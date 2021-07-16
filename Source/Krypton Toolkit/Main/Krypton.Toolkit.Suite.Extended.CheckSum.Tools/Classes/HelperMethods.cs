namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class HelperMethods
    {
        #region Variables
        private string[] _hashTypes = new string[] { "MD-5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "RIPEMD-160" }, _safeNETCoreAndNewerHashTypes = new string[] { "MD-5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
        #endregion

        #region Properties
        public string[] HashTypes { get => _hashTypes; }

        public string[] SafeNetCoreAndNewerHashTypes { get => _safeNETCoreAndNewerHashTypes; }
        #endregion

        #region Methods
        public static void PropagateHashBox(KryptonComboBox hashBox)
        {
            HelperMethods helperMethods = new HelperMethods();

#if NETCOREAPP3_0_OR_GREATER
            foreach (string hashType in helperMethods.SafeNetCoreAndNewerHashTypes)
	        {
                hashBox.Items.Add(hashType);
	        }
#else
            foreach (string hashType in helperMethods.HashTypes)
            {
                hashBox.Items.Add(hashType);
            }
#endif
        }

        public static bool IsValid(string fileCheckSum, string checkSumToCompare) => checkSumToCompare.Contains(fileCheckSum);
        #endregion
    }
}