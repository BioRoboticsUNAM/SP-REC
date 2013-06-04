using System;
//using System.Speech
using Robotics.API;

namespace SpRec3.CommandExecuters
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
				try
				{
					response =  Response.CreateFromCommand(command, spRec.LoadGrammar(param));
				}
				catch
				{
					response =  Response.CreateFromCommand(command, false);
				}
			}
			this.CommandManager.Busy = false;
			return response;
		}

		#endregion
	}
}
