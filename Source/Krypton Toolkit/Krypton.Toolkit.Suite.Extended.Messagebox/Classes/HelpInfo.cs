#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Messagebox;

public class HelpInfo
{
    #region Instance Fields

    #endregion

    #region Identity

    /// <summary>
    /// Initialize a new instance of the HelpInfo class.
    /// </summary>
    /// <param name="helpFilePath">Value for HelpFilePath.</param>
    /// <param name="keyword">Value for Keyword</param>
    public HelpInfo(string? helpFilePath = null, string? keyword = null)
        : this(helpFilePath, keyword, !string.IsNullOrWhiteSpace(keyword) ? HelpNavigator.Topic : HelpNavigator.TableOfContents, null)
    {

    }

    /// <summary>
    /// Initialize a new instance of the HelpInfo class.
    /// </summary>
    /// <param name="helpFilePath">Value for HelpFilePath.</param>
    /// <param name="navigator">Value for Navigator</param>
    /// <param name="param"></param>
    public HelpInfo(string helpFilePath, HelpNavigator navigator, object? param = null)
        : this(helpFilePath, null, navigator, param)
    {

    }

    /// <summary>
    /// Initialize a new instance of the HelpInfo class.
    /// </summary>
    /// <param name="helpFilePath">Value for HelpFilePath.</param>
    /// <param name="navigator">Value for Navigator</param>
    /// <param name="keyword">Value for Keyword</param>
    /// <param name="param"></param>
    private HelpInfo(string? helpFilePath, string? keyword, HelpNavigator navigator, object? param)
    {
        HelpFilePath = helpFilePath ?? string.Empty;
        Keyword = keyword ?? string.Empty;
        Navigator = navigator;
        Param = param ?? string.Empty;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the HelpFilePath property.
    /// </summary>
    public string HelpFilePath { get; }

    /// <summary>
    /// Gets the Keyword property.
    /// </summary>
    public string Keyword { get; }

    /// <summary>
    /// Gets the Navigator property.
    /// </summary>
    public HelpNavigator Navigator { get; }

    /// <summary>
    /// Gets the Param property.
    /// </summary>
    public object Param { get; }

    #endregion
}