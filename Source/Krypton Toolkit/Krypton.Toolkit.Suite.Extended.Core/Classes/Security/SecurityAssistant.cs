#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core;

public class SecurityAssistant
{
    #region Variables
    private string[] _supportedHashAlgorithims = ["MD-5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "RIPEMD-160"];

    private StringCollection? _supportedHashAlgorithimCollection = null;
    #endregion

    #region Constructor
    public SecurityAssistant()
    {

    }
    #endregion

    #region Methods
    /// <summary>Returns the supported hash algorithims.</summary>
    /// <returns></returns>
    public string[] ReturnSupportedHashAlgorithims() => _supportedHashAlgorithims;

    public void PropagateSupportedHashAlgorithimCollection()
    {
        _supportedHashAlgorithimCollection = new();

        foreach (string item in ReturnSupportedHashAlgorithims())
        {
            _supportedHashAlgorithimCollection.Add(item);
        }
    }

    public StringCollection ReturnSupportedHashAlgorithimCollection() => _supportedHashAlgorithimCollection;
    #endregion
}