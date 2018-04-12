using System;
using System.Collections.Generic;
using System.IO;
using SpeechLib;
using Robotics.HAL.Sensors;

namespace SpRec
{
	/// <summary>
	/// Implements a Speech Recognizer using Sapi 5.1
	/// </summary>
	public class SpeechRecognizer51 : SpeechRecognizer
	{
		#region Variables

		/// <summary>
		/// Speech Recognizer
		/// </summary>
		private ISpeechRecoContext recoContext;

		/// <summary>
		/// Recognition Grammar
		/// </summary>
		private ISpeechRecoGrammar grammar;

		/// <summary>
		/// Voice profiles
		/// </summary>
		private SortedList<string, SpObjectToken> profiles;

		#endregion

		#region Constuctors

		/// <summary>
		/// Initializes a new instance of SpeechRecognizer51
		/// </summary>
		public SpeechRecognizer51()
		{
			recoContext = new SpeechLib.SpSharedRecoContext();

			recoContext.CmdMaxAlternates = 20;
			recoContext.State = SpeechRecoContextState.SRCS_Disabled;
			((SpSharedRecoContext)recoContext).Recognition +=
				new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoContext_Recognition);
			((SpSharedRecoContext)recoContext).FalseRecognition +=
				new _ISpeechRecoContextEvents_FalseRecognitionEventHandler(SpeechRecognizer_FalseRecognition);
			((SpSharedRecoContext)recoContext).Hypothesis +=
				new _ISpeechRecoContextEvents_HypothesisEventHandler(SpeechRecognizer_Hypothesis);
			((SpSharedRecoContext)recoContext).AudioLevel +=
				new _ISpeechRecoContextEvents_AudioLevelEventHandler(SpeechRecognizer_AudioLevel);
			((SpSharedRecoContext)recoContext).EventInterests |= SpeechRecoEvents.SREAudioLevel;

			GetProfiles();
		}

		~SpeechRecognizer51()
		{
			// free managed resources
			if (grammar != null)
			{
				try
				{
					grammar.DictationUnload();
				}
				catch { }
				grammar = null;
			}
			if (recoContext != null)
			{
				try
				{
					recoContext.State = SpeechRecoContextState.SRCS_Disabled;
					recoContext.Recognizer.Profile = null;
					recoContext.Recognizer.AudioInputStream = null;
				}
				catch { }
				recoContext = null;
			}
		}

		#endregion

		#region Properties

		public override string SelectedProfile
		{
			get { return profiles.Keys[selectedProfile]; }
			set
			{
				if (!profiles.ContainsKey(value)) throw new Exception("Invalid profile name");
				selectedProfile = profiles.IndexOfKey(value);
				recoContext.Recognizer.Profile = profiles[value];
			}
		}

		public override string[] Profiles
		{
			get
			{
				string[] profileNames = new string[profiles.Count];
				for (int i = 0; i < profiles.Count; ++i)
					profileNames[i] = profiles.Keys[i];
				return (string[])profileNames;
			}
		}

		public override bool Enabled
		{
			get { return (recoContext.State == SpeechRecoContextState.SRCS_Enabled); }
			set
			{
				if (value)
					recoContext.State = SpeechRecoContextState.SRCS_Enabled;
				else
					recoContext.State = SpeechRecoContextState.SRCS_Disabled;
				OnStatusChanged();
			}
		}

