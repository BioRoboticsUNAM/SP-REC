using System;
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class Rec_EnaCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public Rec_EnaCommandExecuter(SpeechRecognizer spRec)
			: base("sprec_na")
		{
			this.spRec = spRec;
		}

		#endregion

		#region Properties

		public override bool ParametersRequired
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region Methods

		protected override Response SyncTask(Command command)
		{
			bool success;

			success = false;
			try
			{
				if (command.Parameters.StartsWith("enable"))
				{

					spRec.Enabled = true;
					success = true;

				}
				else if (command.Parameters.StartsWith("disable"))
				{
					spRec.Enabled = false;
					success = true;
				}
				else if (command.Parameters == "toggle")
				{
					spRec.Enabled = !spRec.Enabled;
					success = true;
				}
			}
			catch { success = false; }
			return Response.CreateFromCommand(command, success);
		}

		#endregion
	}
}
