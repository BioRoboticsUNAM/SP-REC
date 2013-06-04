using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Speech;
using System.Speech.Recognition;
using System.Xml;
using Robotics.HAL.Sensors;

namespace SpRec3
{
	#region Delegates
	
	public delegate void SpeechRecognizedStatusChangedEH(SpeechRecognizer sender);
	public delegate void SpeechRecognizedEH(SpeechRecognizer sender, RecognizedSpeech recognizedSpeech);
	public delegate void AudioLevelChangedEH(int audioLevel);

	#endregion

	public abstract class SpeechRecognizer
	{
		#region Variables

		protected bool hasGrammar = false;

		private string grammarFile;

		protected int selectedProfile;

		#endregion

		#region Constuctors

		public SpeechRecognizer()
		{
			hasGrammar = false;
		}

		#endregion

		#region Properties

		public abstract string SelectedProfile
		{
			get;
			set;
		}

		public abstract string[] Profiles
		{
			get;
		}

		public abstract bool Enabled
		{
			get;
			set;
		}

		public abstract bool FreeDictationEnabled { get; set; }

		public bool HasGrammar
		{
			get { return hasGrammar; }
		}

		public virtual string GrammarFile
		{
			get { return grammarFile; }
			protected set { grammarFile = value; }
		}

		#endregion

		#region Events

		public event SpeechRecognizedEH SpeechRecognized;
		public event SpeechRecognizedEH SpeechHypothesized;
		public event SpeechRecognizedEH SpeechRecognitionRejected;
		public event AudioLevelChangedEH AudioLevelChanged;
		public event SpeechRecognizedStatusChangedEH StatusChanged;
		public event SpeechRecognizedStatusChangedEH GrammarLoaded;

		#endregion

		#region Methods

		public virtual bool LoadGrammar(string grammarFilePath)
		{
			bool result;
			if (!File.Exists(grammarFilePath))
				return false;
			FileInfo fi = new FileInfo(grammarFilePath);
			result = LoadGrammar(fi);
			OnGrammarLoaded();
			return result;
		}

		protected abstract bool LoadGrammar(FileInfo grammarFile);

		public abstract bool EnableRule(string ruleName);

		public abstract bool DisableRule(string ruleName);

		/// <summary>
		/// Rises the GrammarLoaded event
		/// </summary>
		protected virtual void OnGrammarLoaded()
		{
			if (this.GrammarLoaded != null)
				this.GrammarLoaded(this);
		}

		/// <summary>
		/// Rises the SpeechRecognized event
		/// </summary>
		protected virtual void OnSpeechRecognized(RecognizedSpeech recognizedSpeech)
		{
			if (SpeechRecognized != null)
				SpeechRecognized(this, recognizedSpeech);
		}

		/// <summary>
		/// Rises the SpeechHypothesized event
		/// </summary>
		protected virtual void OnSpeechHypothesized(RecognizedSpeech recognizedSpeech)
		{
			if (SpeechHypothesized != null)
				SpeechHypothesized(this, recognizedSpeech);
		}

		/// <summary>
		/// Rises the SpeechRecognitionRejected event
		/// </summary>
		protected virtual void OnSpeechRecognitionRejected(RecognizedSpeech recognizedSpeech)
		{
			if (SpeechRecognitionRejected != null)
				SpeechRecognitionRejected(this, recognizedSpeech);
		}

		/// <summary>
		/// Rises the StatusChanged event
		/// </summary>
		protected virtual void OnStatusChanged()
		{
			if (this.StatusChanged != null)
				this.StatusChanged(this);
		}

		/// <summary>
		/// Rises the AudioLevelUpdated event
		/// </summary>
		protected virtual void OnAudioLevelChanged(int audioLevel)
		{
			if (AudioLevelChanged != null) AudioLevelChanged(audioLevel);
		}

		#endregion
	}
}
