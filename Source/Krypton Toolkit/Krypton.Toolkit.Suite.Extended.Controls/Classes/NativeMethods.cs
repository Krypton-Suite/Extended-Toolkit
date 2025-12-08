#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls;

internal class NativeMethods
{
    #region Constants

    internal const int WM_NCHITTEST = 0x0084;
    internal const int WM_NCACTIVATE = 0x0086;
    internal const int WS_EX_NOACTIVATE = 0x08000000;
    internal const int HTTRANSPARENT = -1;
    internal const int HTLEFT = 10;
    internal const int HTRIGHT = 11;
    internal const int HTTOP = 12;
    internal const int HTTOPLEFT = 13;
    internal const int HTTOPRIGHT = 14;
    internal const int HTBOTTOM = 15;
    internal const int HTBOTTOMLEFT = 16;
    internal const int HTBOTTOMRIGHT = 17;
    internal const int WM_USER = 0x0400;
    internal const int WM_REFLECT = WM_USER + 0x1C00;
    internal const int WM_COMMAND = 0x0111;
    internal const int CBN_DROPDOWN = 7;
    internal const int WM_GETMINMAXINFO = 0x0024;

    #endregion

    #region Parameters

    /* Sent when the system makes a request to paint (a portion of) a window. */
    public const int WM_PAINT = 0xf;

    /* Sent to a window to request that it draw its client area in the
    specified device context, most commonly in a printer device context. */
    public const int WM_PRINTCLIENT = 0x318;

    /* Paints all descendants of a window in bottom-to-top painting order using double-buffering. */
    public const int WS_EX_COMPOSITED = 0x2000000;

    #endregion

    #region Structures

    /* Contains information to be used to paint the client area of a window. */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PAINTSTRUCT
    {
        /* A handle to the display DC to use for painting. */
        public IntPtr hdc;

        /* Indicates whether the background should be erased. */
        public bool fErase;

        /* A RECT structure that specifies the upper left and lower right
        corners of the rectangle in which the painting is requested, */
        public RECT rcPaint;

        /* Reserved; used internally by the system. */
        public bool fRestore;

        /* Reserved; used internally by the system. */
        public bool fIncUpdate;
    }

    /* Defines the coordinates of the upper-left and lower-right corners of a rectangle. */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RECT
    {
        /* The x-coordinate of the upper-left corner of the rectangle. */
        public int Left;

        /* The y-coordinate of the upper-left corner of the rectangle. */
        public int Top;

        /* The x-coordinate of the lower-right corner of the rectangle. */
        public int Right;

        /* The y-coordinate of the lower-right corner of the rectangle. */
        public int Bottom;
    }

    /*  Contains basic information about a physical font. This is the Unicode version of the structure. */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TEXTMETRIC
    {
        /* The height (ascent + descent) of characters. */
        public int tmHeight;

        /* The ascent (units above the base line) of characters. */
        public int tmAscent;

        /* The descent (units below the base line) of characters. */
        public int tmDescent;

        /* The amount of leading (space) inside the bounds set by the tmHeight member. */
        public int tmInternalLeading;

        /* The amount of extra leading (space) that the application adds between rows. */
        public int tmExternalLeading;

        /* The average width of characters in the font (generally defined as the width of the letter x). */
        public int tmAveCharWidth;

        /* The width of the widest character in the font. */
        public int tmMaxCharWidth;

        /* The weight of the font. */
        public int tmWeight;

        /* The extra width per string that may be added to some synthesized fonts. */
        public int tmOverhang;

        /* The horizontal aspect of the device for which the font was designed. */
        public int tmDigitizedAspectX;

        /* The vertical aspect of the device for which the font was designed. */
        public int tmDigitizedAspectY;

        /* The value of the first character defined in the font. */
        public char tmFirstChar;

        /* The value of the last character defined in the font. */
        public char tmLastChar;

        /* The value of the character to be substituted for characters not in the font. */
        public char tmDefaultChar;

        /* The value of the character that will be used to define word breaks for text justification. */
        public char tmBreakChar;

        /* Specifies an italic font if it is nonzero. */
        public byte tmItalic;

        /* Specifies an underlined font if it is nonzero. */
        public byte tmUnderlined;

        /* A strikeout font if it is nonzero. */
        public byte tmStruckOut;

        /* Specifies information about the pitch, the technology, and the family of a physical font. */
        public byte tmPitchAndFamily;

        /* The character set of the font. */
        public byte tmCharSet;
    }

