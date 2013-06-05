using System;
using System.Text.RegularExpressions;
using Robotics.API;

namespace SpRec3.CommandExecuters
{
	public class WordsCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;
		private Regex rxWordExtractor;

		#endregion

		#region Constructors

		public WordsCommandExecuter(SpeechRecognizer spRec)
			: base("spr_words")
		{
			this.spRec = spRec;
			this.rxWordExtractor = new Regex(@"(?<timeOut>\d+)\s+(?<words>(\w+(\s+\w+)*\,)*(\w+(\s+\w+)*))", RegexOptions.Compiled);
		}

		#endregion

		#region Properties

		public override bool ParametersRequired
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region Methods

		protected override Response SyncTask(Command command)
		{
			return Response.CreateFromCommand(command, false);
			/*
			Match m;
			bool result;
			string[] words;
			int timeOut;
			
			m = rxWordExtractor.Match(command.Parameters);
			if (!m.Success)
				return Response.CreateFromCommand(command, false);

			try
			{
				words = m.Result("${words}").Split(',');
				timeOut = Int32.Parse(m.Result("${timeOut}"));
				frmSpRec.AddToExpectedPhraseList(words, timeOut);
				result = true;
			}
			catch { result = false; }
			return Response.CreateFromCommand(command, result);
			*/
		}

		#endregion
	}
}
