using System;
using System.Windows.Forms;
using System.Net;

namespace SpRec
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FrmSpRec frmSpRec = new FrmSpRec();
			if (args.Length > 0)
				parseArgs(frmSpRec, args);
			Application.Run(frmSpRec);
		}

		private static void parseArgs(FrmSpRec frmSpRec, string[] args)
		{
			int resultInt;
			//byte resultByte;
			//double resultDouble;
			IPAddress resultIP;
			for (int i = 0; i < args.Length; ++i)
			{

				switch (args[i].ToLower())
				{
					case "-a":
						if (++i > args.Length) return;
						if (IPAddress.TryParse(args[i], out resultIP))
							frmSpRec.TcpServerAddress = resultIP;
						break;

					case "-g":
						if (++i > args.Length) return;
						if (System.IO.File.Exists(args[i]))
							frmSpRec.GrammarFile = args[i];
						break;

					case "-h":
					case "--h":
					case "-help":
					case "--help":
					case "/h":
						showHelp();
						break;

					case "-r":
						if (++i > args.Length) return;
						if (Int32.TryParse(args[i], out resultInt) && (resultInt >= 0))
							frmSpRec.TcpPortIn = resultInt;
						break;

					case "-sr":
						frmSpRec.SendRejected = true;
						break;

					case "-w":
						if (++i > args.Length) return;
						if (Int32.TryParse(args[i], out resultInt) && (resultInt >= 0))
							frmSpRec.TcpPortOut = resultInt;
						break;
				}
			}
		}

		private static void showHelp()
		{
			// -a 127.0.0.1 -r 2001 -w 2000 -sim
			Console.WriteLine("SocketSpeech Help");
			Console.WriteLine("-autosockets\tSocket autoconnect");
			Console.WriteLine("-a\t\tTcp server Address");
			Console.WriteLine("-g\t\tGrammar XML file");
			Console.WriteLine("-r\t\tTcp input port (server)");
			Console.WriteLine("-raw\t\tRecognition RAW mode. Set 0 for raw, 1 for command");
			Console.WriteLine("-w\t\tTcp output port (client)");
		}
	}
}