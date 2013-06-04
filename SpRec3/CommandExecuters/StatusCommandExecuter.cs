using System;
using Robotics.API;

namespace SpRec3.CommandExecuters
{
	public class StatusCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public StatusCommandExecuter(SpeechRecognizer spRec)
			: base("spr_status")
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
			string param = command.Parameters;
			bool success = false;

			try
			{
				switch (param)
				{
					case "enable":
					case "enabled":
						spRec.Enabled = true;
						success = true;
						break;

					case "disable":
					case "disabled":
						spRec.Enabled = false;
						success = true;
						break;

					case "get":
					case "":
						param = spRec.Enabled ? "enable" : "disable";
						success = true;
						break;

					case "toggle":
						spRec.Enabled = !spRec.Enabled;
						param = spRec.Enabled ? "enable" : "disable";
						success = true;
						break;

					default:
						success = false;
						break;
				}
			}
			catch { success = false; }

			return Response.CreateFromCommand(command, success);
		}

		#endregion
	}
}
