﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Exports colored text as RTF
    /// </summary>
    /// <remarks>At this time only TextStyle renderer is supported. Other styles are not exported.</remarks>
    public class ExportToRTF
    {
        /// <summary>
        /// Includes line numbers
        /// </summary>
        public bool IncludeLineNumbers { get; set; }
        /// <summary>
        /// Use original font
        /// </summary>
        public bool UseOriginalFont { get; set; }

        FastColouredTextBox tb;
        Dictionary<Color, int> colourTable = new Dictionary<Color, int>();

        public ExportToRTF()
        {
            UseOriginalFont = true;
        }

        public string GetRtf(FastColouredTextBox tb)
        {
            this.tb = tb;
            Range sel = new Range(tb);
            sel.SelectAll();
            return GetRtf(sel);
        }

        public string GetRtf(Range r)
        {
            this.tb = r.tb;
            var styles = new Dictionary<StyleIndex, object>();
            var sb = new StringBuilder();
            var tempSB = new StringBuilder();
            var currentStyleId = StyleIndex.None;
            r.Normalize();
            int currentLine = r.Start.iLine;
            styles[currentStyleId] = null;
            colourTable.Clear();
            //
            var lineNumberColour = GetColourTableNumber(r.tb.LineNumberColour);

            if (IncludeLineNumbers)
                tempSB.AppendFormat(@"{{\cf{1} {0}}}\tab", currentLine + 1, lineNumberColour);
            //
            foreach (Place p in r)
            {
                Char c = r.tb[p.iLine][p.iChar];
                if (c.style != currentStyleId)
                {
                    Flush(sb, tempSB, currentStyleId);
                    currentStyleId = c.style;
                    styles[currentStyleId] = null;
                }

                if (p.iLine != currentLine)
                {
                    for (int i = currentLine; i < p.iLine; i++)
                    {
                        tempSB.AppendLine(@"\line");
                        if (IncludeLineNumbers)
                            tempSB.AppendFormat(@"{{\cf{1} {0}}}\tab", i + 2, lineNumberColour);
                    }
                    currentLine = p.iLine;
                }
                switch (c.c)
                {
                    case '\\':
                        tempSB.Append(@"\\");
                        break;
                    case '{':
                        tempSB.Append(@"\{");
                        break;
                    case '}':
                        tempSB.Append(@"\}");
                        break;
                    default:
                        var ch = c.c;
                        var code = (int)ch;
                        if (code < 128)
                            tempSB.Append(c.c);
                        else
                            tempSB.AppendFormat(@"{{\u{0}}}", code);
                        break;
                }
            }
            Flush(sb, tempSB, currentStyleId);

            //build color table
            var list = new SortedList<int, Color>();
            foreach (var pair in colourTable)
                list.Add(pair.Value, pair.Key);

            tempSB.Length = 0;
            tempSB.AppendFormat(@"{{\colortbl;");

            foreach (var pair in list)
                tempSB.Append(GetColourAsString(pair.Value) + ";");
            tempSB.AppendLine("}");

            //
            if (UseOriginalFont)
            {
                sb.Insert(0, string.Format(@"{{\fonttbl{{\f0\fmodern {0};}}}}{{\fs{1} ",
                                tb.Font.Name, (int)(2 * tb.Font.SizeInPoints), tb.CharHeight));
                sb.AppendLine(@"}");
            }

            sb.Insert(0, tempSB.ToString());

            sb.Insert(0, @"{\rtf1\ud\deff0");
            sb.AppendLine(@"}");

            return sb.ToString();
        }

        private RTFStyleDescriptor GetRtfDescriptor(StyleIndex styleIndex)
        {
            List<Style> styles = new List<Style>();
            //find text renderer
            TextStyle textStyle = null;
            int mask = 1;
            bool hasTextStyle = false;
            for (int i = 0; i < tb.Styles.Length; i++)
            {
                if (tb.Styles[i] != null && ((int)styleIndex & mask) != 0)
                    if (tb.Styles[i].IsExportable)
                    {
                        var style = tb.Styles[i];
                        styles.Add(style);

                        bool isTextStyle = style is TextStyle;
                        if (isTextStyle)
                            if (!hasTextStyle || tb.AllowSeveralTextStyleDrawing)
                            {
                                hasTextStyle = true;
                                textStyle = style as TextStyle;
                            }
                    }
                mask = mask << 1;
            }
            //add TextStyle css
            RTFStyleDescriptor result = null;

            if (!hasTextStyle)
            {
                //draw by default renderer
                result = tb.DefaultStyle.GetRTF();
            }
            else
            {
                result = textStyle.GetRTF();
            }

            return result;
        }

        public static string GetColourAsString(Color colour)
        {
            if (colour == Color.Transparent)
                return "";
            return string.Format(@"\red{0}\green{1}\blue{2}", colour.R, colour.G, colour.B);
        }

        private void Flush(StringBuilder sb, StringBuilder tempSB, StyleIndex currentStyle)
        {
            //find textRenderer
            if (tempSB.Length == 0)
                return;

            var desc = GetRtfDescriptor(currentStyle);
            var cf = GetColourTableNumber(desc.ForeColour);
            var cb = GetColourTableNumber(desc.BackColour);
            var tags = new StringBuilder();
            if (cf >= 0)
                tags.AppendFormat(@"\cf{0}", cf);
            if (cb >= 0)
                tags.AppendFormat(@"\highlight{0}", cb);
            if (!string.IsNullOrEmpty(desc.AdditionalTags))
                tags.Append(desc.AdditionalTags.Trim());

            if (tags.Length > 0)
                sb.AppendFormat(@"{{{0} {1}}}", tags, tempSB.ToString());
            else
                sb.Append(tempSB.ToString());
            tempSB.Length = 0;
        }

        private int GetColourTableNumber(Color colour)
        {
            if (colour.A == 0)
                return -1;

            if (!colourTable.ContainsKey(colour))
                colourTable[colour] = colourTable.Count + 1;

            return colourTable[colour];
        }
    }
}