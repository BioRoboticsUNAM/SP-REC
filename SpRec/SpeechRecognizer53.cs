using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;
using Robotics.HAL.Sensors;
using SpeechLib;

namespace SpRec
{
	[Flags]
	public enum AutoSaveMode
	{
		None = 0,
		Recognized = 1,
		Rejected = 2
	}

	#region Delegates

	public delegate void FileSpeechRecognizedEH(SpeechRecognizer53 sender, RecognizedSpeech recognizedSpeech);

	#endregion

	/// <summary>
	/// Implements a Speech Recognizer using Sapi 5.3
	/// </summary>
	public class SpeechRecognizer53 : SpeechRecognizer
	{
		#region Variables

		//private ISpeechRecoContext recoContext;
		private SpeechRecognitionEngine engine;
		private SpeechRecognitionEngine engineForFiles;
		
		//private ISpeechRecoGrammar grammar;
		private Grammar grammar;
		private Grammar grammarForFiles;

		private Grammar freeDictationGrammar;

		/// <summary>
		/// Object used to lock the access to the engine
		/// </summary>
		protected object oLock;

		private bool enabled;

		protected string grammarFile;

		/// <summary>
		/// Voice profiles
		/// </summary>
		private SortedList<string, SpObjectToken> profiles;

		#endregion

		#region Constuctors

		public SpeechRecognizer53()
		{
			//int engines = SpeechRecognitionEngine.InstalledRecognizers().Count;
			oLock = new Object();
			hasGrammar = false;
			GetProfiles();
			SetupEngine();
			SetupEngineForFiles();
			Enabled = false;
			SetupFreeDictationGrammar();
		}

		#endregion

		#region Events

		public event FileSpeechRecognizedEH FileSpeechRecognized;
		public event FileSpeechRecognizedEH FileSpeechHypothesized;
		public event FileSpeechRecognizedEH FileSpeechRecognitionRejected;

		#endregion

		#region Properties

		public AutoSaveMode AutoSaveMode { get; set; }

		public override string SelectedProfile
		{
			get { return profiles.Keys[selectedProfile]; }
			set
			{
				if (!profiles.ContainsKey(value)) throw new Exception("Invalid profile name");
				if (profiles.IndexOfKey(value) == selectedProfile)
					return;
				selectedProfile = profiles.IndexOfKey(value);

				lock (oLock)
				{
					if (this.engine != null)
						this.engine.SetInputToNull();
					// Try to acquire a recognition context...
					try
					{
						SpSharedRecoContext recoContext = new SpSharedRecoContext();
						recoContext.Recognizer.Profile = profiles[value];
					}
					// If no recognition context could be acquired, reload the default engine
					catch { }
					SetupEngine();
					LoadGrammar(this.grammarFile);
					if (hasGrammar && this.enabled)
					{
						this.engine.SetInputToDefaultAudioDevice();
						this.engine.RecognizeAsync(RecognizeMode.Multiple);
					}
					else
					{
						this.engine.SetInputToNull();
					}
				}
			}
		}

		public override string[] Profiles
		{
			get
			{
				string[] profileNames = new string[this.profiles.Count];
				for (int i = 0; i < this.profiles.Count; ++i)
					profileNames[i] = this.profiles.Keys[i];
				return (string[])profileNames;
			}
		}

		public override bool Enabled
		{
			get { return enabled; }
			set
			{
				if (enabled == value)
					return;

				lock (oLock)
				{
					if (hasGrammar && value)
					{
						engine.SetInputToDefaultAudioDevice();
						engine.RecognizeAsync(RecognizeMode.Multiple);
					}
					else
					{
						engine.RecognizeAsyncCancel();
						engine.RecognizeAsyncStop();
						System.Threading.Thread.Sleep(10);
						engine.SetInputToNull();
					}
				}
				enabled = value;
				OnStatusChanged();
			}
		}

		public override bool FreeDictationEnabled
		{
			get { return (engine != null) && freeDictationGrammar.Enabled; }
			set
			{
				lock (oLock)
				{
					freeDictationGrammar.Enabled = value;
				}
				OnStatusChanged();
			}
		}

		public override string GrammarFile
		{
			get { return this.grammarFile; }
		}

		public int MaxAlternates
		{
			get { return this.engine.MaxAlternates; }
			set
			{
				lock (oLock)
				{
					this.engine.MaxAlternates = value;
				}
				lock (this.engineForFiles)
				{
					this.engineForFiles.MaxAlternates = value;
				}
			}
		}

		public int InitialSilenceTimeout
		{
			get { return this.engine.InitialSilenceTimeout.Milliseconds; }
			set
			{
				lock (oLock)
				{
					this.engine.InitialSilenceTimeout = new TimeSpan(0, 0, 0, 0, value);
				}
				lock (this.engineForFiles)
				{
					this.engineForFiles.InitialSilenceTimeout = new TimeSpan(0, 0, 0, 0, value); ;
				}
			}
		}