		public override bool FreeDictationEnabled
		{
			get { return false; }
			set { OnStatusChanged(); }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Tries to load a SRGS grammar for SAPI 5.1 or earlier
		/// </summary>
		/// <returns>true if grammar was loaded successfully, false otherwise</returns>
		protected override bool LoadGrammar(FileInfo grammarFile)
		{

			if ((grammarFile == null)||!grammarFile.Exists) return false;
			hasGrammar = false;
			try
			{
				// set up the grammar
				grammar = recoContext.CreateGrammar(0);
				// set up the dictation grammar
				grammar.DictationLoad("", SpeechLoadOption.SLOStatic);
				grammar.DictationSetState(SpeechRuleState.SGDSInactive);
				// load the command and control grammar
				grammar.CmdLoadFromFile(grammarFile.FullName, SpeechLoadOption.SLOStatic);
				grammar.CmdSetRuleIdState(0, SpeechRuleState.SGDSInactive);
				// activate one of the grammars if we don't want both at the same time
				//if (commandAndControl)
				grammar.CmdSetRuleIdState(0, SpeechRuleState.SGDSActive);
				//else
				//	grammar.DictationSetState(SpeechRuleState.SGDSActive);
				//if (GrammarLoaded != null) GrammarLoaded(this);
				hasGrammar = true;
			}
			catch
			{
				hasGrammar= false;
			}

			return hasGrammar;
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
			ISpeechObjectTokens tokens;
			SpObjectToken token;
			profiles = new SortedList<string, SpObjectToken>();
			string profileName;

			tokens = recoContext.Recognizer.GetProfiles(requiredAtributes, optionalAtributes);
			selectedProfile = 0;
			for (int i = 0; i < tokens.Count; ++i)
			{
				token = tokens.Item(i);
				profileName = token.GetDescription(0);
				profiles.Add(profileName, token);
			}
			selectedProfile = profiles.IndexOfKey(recoContext.Recognizer.Profile.GetDescription(0));
		}

		#endregion

		#region Event Handler Functions

		private void RecoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
		{
			////result_textBox.AppendText(Result.PhraseInfo.GetText(0, -1, true) + "\n");
			//string result;

			//ISpeechPhraseInfo info;
			//ISpeechPhraseAlternate alternate;
			//ISpeechPhraseAlternates alternates = Result.Alternates(20, 0, -1);
			//ISpeechPhraseReplacements replacements;

			//if (alternates != null)
			//    alternate = alternates.Item(0);
			//info = Result.PhraseInfo;
			//replacements = info.Replacements;
			//string rep;
			//if (replacements != null)
			//    rep = replacements.Item(0).Text;

			//result = Result.PhraseInfo.GetText(0, -1, true);
			//if (result.Length < 1) result = "???";
			//OnSpeechRecognized(null);

			////result_textBox.AppendText(Result.PhraseInfo.GetText(0, -1, true) + "\n");
			//string result;

			string result;
			float confidence;
			RecognizedSpeechAlternate[] alternates;
			RecognizedSpeech recognizedSpeech;

			result = Result.PhraseInfo.GetText(0, -1, true);
			confidence = Result.PhraseInfo.Rule.EngineConfidence;
			//confidence = Result.PhraseInfo.Rule.Confidence;
			if (result.Length < 1)
				return;

			alternates = new RecognizedSpeechAlternate[1];
			alternates[0] = new RecognizedSpeechAlternate(result, confidence);
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechRecognized(recognizedSpeech);
		}

		private void SpeechRecognizer_FalseRecognition(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
		{
			string result;
			float confidence;
			RecognizedSpeechAlternate[] alternates;
			RecognizedSpeech recognizedSpeech;

			result = Result.PhraseInfo.GetText(0, -1, true);
			confidence = Result.PhraseInfo.Rule.EngineConfidence;
			if (result.Length < 1)
				return;

			alternates = new RecognizedSpeechAlternate[1];
			alternates[0] = new RecognizedSpeechAlternate(result, confidence);
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechRecognitionRejected(recognizedSpeech);
		}

		private void SpeechRecognizer_Hypothesis(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
		{
			string result;
			float confidence;
			RecognizedSpeechAlternate[] alternates;
			RecognizedSpeech recognizedSpeech;

			result = Result.PhraseInfo.GetText(0, -1, true);
			confidence = Result.PhraseInfo.Rule.EngineConfidence;
			if (result.Length < 1)
				return;

			alternates = new RecognizedSpeechAlternate[1];
			alternates[0] = new RecognizedSpeechAlternate(result, confidence);
			recognizedSpeech = new RecognizedSpeech(alternates);

			OnSpeechHypothesized(recognizedSpeech);
		}

		private void SpeechRecognizer_AudioLevel(int StreamNumber, object StreamPosition, int level)
		{
			OnAudioLevelChanged(level);
		}

		#endregion
	}
}
