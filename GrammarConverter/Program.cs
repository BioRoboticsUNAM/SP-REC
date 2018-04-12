using System;
using System.IO;

namespace GrammarConverter
{
	public class Program
	{
		static void Main(string[] args)
		{
			SpRec.GrammarConverter converter;
			string input;
			string output;
			string outputFile;

			input = null;
			converter = new SpRec.GrammarConverter();
			while (input == null)
			{
				Console.WriteLine("Xml grammar file to convert: ");
				input = Console.ReadLine();
				if (!File.Exists(input))
				{
					Console.WriteLine("Invalid input file (file not exist).");
					Console.WriteLine();
					input = null;
					continue;
				}
				try
				{
					input = File.ReadAllText(input);
				}
				catch
				{
					Console.WriteLine("Can not access input file.");
					Console.WriteLine();
					input = null;
					continue;
				}
			}

			Console.WriteLine("Converting...");
			try
			{
				output = converter.Convert(input);
				if (output == null)
				{
					Console.WriteLine("Invalid grammar file.");
					return;
				}
			}
			catch
			{
				Console.WriteLine("Invalid grammar file.");
				return;
			}

			outputFile = null;
			while (outputFile == null)
			{
				Console.WriteLine("Output file: ");
				outputFile = Console.ReadLine();
				if (File.Exists(outputFile))
				{
					do
					{
						Console.WriteLine("File already exists. Overwrite (yes/NO)? ");
						input = Console.ReadLine().ToLower();
					} while ((input != "y") && (input != "yes") && (input != "n") && (input != "no"));
					if ((input != "y") && (input != "yes"))
					{
						Console.WriteLine();
						continue;
					}
				}

				try
				{
					File.WriteAllText(outputFile, output);
				}
				catch
				{
					Console.WriteLine("Can not write converted file.");
					Console.WriteLine();
					outputFile = null;
				}

			}

		}
	}
}