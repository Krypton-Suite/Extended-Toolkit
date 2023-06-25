#region License

/*
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
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
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>Enum representing the effect of Mandatory flag.</summary>
    public enum UpdateMode
    {
        /// <summary>In this mode, it ignores Remind Later and Skip values set previously and hide both buttons.</summary>
        [XmlEnum("0")] Normal,

        /// <summary>In this mode, it won't show close button in addition to Normal mode behaviour.</summary>
        [XmlEnum("1")] Forced,

        /// <summary>In this mode, it will start downloading and applying update without showing standard update dialog in addition to Forced mode behaviour.</summary>
        [XmlEnum("2")] ForcedDownload
    }
}