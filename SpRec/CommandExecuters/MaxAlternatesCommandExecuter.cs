using System;
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class MaxAlternatesCommandExecuter : SyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public MaxAlternatesCommandExecuter(SpeechRecognizer spRec)
			: base("spr_maxalternates")
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

			int alternates;
			Response r = Response.CreateFromCommand(command, true);
			if (String.IsNullOrEmpty(command.Parameters) || !Int32.TryParse(command.Parameters, out alternates) || (alternates < 1) || (alternates > 50))
			{
				r.Parameters = reco.MaxAlternates.ToString();
				return r;
			}
			else
				reco.MaxAlternates = alternates;
			return r;
		}

		#endregion
	}
}
