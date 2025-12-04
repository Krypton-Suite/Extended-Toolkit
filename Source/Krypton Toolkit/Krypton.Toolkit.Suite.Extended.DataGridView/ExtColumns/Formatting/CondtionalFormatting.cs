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

namespace Krypton.Toolkit.Suite.Extended.DataGridView;

/// <summary>
/// Conditional Formatting class
/// </summary>
public class ConditionalFormatting
{
    /// <summary>
    /// Gets or sets the name of the column.
    /// </summary>
    /// <value>
    /// The name of the column.
    /// </value>
    public string ColumnName { get; set; }
    /// <summary>
    /// Gets or sets the type of the Conditional Formatting.
    /// </summary>
    /// <value>
    /// The type of the Conditional Formatting.
    /// </value>
    public EnumConditionalFormatType FormatType { get; set; }
    /// <summary>
    /// Gets or sets the Conditional Formatting parameters.
    /// </summary>
    /// <value>
    /// The Conditional Formatting parameters.
    /// </value>
    public IFormatParams FormatParams { get; set; }
    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    /// <value>
    /// The minimum value.
    /// </value>
    public double minValue { get; set; }
    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    /// <value>
    /// The maximum value.
    /// </value>
    public double maxValue { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class.
    /// </summary>
    public ConditionalFormatting() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class. (Only use for context menu !)
    /// </summary>
    /// <param name="formatType">Type of the Conditional Formatting.</param>
    /// <param name="formatParams">The Conditional Formatting parameters.</param>
    public ConditionalFormatting(EnumConditionalFormatType formatType, IFormatParams formatParams)
    {
        FormatType = formatType;
        FormatParams = formatParams;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class.
    /// </summary>
    /// <param name="columnName">Name of the column.</param>
    /// <param name="formatType">Type of the Conditional Formatting.</param>
    /// <param name="formatParams">The Conditional Formatting parameters.</param>
    public ConditionalFormatting(string columnName, EnumConditionalFormatType formatType, IFormatParams formatParams)
    {
        ColumnName = columnName;
        FormatType = formatType;
        FormatParams = formatParams;
    }

    internal void Persist(XmlWriter writer)
    {
        writer.WriteStartElement("Condition");
        writer.WriteElementString("ColumnName", ColumnName);
        writer.WriteElementString("FormatType", FormatType.ToString());
        writer.WriteStartElement("FormatParams");
        FormatParams.Persist(writer);
        writer.WriteEndElement(); //FormatParams
        //No need to persist min/max Value.
        writer.WriteEndElement(); //Condition
    }
}