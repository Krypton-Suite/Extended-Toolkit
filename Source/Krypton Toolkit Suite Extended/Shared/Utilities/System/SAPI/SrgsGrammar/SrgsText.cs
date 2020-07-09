using System.Diagnostics;
using System.Speech.Internal;
using System.Speech.Internal.SrgsParser;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
	[Serializable]
	[DebuggerDisplay("{DebuggerDisplayString ()}")]
	public class SrgsText : SrgsElement, IElementText, IElement
	{
		private string _text = string.Empty;

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				Helpers.ThrowIfNull(value, "value");
				XmlParser.ParseText(null, value, null, null, -1f, null);
				_text = value;
			}
		}

		public SrgsText()
		{
		}

		public SrgsText(string text)
		{
			Helpers.ThrowIfNull(text, "text");
			Text = text;
		}

		internal override void WriteSrgs(XmlWriter writer)
		{
			if (_text != null && _text.Length > 0)
			{
				writer.WriteString(_text);
			}
		}

		internal override string DebuggerDisplayString()
		{
			return "'" + _text + "'";
		}
	}
}
