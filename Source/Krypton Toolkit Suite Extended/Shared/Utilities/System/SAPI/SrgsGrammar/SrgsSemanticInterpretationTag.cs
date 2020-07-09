using System.Diagnostics;
using System.Speech.Internal;
using System.Speech.Internal.SrgsParser;
using System.Text;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
	[Serializable]
	[DebuggerDisplay("{DebuggerDisplayString ()}")]
	public class SrgsSemanticInterpretationTag : SrgsElement, ISemanticTag, IElement
	{
		private string _script = string.Empty;

		public string Script
		{
			get
			{
				return _script;
			}
			set
			{
				Helpers.ThrowIfNull(value, "value");
				_script = value;
			}
		}

		public SrgsSemanticInterpretationTag()
		{
		}

		public SrgsSemanticInterpretationTag(string script)
		{
			Helpers.ThrowIfNull(script, "script");
			_script = script;
		}

		internal override void Validate(SrgsGrammar grammar)
		{
			if (grammar.TagFormat == SrgsTagFormat.Default)
			{
				grammar.TagFormat |= SrgsTagFormat.W3cV1;
			}
			else if (grammar.TagFormat == SrgsTagFormat.KeyValuePairs)
			{
				XmlParser.ThrowSrgsException(SRID.SapiPropertiesAndSemantics);
			}
		}

		internal override void WriteSrgs(XmlWriter writer)
		{
			string text = Script.Trim(Helpers._achTrimChars);
			writer.WriteStartElement("tag");
			if (!string.IsNullOrEmpty(text))
			{
				writer.WriteString(text);
			}
			writer.WriteEndElement();
		}

		internal override string DebuggerDisplayString()
		{
			StringBuilder stringBuilder = new StringBuilder("SrgsSemanticInterpretationTag '");
			stringBuilder.Append(_script);
			stringBuilder.Append("'");
			return stringBuilder.ToString();
		}

		void ISemanticTag.Content(IElement parent, string value, int line)
		{
			Script = value;
		}
	}
}