		public int EndSilenceTimeout
		{
			get { return this.engine.EndSilenceTimeout.Milliseconds; }
			set
			{
				lock (oLock)
				{
					this.engine.EndSilenceTimeout = new TimeSpan(0, 0, 0, 0, value);
				}
				lock (this.engineForFiles)
				{
					this.engineForFiles.EndSilenceTimeout = new TimeSpan(0, 0, 0, 0, value);
				}
			}
		}

		public int EndSilenceTimeoutAmbiguous
		{
			get { return this.engine.EndSilenceTimeoutAmbiguous.Milliseconds; }
			set
			{
				lock (oLock)
				{
					this.engine.EndSilenceTimeoutAmbiguous = new TimeSpan(0, 0, 0, 0, value);
				}
				lock (this.engineForFiles)
				{
					this.engineForFiles.EndSilenceTimeoutAmbiguous = new TimeSpan(0, 0, 0, 0, value);
				}
			}
		}

		#endregion

		#region Methods

		private void AddFreeDictationGrammar()
		{
			engine.LoadGrammar(freeDictationGrammar);
		}

		public override bool EnableRule(string ruleName)
		{
			//try
			//{
			//	grammar.CmdSetRuleState(ruleName, SpeechRuleState.SGDSActive);
			//	return true;
			//}
			//catch { return false; }
			return true;
		}

		public override bool DisableRule(string ruleName)
		{
			//try
			//{
			//	grammar.CmdSetRuleState(ruleName, SpeechRuleState.SGDSInactive);
			//	return true;
			//}
			//catch { return false; }
			return false;
		}

		private RecognizedSpeech GenerateRecognizedSpeechObject(System.Collections.ObjectModel.ReadOnlyCollection<RecognizedPhrase> engineAlternates)
		{
			RecognizedSpeechAlternate[] alternates;
			RecognizedPhrase phrase;
			RecognizedSpeech recognizedSpeech;

			alternates = new RecognizedSpeechAlternate[engineAlternates.Count];
			for (int i = 0; i < engineAlternates.Count; ++i)
			{
				phrase = engineAlternates[i];
				alternates[i] = new RecognizedSpeechAlternate(phrase.Text, phrase.Confidence);
			}
			recognizedSpeech = new RecognizedSpeech(alternates);
			return recognizedSpeech;
		}

		private void GetProfiles()
		{
			string requiredAtributes = "";
			string optionalAtributes = "";
			SpSharedRecoContext recoContext;
			ISpeechObjectTokens tokens;
			SpObjectToken token;
			this.profiles = new SortedList<string, SpObjectToken>();
			string profileName;

			selectedProfile = 0;
			// Attempt to get profile list
			try
			{
				recoContext = new SpeechLib.SpSharedRecoContext();
				tokens = recoContext.Recognizer.GetProfiles(requiredAtributes, optionalAtributes);
				for (int i = 0; i < tokens.Count; ++i)
				{
					token = tokens.Item(i);
					profileName = token.GetDescription(0);
					this.profiles.Add(profileName, token);
				}
				selectedProfile = this.profiles.IndexOfKey(recoContext.Recognizer.Profile.GetDescription(0));
			}
			catch
			{
				// If no profiles could be retreived or an error occurred, clear the list and add a default profile with no token
				profiles.Clear();
				profiles.Add("Default", null);
			}
		}

		/// <summary>
		/// Tries to load a SGRS grammar for SAPI 5.3 and above
		/// </summary>
		/// <returns>true if grammar was loaded successfully, false otherwise</returns>
		protected override bool LoadGrammar(FileInfo grammarFile)
		{
			Grammar grammar;
			if ((grammarFile == null) || !grammarFile.Exists) return false;

			grammar = LoadSapi53Grammar(grammarFile.FullName);
			grammarForFiles = LoadSapi53Grammar(grammarFile.FullName);
			if (grammar == null)
			{
				grammar = LoadSapi51Grammar(grammarFile.FullName);
				grammarForFiles = LoadSapi51Grammar(grammarFile.FullName);
			}
			if (grammar == null)
				return false;

			lock (oLock)
			{
				this.engine.UnloadAllGrammars();
				try
				{
					this.engine.LoadGrammar(grammar);
				}
				catch
				{
					this.grammar = null;
					this.hasGrammar = false;
					return false;
				}
				this.grammar = grammar;
				this.hasGrammar = true;
				this.grammarFile = grammarFile.FullName;
			}

			lock (engineForFiles)
			{
				engineForFiles.UnloadAllGrammars();
				engineForFiles.LoadGrammar(grammarForFiles);
			}

			AddFreeDictationGrammar();
			return true;
		}

		private static Grammar LoadSapi51Grammar(string path)
		{
			Grammar grammar;
			string temp = Path.GetTempFileName();
			GrammarConverter grammarConverter = new GrammarConverter();
			try
			{
				grammarConverter.ConvertFile(path, temp);
				grammar = new Grammar(temp);
			}
			catch { return null; }
			finally
			{
				if (!String.IsNullOrEmpty(temp))
					File.Delete(temp);
			}
			return grammar;
		}

