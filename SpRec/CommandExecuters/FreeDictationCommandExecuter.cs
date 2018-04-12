using System;
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class FreeDictationCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public FreeDictationCommandExecuter(SpeechRecognizer spRec)
			: base("spr_free")
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
						spRec.FreeDictationEnabled = true;
						success = spRec.FreeDictationEnabled == true;
						break;

					case "disable":
					case "disabled":
						spRec.FreeDictationEnabled = false;
						success = spRec.FreeDictationEnabled ==false;
						break;

					case "get":
					case "":
						param = spRec.FreeDictationEnabled ? "enable" : "disable";
						success = true;
						break;

					case "toggle":
						bool prevValue = spRec.FreeDictationEnabled;
						spRec.FreeDictationEnabled = !spRec.FreeDictationEnabled;
						param = spRec.Enabled ? "enable" : "disable";
						success = spRec.FreeDictationEnabled == prevValue;
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
