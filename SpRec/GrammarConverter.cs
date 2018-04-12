using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace SpRec
{
	public class GrammarConverter
	{
		public void ConvertFile(string inputFile, string outputFile)
		{
			File.WriteAllText(outputFile, Convert(new FileInfo(inputFile)));
		}

		public string Convert(string xml)
		{
			MemoryStream ms = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xml));
			XmlReader reader = new XmlTextReader(ms);
			string result = Convert(reader);
			reader.Close();
			ms.Close();
			ms.Dispose();
			return result;
		}

		public string Convert(FileInfo fi)
		{
			if (!fi.Exists)
				return null;
			XmlTextReader reader = new XmlTextReader(fi.FullName);
			return Convert(reader);
		}

		public string Convert(XmlReader reader)
		{
			MemoryStream ms = new MemoryStream(1048576);
			XmlTextWriter writer;
			List<string> topLevelRules;

			writer = new XmlTextWriter(ms, Encoding.UTF8);
			writer.Indentation = 1;
			writer.IndentChar = '\t';
			writer.Formatting = Formatting.Indented;
			writer.Namespaces = false;

			if (!ParseGrammarElement(reader, writer))
				return Clear(writer, ms);
			if (!ParseRules(reader, writer, out topLevelRules))
				return Clear(writer, ms);
			CreateMainRule(topLevelRules, writer);
			if (!ParseGrammarEndElement(reader, writer))
				return Clear(writer, ms);
			writer.Flush();
			string result = ASCIIEncoding.UTF8.GetString(ms.ToArray());
			return result;
		}

		private void CreateMainRule(List<string> topLevelRules, XmlTextWriter writer)
		{
			writer.WriteStartElement("rule");
			writer.WriteAttributeString("id", "main");
			writer.WriteAttributeString("scope", "public");
			writer.WriteStartElement("one-of");
			foreach (string rule in topLevelRules)
			{
				writer.WriteStartElement("item");
				writer.Formatting = Formatting.None;
				writer.WriteStartElement("ruleref");
				writer.WriteAttributeString("uri", "#" + rule);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.Formatting = Formatting.Indented;
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
		}

		private string Clear(XmlTextWriter writer, MemoryStream ms)
		{
			writer.Close();
			ms.Close();
			ms.Dispose();
			return null;
		}

		private void WriteDeclaration(XmlWriter writer)
		{
		}

		private void ParseComment(XmlReader reader, XmlWriter writer)
		{
			writer.WriteComment(reader.Value);
		}

		private bool ReadElementText(XmlReader reader, XmlWriter writer, out string text)
		{
			bool found;

			found = false;
			text = null;
			while (!found && reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Text:
						text = reader.Value;
						return true;

					case XmlNodeType.Comment:
						ParseComment(reader, writer);
						break;

					case XmlNodeType.Whitespace:
						break;

					default:
						return false;
				}
			}
			return false;
		}

		private bool ReadElement(XmlReader reader, XmlWriter writer, string elementName)
		{
			bool found;

			found = false;

			while (!found && reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						if (String.Compare(reader.Name, elementName, true) == 0)
							return true;
						return false;

					case XmlNodeType.Comment:
						ParseComment(reader, writer);
						break;

					case XmlNodeType.Whitespace:
						break;

					default:
						return false;
				}
			}
			return false;
		}

		private bool ReadElement(XmlReader reader, XmlWriter writer, out string elementName)
		{
			bool found;

			found = false;
			elementName = null;
			while (!found && reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						elementName = reader.Name.ToLower();
						return true;

					case XmlNodeType.Comment:
						ParseComment(reader, writer);
						break;

					case XmlNodeType.Whitespace:
						break;

					default:
						return false;
				}
			}
			return false;
		}

		private bool ReadEndElement(XmlReader reader, XmlWriter writer, out string elementName)
		{
			bool found;

			found = false;
			elementName = null;

			while (!found && reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.EndElement:
						elementName = reader.Name.ToLower();
						return true;

					case XmlNodeType.Comment:
						ParseComment(reader, writer);
						break;

					case XmlNodeType.Whitespace:
						break;

					default:
						return false;
				}
			}
			return false;
		}

		private bool ReadAttribute(XmlReader reader, string attributeName)
		{
			while (reader.MoveToNextAttribute())
			{
				return (String.Compare(reader.Name, attributeName, true) == 0);
			}
			return false;
		}

		private bool ReadAttribute(XmlReader reader, string attributeName, out string value)
		{
			value = null;
			while (reader.MoveToNextAttribute())
			{
				if (String.Compare(reader.Name, attributeName, true) == 0)
				{
					value = reader.Value;
					return true;
				}
				return false;
			}
			return false;
		}

		private bool SkipSpacesAndComments(XmlReader reader, XmlWriter writer)
		{
			while ((reader.NodeType == XmlNodeType.Whitespace) || (reader.NodeType == XmlNodeType.Comment))
			{
				if (reader.NodeType == XmlNodeType.Comment)
					ParseComment(reader, writer);
				if (!reader.Read())
					return false;
			}
			return true;
		}

		private void ParseDocumentType(XmlReader reader, XmlWriter writer)
		{
			if (reader.NodeType != XmlNodeType.DocumentType)
				return;
			//reader.
			//writer.WriteDocType();
		}

		private void ParseProcessingInstruction(XmlReader reader, XmlWriter writer)
		{
			if (reader.NodeType != XmlNodeType.ProcessingInstruction)
				return;
			writer.WriteProcessingInstruction(reader.Name, reader.Value);
		}

		private bool ParseGrammarElement(XmlReader reader, XmlWriter writer)
		{
			bool declarationWritten;

			if ((reader.NodeType == XmlNodeType.None) && !reader.Read())
				return false;
			if (!SkipSpacesAndComments(reader, writer))
				return false;
			declarationWritten = false;
			if (reader.NodeType == XmlNodeType.XmlDeclaration)
			{
				declarationWritten = true;
				WriteDeclaration(writer);
				reader.Read();
			}
			if (!SkipSpacesAndComments(reader, writer))
				return false;
			if (reader.NodeType == XmlNodeType.DocumentType)
				ParseDocumentType(reader, writer);
			if (!SkipSpacesAndComments(reader, writer))
				return false;
			while (reader.NodeType == XmlNodeType.ProcessingInstruction)
			{
				ParseProcessingInstruction(reader, writer);
				if (!SkipSpacesAndComments(reader, writer))
					return false;
			}
			if (!SkipSpacesAndComments(reader, writer))
				return false;

			if ((reader.NodeType != XmlNodeType.Element) || (String.Compare("grammar", reader.Name, true) != 0))
				return false;

			if (!ReadAttribute(reader, "langid") || (reader.Value != "409"))
				return false;

			if (!declarationWritten)
				WriteDeclaration(writer);
			writer.WriteStartElement("grammar");
			writer.WriteAttributeString("version", "1.0");
			writer.WriteAttributeString("xml:lang", "en-US");
			writer.WriteAttributeString("xmlns", "http://www.w3.org/2001/06/grammar");
			writer.WriteAttributeString("tag-format", "semantics/1.0");
			writer.WriteAttributeString("root", "main");
			return true;
		}

		private bool ParseGrammarEndElement(XmlReader reader, XmlWriter writer)
		{
			string endElementName;

			if (reader.NodeType == XmlNodeType.EndElement)
				endElementName = reader.Name;
			else if (!ReadEndElement(reader, writer, out endElementName))
				return false;
			if (String.Compare("grammar", endElementName, true) != 0)
				return false;
			writer.WriteEndElement();
			return true;
		}

		private bool ParseRules(XmlReader reader, XmlWriter writer, out List<string> topLevelRules)
		{
			topLevelRules = new List<string>(10);
			while (ReadElement(reader, writer, "RULE"))
			{
				if (!ParseRule(topLevelRules, reader, writer))
					return false;
			}

			return (topLevelRules.Count > 0);
		}

		private bool ParseRule(List<string> topLevelRules, XmlReader reader, XmlWriter writer)
		{
			string startElementName;
			string endElementName;
			string elementName;
			string ruleId;
			bool dynamic;
			bool topLevel;

			ruleId = null;
			dynamic = true;
			topLevel = false;
			startElementName = reader.Name;
			while (reader.MoveToNextAttribute())
			{
				switch (reader.Name.ToLower())
				{
					case "name":
						ruleId = reader.Value;
						break;

					case "toplevel":
						topLevel = (String.Compare(reader.Value, "active", true) == 0);
						break;

					case "dynamic":
						if (!Boolean.TryParse(reader.Value, out dynamic))
							dynamic = false;
						break;
				}
			}

			if (ruleId == null)
				return false;

			writer.WriteStartElement("rule");
			writer.WriteAttributeString("id", ruleId);
			writer.WriteAttributeString("scope", topLevel ? "public" : "private");

			while (ReadElement(reader, writer, out elementName))
			{
				if (!ParseElement(elementName, reader, writer))
					return false;
			}

			if (!SkipSpacesAndComments(reader, writer))
				return false;

			if (reader.NodeType == XmlNodeType.EndElement)
				endElementName = reader.Name;
			else if (!ReadEndElement(reader, writer, out endElementName))
				return false;
			if (String.Compare(startElementName, endElementName, true) != 0)
				return false;

			//if (!ReadEndElement(reader, writer, out endElementName) ||
			//	(String.Compare(startElementName, endElementName, true) != 0))
			//	return false;
			writer.WriteEndElement();
			if (topLevel)
				topLevelRules.Add(ruleId);

			return true;
		}

		private bool ParseElement(string elementName, XmlReader reader, XmlWriter writer)
		{
			if (reader.NodeType != XmlNodeType.Element)
				return false;
			switch (elementName)
			{
				case "list":
					return ParseList(reader, writer);

				case "o":
				case "opt":
					return ParseOptionalElement(reader, writer);

				case "p":
				case "phrase":
					return ParsePhrase(reader, writer);

				case "ruleref":
					//return ParseRuleReference(reader, writer);
					return ParseRuleReference(reader, writer);
			}
			return false;
		}

		private bool ParseList(XmlReader reader, XmlWriter writer)
		{
			string startElementName;
			string endElementName;
			string elementName;
			int count;

			startElementName = reader.Name;
			writer.WriteStartElement("one-of");
			count = 0;
			while (ReadElement(reader, writer, out elementName))
			{
				++count;
				switch (elementName)
				{
					case "list":
						return false;

					case "o":
					case "opt":
						return false;

					case "p":
					case "phrase":
						if (!ParsePhrase(reader, writer))
							return false;
						break;

					case "ruleref":
						writer.WriteStartElement("item");
						if (!ParseRuleReference(reader, writer))
							return false;
						writer.WriteEndElement();
						break;

					default:
						return false;
				}
			}

			if (reader.NodeType == XmlNodeType.EndElement)
				endElementName = reader.Name;
			else if (!ReadEndElement(reader, writer, out endElementName))
				return false;
			if (String.Compare(startElementName, endElementName, true) != 0)
				return false;
			writer.WriteEndElement();
			return (count > 0);
		}

		private bool ParseOptionalElement(XmlReader reader, XmlWriter writer)
		{
			string startElementName;
			string elementName;
			string endElementName;

			startElementName = reader.Name;
			writer.WriteStartElement("item");
			writer.WriteAttributeString("repeat", "0-1");
			if (!ReadElement(reader, writer, out elementName) ||
				!ParseElement(elementName, reader, writer) ||
				!ReadEndElement(reader, writer, out endElementName) ||
				(String.Compare(startElementName, endElementName, true) != 0))
				return false;
			writer.WriteEndElement();
			return true;
		}

		private bool ParsePhrase(XmlReader reader, XmlWriter writer)
		{
			string value;
			string startElementName;
			string endElementName;

			startElementName = reader.Name;
			if (!ReadElementText(reader, writer, out value) ||
				!ReadEndElement(reader, writer, out endElementName) ||
				String.IsNullOrEmpty(value) ||
				(String.Compare(startElementName, endElementName, true) != 0))
				return false;
			writer.WriteElementString("item", value);
			return true;
		}

		private bool ParseRuleReference(XmlReader reader, XmlWriter writer)
		{
			string ruleId;

			if (!ReadAttribute(reader, "name", out ruleId) ||
				String.IsNullOrEmpty(ruleId))
				return false;
			writer.WriteStartElement("ruleref");
			writer.WriteAttributeString("uri", "#" + ruleId);
			writer.WriteEndElement();
			return true;
		}
	}
}
