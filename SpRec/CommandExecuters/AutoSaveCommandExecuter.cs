using System;
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class AutoSaveCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public AutoSaveCommandExecuter(SpeechRecognizer spRec)
			: base("spr_autosave")
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
			SpeechRecognizer53 reco = spRec as SpeechRecognizer53;
			if (spRec == null)
				return Response.CreateFromCommand(command, false);

			AutoSaveMode mode;
			string p = String.IsNullOrEmpty(command.Parameters) ? String.Empty : command.Parameters.ToLower();
			Response r = Response.CreateFromCommand(command, true);

			if (TryParse(p, out mode))
				reco.AutoSaveMode = mode;
			r.Parameters = AutoSaveModeToString(reco.AutoSaveMode);
			return r;
		}

		private bool TryParse(string s, out AutoSaveMode mode)
		{
			bool success = false;
			mode = AutoSaveMode.None;

			if (s.Contains("none"))
				success = true;
			if (s.Contains("recognized"))
			{
				mode |= AutoSaveMode.Recognized;
				success = true;
			}
			if (s.Contains("rejected"))
			{
				mode |= AutoSaveMode.Rejected;
				success = true;
			}
			return success;
		}

		private string AutoSaveModeToString(AutoSaveMode mode)
		{
			
			switch ((int)mode)
			{
				default:
				case 0:
					return "none";

				case 1:
					return "recognized";

				case 2:
					return "rejected";

				case 3:
					return "all";
			}
		}

		#endregion
	}
}

