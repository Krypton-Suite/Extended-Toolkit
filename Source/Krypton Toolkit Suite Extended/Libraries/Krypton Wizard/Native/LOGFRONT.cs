#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        public enum LogFontCharSet : byte
        {
            ANSI_CHARSET = 0,
            DEFAULT_CHARSET = 1,
            SYMBOL_CHARSET = 2,
            SHIFTJIS_CHARSET = 128,
            HANGEUL_CHARSET = 129,
            HANGUL_CHARSET = 129,
            GB2312_CHARSET = 134,
            CHINESEBIG5_CHARSET = 136,
            OEM_CHARSET = 255,
            JOHAB_CHARSET = 130,
            HEBREW_CHARSET = 177,
            ARABIC_CHARSET = 178,
            GREEK_CHARSET = 161,
            TURKISH_CHARSET = 162,
            VIETNAMESE_CHARSET = 163,
            THAI_CHARSET = 222,
            EASTEUROPE_CHARSET = 238,
            RUSSIAN_CHARSET = 204,
            MAC_CHARSET = 77,
            BALTIC_CHARSET = 186
        }

        public enum LogFontClippingPrecision : byte
        {
            CLIP_DEFAULT_PRECIS = 0,
            CLIP_CHARACTER_PRECIS = 1,
            CLIP_STROKE_PRECIS = 2,
            CLIP_MASK = 0xf,
            CLIP_LH_ANGLES = 1 << 4,
            CLIP_TT_ALWAYS = 2 << 4,
            CLIP_DFA_DISABLE = 4 << 4,
            CLIP_EMBEDDED = 8 << 4
        }

        public enum LogFontFontFamily : byte
        {
            FF_DONTCARE = 0 << 4,
            FF_ROMAN = 1 << 4,
            FF_SWISS = 2 << 4,
            FF_MODERN = 3 << 4,
            FF_SCRIPT = 4 << 4,
            FF_DECORATIVE = 5 << 4,
        }

        public enum LogFontOutputPrecision : byte
        {
            OUT_DEFAULT_PRECIS = 0,
            OUT_STRING_PRECIS = 1,
            OUT_CHARACTER_PRECIS = 2,
            OUT_STROKE_PRECIS = 3,
            OUT_TT_PRECIS = 4,
            OUT_DEVICE_PRECIS = 5,
            OUT_RASTER_PRECIS = 6,
            OUT_TT_ONLY_PRECIS = 7,
            OUT_OUTLINE_PRECIS = 8,
            OUT_SCREEN_OUTLINE_PRECIS = 9,
            OUT_PS_ONLY_PRECIS = 10
        }
        public enum LogFontOutputQuality : byte
        {
            DEFAULT_QUALITY = 0,
            DRAFT_QUALITY = 1,
            PROOF_QUALITY = 2,
            NONANTIALIASED_QUALITY = 3,
            ANTIALIASED_QUALITY = 4,
            CLEARTYPE_QUALITY = 5,
            CLEARTYPE_NATURAL_QUALITY = 6
        }

        public enum LogFontPitch : byte
        {
            DEFAULT_PITCH = 0,
            FIXED_PITCH = 1,
            VARIABLE_PITCH = 2
        }
        /// <summary>The LOGFONT structure defines the attributes of a font.</summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LOGFONT
        {
            /// <summary>
            /// The height, in logical units, of the font's character cell or character. The character height value (also known as the em height) is the
            /// character cell height value minus the internal-leading value. The font mapper interprets the value specified in lfHeight in the following manner.
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <definition>Meaning</definition>
            /// </listheader>
            /// <item>
            /// <term>&gt; 0</term>
            /// <definition>The font mapper transforms this value into device units and matches it against the cell height of the available fonts.</definition>
            /// </item>
            /// <item>
            /// <term>0</term>
            /// <definition></definition> The font mapper uses a default height value when it searches for a match.
            /// </item>
            /// <item>
            /// <term>&lt; 0</term>
            /// <definition>The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.</definition>
            /// </item>
            /// </list>
            /// <para>For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.</para>
            /// <para>This mapping occurs when the font is used for the first time.</para>
            /// <para>For the MM_TEXT mapping mode, you can use the following formula to specify a height for a font with a specified point size:</para>
            /// </summary>
            public int lfHeight;

            /// <summary>
            /// The average width, in logical units, of characters in the font. If lfWidth is zero, the aspect ratio of the device is matched against the
            /// digitization aspect ratio of the available fonts to find the closest match, determined by the absolute value of the difference.
            /// </summary>
            public int lfWidth;

            /// <summary>
            /// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device. The escapement vector is parallel to the base line
            /// of a row of text.
            /// <para>
            /// When the graphics mode is set to GM_ADVANCED, you can specify the escapement angle of the string independently of the orientation angle of the
            /// string's characters.
            /// </para>
            /// <para>
            /// When the graphics mode is set to GM_COMPATIBLE, lfEscapement specifies both the escapement and orientation. You should set lfEscapement and
            /// lfOrientation to the same value.
            /// </para>
            /// </summary>
            public int lfEscapement;

            /// <summary>The angle, in tenths of degrees, between each character's base line and the x-axis of the device.</summary>
            public int lfOrientation;

            /// <summary>
            /// The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold. If this value is zero, a default weight is used.
            /// </summary>
            public int lfWeight;

            /// <summary>An italic font if set to TRUE.</summary>
            public byte lfItalic;

            /// <summary>An underlined font if set to TRUE.</summary>
            public byte lfUnderline;

            /// <summary>A strikeout font if set to TRUE.</summary>
            public byte lfStrikeOut;

            /// <summary>The character set.</summary>
            public LogFontCharSet lfCharSet;

            /// <summary>
            /// The output precision. The output precision defines how closely the output must match the requested font's height, width, character orientation,
            /// escapement, pitch, and font type.
            /// </summary>
            public LogFontOutputPrecision lfOutPrecision;

            /// <summary>The clipping precision. The clipping precision defines how to clip characters that are partially outside the clipping region.</summary>
            public LogFontClippingPrecision lfClipPrecision;

            /// <summary>
            /// The output quality. The output quality defines how carefully the graphics device interface (GDI) must attempt to match the logical-font
            /// attributes to those of an actual physical font.
            /// </summary>
            public LogFontOutputQuality lfQuality;

            /// <summary>The pitch and family of the font.</summary>
            public byte lfPitchAndFamily;

            /// <summary>
            /// A null-terminated string that specifies the typeface name of the font. The length of this string must not exceed 32 TCHAR values, including the
            /// terminating NULL. The EnumFontFamiliesEx function can be used to enumerate the typeface names of all currently available fonts. If lfFaceName is
            /// an empty string, GDI uses the first font that matches the other specified attributes.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;

            public bool Italic
            {
                get { return lfItalic == 1; }
                set { lfItalic = System.Convert.ToByte(value); }
            }

            public bool Underline
            {
                get { return lfUnderline == 1; }
                set { lfUnderline = System.Convert.ToByte(value); }
            }

            public bool StrikeOut
            {
                get { return lfStrikeOut == 1; }
                set { lfStrikeOut = System.Convert.ToByte(value); }
            }

            public LogFontPitch Pitch
            {
                get { return (LogFontPitch)(lfPitchAndFamily & 0x0F); }
                set { lfPitchAndFamily = (byte)((lfPitchAndFamily & 0xF0) | (byte)value); }
            }

            public LogFontFontFamily FontFamily
            {
                get { return (LogFontFontFamily)(lfPitchAndFamily & 0xF0); }
                set { lfPitchAndFamily = (byte)((lfPitchAndFamily & 0x0F) | (byte)value); }
            }

            public static LOGFONT FromFont(Font font)
            {
                if (font == null)
                    throw new System.ArgumentNullException(nameof(font));
                var lf = default(LOGFONT);
                font.ToLogFont(lf);
                return lf;
            }

            public Font ToFont()
            {
                try
                {
                    return Font.FromLogFont(this);
                }
                catch
                {
                    return new Font(lfFaceName, lfHeight, FontStyle.Regular, GraphicsUnit.Display);
                }
            }

            public override string ToString() => $"lfHeight={lfHeight}, lfWidth={lfWidth}, lfEscapement={lfEscapement}, lfOrientation={lfOrientation}, lfWeight={lfWeight}, lfItalic={lfItalic}, lfUnderline={lfUnderline}, lfStrikeOut={lfStrikeOut}, lfCharSet={lfCharSet}, lfOutPrecision={lfOutPrecision}, lfClipPrecision={lfClipPrecision}, lfQuality={lfQuality}, lfPitchAndFamily={lfPitchAndFamily}, lfFaceName={lfFaceName}";
        }
    }
}