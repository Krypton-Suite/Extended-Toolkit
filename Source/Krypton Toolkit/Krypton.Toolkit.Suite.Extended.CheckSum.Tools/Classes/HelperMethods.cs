namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class HelperMethods
    {
        #region Variables
        private string[] _hashTypes = new string[] { "MD-5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "RIPEMD-160" };
        #endregion

        #region Properties
        public string[] HashTypes { get => _hashTypes; }
        #endregion

        #region Methods
        public static void PropagateHashBox(KryptonComboBox hashBox)
        {
            HelperMethods helperMethods = new HelperMethods();

            foreach (string hashType in helperMethods.HashTypes)
            {
                hashBox.Items.Add(hashType);
            }
        }

        public static bool IsValid(string fileCheckSum, string checkSumToCompare) => checkSumToCompare.Contains(fileCheckSum);
        #endregion
    }
}