		private static Grammar LoadSapi53Grammar(string path)
		{
			try
			{
				Grammar grammar = new Grammar(path);
				return grammar;
			}
			catch { return null; }
		}

		/// <summary>
		/// Rises the SpeechRecognized event
		/// </summary>
		protected virtual void OnFileSpeechRecognized(RecognizedSpeech recognizedSpeech)
		{
			if (FileSpeechRecognized != null)
				FileSpeechRecognized(this, recognizedSpeech);
		}

		/// <summary>
		/// Rises the SpeechHypothesized event
		/// </summary>
		protected virtual void OnFileSpeechHypothesized(RecognizedSpeech recognizedSpeech)
		{
			if (FileSpeechHypothesized != null)
				FileSpeechHypothesized(this, recognizedSpeech);
		}

		/// <summary>
		/// Rises the SpeechRecognitionRejected event
		/// </summary>
		protected virtual void OnFileSpeechRecognitionRejected(RecognizedSpeech recognizedSpeech)
		{
			if (FileSpeechRecognitionRejected != null)
				FileSpeechRecognitionRejected(this, recognizedSpeech);
		}

		private static void SaveRecognized(SpeechRecognizedEventArgs e)
		{
			try
			{
				string path = "wave";
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				path = Path.Combine(path, "audio " + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + " recognized.wav");
				using (FileStream fs = File.OpenWrite(path))
				{
					e.Result.Audio.WriteToWaveStream(fs);
				}
			}
			catch { }
		}

		private static void SaveRejected(SpeechRecognitionRejectedEventArgs e)
		{
			try
			{
				string path = "wave";
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				path = Path.Combine(path, "audio " + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + " rejected.wav");
				using (FileStream fs = File.OpenWrite(path))
				{
					e.Result.Audio.WriteToWaveStream(fs);
				}
			}
			catch { }
		}

		private void SetupEngine()
		{
			lock (oLock)
			{
				if (this.engine != null)
					this.engine.Dispose();
				this.engine = new SpeechRecognitionEngine();
				this.engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechRecognizer_SpeechRecognized);
				this.engine.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(speechRecognizer_SpeechHypothesized);
				this.engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(speechRecognizer_SpeechRecognitionRejected);
				this.engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(speechRecognizer_AudioLevelUpdated);
				this.engine.MaxAlternates = 10;
			}
		}

		private void SetupEngineForFiles()
		{
			lock (oLock)
			{
				this.engineForFiles = new SpeechRecognitionEngine();
				this.engineForFiles.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(fileSpeechRecognizer_SpeechRecognized);
				//this.engineForFiles.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(fileSpeechRecognizer_SpeechHypothesized);
				this.engineForFiles.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(fileSpeechRecognizer_SpeechRecognitionRejected);
				this.engineForFiles.MaxAlternates = this.engine.MaxAlternates;
			}
		}

		private void SetupFreeDictationGrammar()
		{
			freeDictationGrammar = new DictationGrammar();
			freeDictationGrammar.Enabled = false;
		}

		public RecognitionResult FromFile(string filePath)
		{
			lock (engineForFiles)
			{
				try
				{
					this.engineForFiles.SetInputToWaveFile(filePath);
					RecognitionResult result = engineForFiles.Recognize();
					return result;
				}
				catch
				{
					return null;
				}
			}
		}

		#endregion

		#region Event Handler Functions

		private void speechRecognizer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
		{
			OnAudioLevelChanged(e.AudioLevel);
		}

		private void speechRecognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Confidence < 0.1) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;

			RecognizedSpeech recognizedSpeech = GenerateRecognizedSpeechObject(e.Result.Alternates);
			OnSpeechRecognitionRejected(recognizedSpeech);
			if((this.AutoSaveMode & AutoSaveMode.Rejected) == AutoSaveMode.Rejected)
				SaveRejected(e);
		}

		private void speechRecognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Confidence < 0.1) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;

			RecognizedSpeech recognizedSpeech = GenerateRecognizedSpeechObject(e.Result.Alternates);

			OnSpeechHypothesized(recognizedSpeech);
		}

		private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;

			RecognizedSpeech recognizedSpeech = GenerateRecognizedSpeechObject(e.Result.Alternates);

			OnSpeechRecognized(recognizedSpeech);
			if ((this.AutoSaveMode & AutoSaveMode.Recognized) == AutoSaveMode.Recognized)
				SaveRecognized(e);

		}

		private void fileSpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;
			RecognizedSpeech recognizedSpeech = GenerateRecognizedSpeechObject(e.Result.Alternates);
			OnSpeechRecognized(recognizedSpeech);

		}

		private void fileSpeechRecognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Confidence < 0.1) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;
			RecognizedSpeech recognizedSpeech = GenerateRecognizedSpeechObject(e.Result.Alternates);
			OnSpeechRecognitionRejected(recognizedSpeech);
		}

		#endregion
	}
}