    /* Contains basic information about a physical font. This is the ANSI version of the structure. */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TEXTMETRICA
    {
        /* The height (ascent + descent) of characters. */
        public int tmHeight;

        /* The ascent (units above the base line) of characters. */
        public int tmAscent;

        /* The descent (units below the base line) of characters. */
        public int tmDescent;

        /* The amount of leading (space) inside the bounds set by the tmHeight member. */
        public int tmInternalLeading;

        /* The amount of extra leading (space) that the application adds between rows. */
        public int tmExternalLeading;

        /* The average width of characters in the font (generally defined as the width of the letter x). */
        public int tmAveCharWidth;

        /* The width of the widest character in the font. */
        public int tmMaxCharWidth;

        /* The weight of the font. */
        public int tmWeight;

        /* The extra width per string that may be added to some synthesized fonts. */
        public int tmOverhang;

        /* The horizontal aspect of the device for which the font was designed. */
        public int tmDigitizedAspectX;

        /* The vertical aspect of the device for which the font was designed. */
        public int tmDigitizedAspectY;

        /* The value of the first character defined in the font. */
        public byte tmFirstChar;

        /* The value of the last character defined in the font. */
        public byte tmLastChar;

        /* The value of the character to be substituted for characters not in the font. */
        public byte tmDefaultChar;

        /* The value of the character that will be used to define word breaks for text justification. */
        public byte tmBreakChar;

        /* Specifies an italic font if it is nonzero. */
        public byte tmItalic;

        /* Specifies an underlined font if it is nonzero. */
        public byte tmUnderlined;

        /* A strikeout font if it is nonzero. */
        public byte tmStruckOut;

        /* Specifies information about the pitch, the technology, and the family of a physical font. */
        public byte tmPitchAndFamily;

        /* The character set of the font. */
        public byte tmCharSet;
    }

    internal struct CHARRANGE
    {
        public int cpMin;

        public int cpMax;
    }

    internal struct FORMATRANGE
    {
        public IntPtr hdc;

        public IntPtr hdcTarget;

        public KryptonRichTextBoxExtendedRECT rc;

        public KryptonRichTextBoxExtendedRECT rcPage;

        public CHARRANGE chrg;
    }

    internal struct PARAFORMAT
    {
        public int cbSize;

        public uint dwMask;

        public short wNumbering;

        public short wReserved;

        public int dxStartIndent;

        public int dxRightIndent;

        public int dxOffset;

        public short wAlignment;

        public short cTabCount;

        public int[] rgxTabs;

        public int dySpaceBefore;

        public int dySpaceAfter;

        public int dyLineSpacing;

        public short sStyle;

        public byte bLineSpacingRule;

        public byte bOutlineLevel;

        public short wShadingWeight;

        public short wShadingStyle;

        public short wNumberingStart;

        public short wNumberingStyle;

        public short wNumberingTab;

        public short wBorderSpace;

        public short wBorderWidth;

        public short wBorders;
    }

    internal struct KryptonRichTextBoxExtendedRECT
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MINMAXINFO
    {
        public Point Reserved;
        public Size MaximumSize;
        public Point MaximumPosition;
        public Size MinimumTrackSize;
        public Size MaximumTrackSize;
    }

    #endregion

    #region Implementation

    internal static int HIWORD(int n)
    {
        return (n >> 16) & 0xffff;
    }

    internal static int HIWORD(IntPtr n)
    {
        return HIWORD(unchecked((int)(long)n));
    }

    internal static int LOWORD(int n)
    {
        return n & 0xffff;
    }

    internal static int LOWORD(IntPtr n)
    {
        return LOWORD(unchecked((int)(long)n));
    }

    #endregion
}