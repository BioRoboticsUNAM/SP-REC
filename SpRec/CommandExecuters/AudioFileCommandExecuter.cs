using System;
using System.IO;
using System.Speech.Recognition;
using System.Text;
using Robotics.API;

namespace SpRec.CommandExecuters
{
	public class AudioFileCommandExecuter : AsyncCommandExecuter
	{
		#region Variables

		private SpeechRecognizer spRec;

		#endregion

		#region Constructors

		public AudioFileCommandExecuter(SpeechRecognizer spRec)
			: base("spr_audiofile")
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

		protected override Response AsyncTask(Command command)
		{
			SpeechRecognizer53 reco = spRec as SpeechRecognizer53;
			if ( (spRec == null) || !File.Exists(command.Parameters))
				return Response.CreateFromCommand(command, false);

			RecognitionResult result = reco.FromFile(command.Parameters);
			if((result == null) || (result.Alternates.Count < 1)) 
				return Response.CreateFromCommand(command, false);

			StringBuilder sb = new StringBuilder();
			foreach (RecognizedPhrase a in result.Alternates)
			{
				sb.Append('"');
				sb.Append(a.Text);
				sb.Append("\" ");
				sb.Append(a.Confidence.ToString("0.00"));
				sb.Append(' ');
			}
			if (sb.Length > 0) --sb.Length;

			Response r = Response.CreateFromCommand(command, true);
			r.Parameters = sb.ToString();
			return r;
		}

		public override void DefaultParameterParser(string[] parameters)
		{
			
		}

		#endregion
	}
}
