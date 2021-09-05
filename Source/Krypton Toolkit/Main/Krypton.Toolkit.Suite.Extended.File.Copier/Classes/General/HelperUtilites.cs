﻿using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    internal static class HelperUtilites
    {
        #region Variables

        #endregion

        #region Properties

        #endregion

        #region Methods
        public static List<string> PopulateDirectoryListing(string inputPath)
        {
            List<string> tempList = new List<string>();

            foreach (string directory in Directory.GetDirectories(inputPath))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    tempList.Add(file);
                }
            }

            return tempList;
        }

        public static string[] ReturnDirectoryListing(List<string> inputList)
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
                ExceptionCapture.CaptureException(exc);

                return null;
            }

            return inputList.ToArray();
        }
        #endregion
    }
}