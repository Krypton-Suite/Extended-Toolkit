#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
            List<char> availableDriveLetters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                availableDriveLetters.Remove((drives[i].Name).ToLower()[0]);
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
                List<char> temp = new List<char>();

                temp.Add(driveLetter);

                driveArray = temp.ToArray();
            }
        }
        #endregion
    }
}