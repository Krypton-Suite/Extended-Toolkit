using System;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class OSHelper
    {
        public OSHelper()
        {

        }

        /// <summary>Determines whether [is seven or higher].</summary>
        /// <returns>
        ///   <c>true</c> if [is seven or higher]; otherwise, <c>false</c>.</returns>
        public static bool IsSevenOrHigher()
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}