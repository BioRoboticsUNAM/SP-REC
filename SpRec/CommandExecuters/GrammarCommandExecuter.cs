using System;
//using System.Speech
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class GrammarCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public GrammarCommandExecuter(SpeechRecognizer spRec)
			: base("spr_grammar")
		{
			this.spRec = spRec;
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
			Response response;
			string param = command.Parameters;

			this.CommandManager.Busy = true;

			if ((param == "") || (param == "get"))
			{
				command.Parameters = spRec.HasGrammar ? spRec.GrammarFile : "none";
				response = Response.CreateFromCommand(command, true);
			}
			else
			{
				bool result;
				try { result = spRec.LoadGrammar(param); }
				catch { result = false; }
				response = Response.CreateFromCommand(command, result);
			}
			this.CommandManager.Busy = false;
			return response;
		}

		#endregion
	}
}
