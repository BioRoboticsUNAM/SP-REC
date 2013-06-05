using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;
using Robotics.HAL.Sensors;
using SpeechLib;

namespace SpRec3
{
	/// <summary>
	/// Implements a Speech Recognizer using Sapi 5.3
	/// </summary>
	public class SpeechRecognizer53 : SpeechRecognizer
	{
		#region Variables

		//private ISpeechRecoContext recoContext;
		private SpeechRecognitionEngine engine;
		
		//private ISpeechRecoGrammar grammar;
		private Grammar grammar;

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
			Enabled = false;
			SetupFreeDictationGrammar();
		}

		#endregion

		#region Properties

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
			hasGrammar = false;
			if ((grammarFile == null) || !grammarFile.Exists) return false;

			FreeDictationEnabled = false;
			lock (oLock)
			{
				engine.UnloadAllGrammars();
				try
				{
					grammar = new Grammar(grammarFile.FullName);
					engine.LoadGrammar(grammar);
					hasGrammar = true;
					this.grammarFile = grammarFile.FullName;
				}
				catch
				{
					hasGrammar = false;
				}
			}

			if (!hasGrammar)
			{
				GrammarConverter grammarConverter = new GrammarConverter();
				string temp = Path.GetTempFileName();
				try
				{
					grammarConverter.ConvertFile(grammarFile.FullName, temp);
					grammar = new Grammar(temp);
					lock (oLock)
					{
						engine.LoadGrammar(grammar);
					}
					hasGrammar = true;
					this.grammarFile = grammarFile.FullName;
				}
				catch
				{
					if (!String.IsNullOrEmpty(temp))
						File.Delete(temp);
					hasGrammar = false;
				}
			}

			AddFreeDictationGrammar();
			return hasGrammar;
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
				this.engine.MaxAlternates = 20;
			}
		}

		private void SetupFreeDictationGrammar()
		{
			freeDictationGrammar = new DictationGrammar();
			freeDictationGrammar.Enabled = false;
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

			RecognizedSpeechAlternate[] alternates;
			RecognizedPhrase phrase;
			RecognizedSpeech recognizedSpeech;

			alternates = new RecognizedSpeechAlternate[e.Result.Alternates.Count];
			for (int i = 0; i < e.Result.Alternates.Count; ++i)
			{
				phrase = e.Result.Alternates[i];
				alternates[i] = new RecognizedSpeechAlternate(phrase.Text, phrase.Confidence);
			}
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechRecognitionRejected(recognizedSpeech);
		}

		private void speechRecognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Confidence < 0.1) || (e.Result.Alternates == null) || (e.Result.Alternates.Count < 1))
				return;

			RecognizedSpeechAlternate[] alternates;
			RecognizedPhrase phrase;
			RecognizedSpeech recognizedSpeech;

			alternates = new RecognizedSpeechAlternate[e.Result.Alternates.Count];
			for (int i = 0; i < e.Result.Alternates.Count; ++i)
			{
				phrase = e.Result.Alternates[i];
				alternates[i] = new RecognizedSpeechAlternate(phrase.Text, phrase.Confidence);
			}
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechHypothesized(recognizedSpeech);
		}

		private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			if ((e == null) || (e.Result == null) || (e.Result.Alternates ==null) || (e.Result.Alternates.Count < 1))
				return;

			RecognizedSpeechAlternate[] alternates;
			RecognizedPhrase phrase;
			RecognizedSpeech recognizedSpeech;

			alternates = new RecognizedSpeechAlternate[e.Result.Alternates.Count];
			for (int i = 0; i < e.Result.Alternates.Count; ++i)
			{
				phrase = e.Result.Alternates[i];
				alternates[i] = new RecognizedSpeechAlternate(phrase.Text, phrase.Confidence);
			}
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechRecognized(recognizedSpeech);
		}

		

		#endregion
	}
}
