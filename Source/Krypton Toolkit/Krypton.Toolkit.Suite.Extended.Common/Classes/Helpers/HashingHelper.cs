#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class HashingHelper
    {
        #region Variables
        private static string[] _hashTypeArray = { "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "RIPEMD-160" };
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the hash type array.
        /// </summary>
        /// <value>
        /// The hash type array.
        /// </value>
        public static string[] HashTypeArray { get => _hashTypeArray; }
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="HashingHelper"/> class.
        /// </summary>
        public HashingHelper()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Propagates the hash input.
        /// </summary>
        /// <param name="box">The box.</param>
        public static void PropagateHashInput(KryptonComboBox box)
        {
            try
            {
                foreach (string value in HashTypeArray)
                {
                    box.Items.Add(value);
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        /// <summary>
        /// Determines whether [is hash valid] [the specified file hash].
        /// </summary>
        /// <param name="fileHash">The file hash.</param>
        /// <param name="hash">The hash.</param>
        /// <returns>
        ///   <c>true</c> if [is hash valid] [the specified file hash]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHashValid(KryptonLabel fileHash, KryptonTextBox hash)
        {
            return fileHash.Text.Contains(hash.Text);
        }

        /// <summary>
        /// Validates the file hash.
        /// </summary>
        /// <param name="fileHash">The file hash.</param>
        /// <param name="hash">The hash.</param>
        public static void ValidateFileHash(KryptonLabel fileHash, KryptonTextBox hash)
        {
            if (IsHashValid(fileHash, hash))
            {
                hash.StateCommon.Back.Color1 = Color.Green;

                hash.StateCommon.Content.Color1 = Color.Black;
            }
            else
            {
                hash.StateCommon.Back.Color1 = Color.Red;

                hash.StateCommon.Content.Color1 = Color.White;
            }
        }

        /// <summary>
        /// Validates the file hash.
        /// </summary>
        /// <param name="showConfirmation">if set to <c>true</c> [show confirmation].</param>
        /// <param name="fileHash">The file hash.</param>
        /// <param name="hash">The hash.</param>
        public static void ValidateFileHash(bool showConfirmation, KryptonLabel fileHash, KryptonTextBox hash)
        {
            if (showConfirmation)
            {
                if (IsHashValid(fileHash, hash))
                {
                    hash.StateCommon.Back.Color1 = Color.Green;

                    hash.StateCommon.Content.Color1 = Color.Black;
                }
                else
                {
                    hash.StateCommon.Back.Color1 = Color.Red;

                    hash.StateCommon.Content.Color1 = Color.White;
                }
            }
            else
            {
                ValidateFileHash(fileHash, hash);
            }
        }

        /// <summary>
        /// Determines whether [is background worker busy] [the specified MD5].
        /// </summary>
        /// <param name="md5">The MD5.</param>
        /// <param name="ripemd160">The ripemd160.</param>
        /// <param name="sha1">The sha1.</param>
        /// <param name="sha256">The sha256.</param>
        /// <param name="sha384">The sha384.</param>
        /// <param name="sha512">The sha512.</param>
        /// <returns>
        ///   <c>true</c> if [is background worker busy] [the specified MD5]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBackgroundWorkerBusy(BackgroundWorker md5, BackgroundWorker ripemd160, BackgroundWorker sha1, BackgroundWorker sha256, BackgroundWorker sha384, BackgroundWorker sha512)
        {
            if (md5.IsBusy || ripemd160.IsBusy || sha1.IsBusy || sha256.IsBusy || sha384.IsBusy || sha512.IsBusy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Cancels the background worker progress.
        /// </summary>
        /// <param name="md5">The MD5.</param>
        /// <param name="ripemd160">The ripemd160.</param>
        /// <param name="sha1">The sha1.</param>
        /// <param name="sha256">The sha256.</param>
        /// <param name="sha384">The sha384.</param>
        /// <param name="sha512">The sha512.</param>
        public static void CancelBackgroundWorkerProgress(BackgroundWorker md5, BackgroundWorker ripemd160, BackgroundWorker sha1, BackgroundWorker sha256, BackgroundWorker sha384, BackgroundWorker sha512)
        {
            try
            {
                md5.CancelAsync();

                ripemd160.CancelAsync();

                sha1.CancelAsync();

                sha256.CancelAsync();

                sha384.CancelAsync();

                sha512.CancelAsync();
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        /// <summary>
        /// Builds the file hash.
        /// </summary>
        /// <param name="hashBytes">The hash bytes.</param>
        /// <param name="size">The size.</param>
        /// <param name="toUpperCase">if set to <c>true</c> [to upper case].</param>
        /// <returns></returns>
        public static string BuildFileHash(byte[] hashBytes, int size, bool toUpperCase = true)
        {
            StringBuilder builder = new StringBuilder(size);

            foreach (byte b in hashBytes)
            {
                if (toUpperCase)
                {
                    builder.Append(b.ToString("X2").ToUpper());
                }
                else
                {
                    builder.Append(b.ToString("X2").ToLower());
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Updates the type of the hash.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="hashLength">Length of the hash.</param>
        public static void UpdateHashType(KryptonComboBox box, int hashLength)
        {
            if (hashLength == 32)
            {
                box.Text = "MD5";
            }
            else if (hashLength == 40)
            {
                box.Text = "SHA-1";
            }
            else if (hashLength == 64)
            {
                box.Text = "SHA-256";
            }
            else if (hashLength == 96)
            {
                box.Text = "SHA-384";
            }
            else if (hashLength == 128)
            {
                box.Text = "SHA-512";
            }
            else
            {
                box.Text = "RIPEMD-160";
            }
        }
        #endregion
    }
}