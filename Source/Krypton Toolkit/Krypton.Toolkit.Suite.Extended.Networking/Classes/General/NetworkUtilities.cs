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

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class NetworkUtilities
    {

        #region Methods
        /// <summary>Code from: https://stackoverflow.com/questions/30317761/populate-list-of-drives-available-for-mapping</summary>
        public char[] GetAvailableDriveLetters()
        {
            List<char> availableDriveLetters =
            [
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            ];

            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                availableDriveLetters.Remove(drives[i].Name.ToLower()[0]);
            }

            return availableDriveLetters.ToArray();
        }

        /// <summary>Gets a list of the available drive letters. Code from: https://hardforum.com/threads/c-getting-free-drive-letters.1208456/.</summary>
        /// <param name="driveArray">The drive array.</param>
        public void GetAvailableDriveLetters(char[] driveArray)
        {
            // Allocate space for alphabet
            ArrayList driveLetters = new ArrayList(26);

            // increment from ASCII values for A-Z
            for (int i = 65; i < 91; i++)
            {
                // Add uppercase letters to possible drive letters
                driveLetters.Add(Convert.ToChar(i));
            }

            foreach (var drive in Directory.GetLogicalDrives())
            {
                // removed used drive letters from possible drive letters
                driveLetters.Remove(drive[0]);
            }

            foreach (char driveLetter in driveLetters)
            {
                // add unused drive letters to the array
                List<char> temp =
                [
                    driveLetter
                ];

                driveArray = temp.ToArray();
            }
        }
        #endregion
    }
}