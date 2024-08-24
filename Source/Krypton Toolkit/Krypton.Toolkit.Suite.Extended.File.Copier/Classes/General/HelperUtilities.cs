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

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    internal static class HelperUtilities
    {
        #region Variables

        #endregion

        #region Properties

        #endregion

        #region Methods
        public static List<string> PopulateDirectoryListing(string inputPath)
        {
            List<string> tempList = new();

            foreach (string directory in Directory.GetDirectories(inputPath))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    tempList.Add(file);
                }
            }

            return tempList;
        }

        public static string[]? ReturnDirectoryListing(List<string> inputList)
        {
            try
            {
                if (inputList.Count > 0)
                {
                    return inputList.ToArray();
                }
            }
            catch (Exception exc)
            {
                DebugUtilities.NotImplemented(exc.ToString());

                return null;
            }

            return inputList.ToArray();
        }
        #endregion
    }
}