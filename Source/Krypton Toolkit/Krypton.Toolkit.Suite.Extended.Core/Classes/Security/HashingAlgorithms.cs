#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class HashingAlgorithms
    {
        #region Variables
        BackgroundWorker _md5Worker, _sha1Worker, _sha256Worker, _sha384Worker, _sha512Worker, _ripemd160Worker;

        string _md5, _sha1, _sha256, _sha384, _sha512, _ripemd160;

        ProgressBar _hashingProgress;

        ToolStripProgressBar _toolStripHashingProgress;

        ToolStripLabel _toolStripProgressValueLabel;

        KryptonLabel _kryptonProgressValueLabel;
        #endregion

        #region Properties
        public BackgroundWorker MD5Worker { get => _md5Worker; set => _md5Worker = value; }

        public BackgroundWorker SHA1Worker { get => _sha1Worker; set => _sha1Worker = value; }

        public BackgroundWorker SHA256Worker { get => _sha256Worker; set => _sha256Worker = value; }

        public BackgroundWorker SHA384Worker { get => _sha384Worker; set => _sha384Worker = value; }

        public BackgroundWorker SHA512Worker { get => _sha512Worker; set => _sha512Worker = value; }

        public BackgroundWorker RIPEMD160Worker { get => _ripemd160Worker; set => _ripemd160Worker = value; }

        public string MD5Output { get => _md5; set => _md5 = value; }

        public string SHA1Output { get => _sha1; set => _sha1 = value; }

        public string SHA256Output { get => _sha256; set => _sha256 = value; }

        public string SHA384Output { get => _sha384; set => _sha384 = value; }

        public string SHA512Output { get => _sha512; set => _sha512 = value; }

        public string RIPEMD160Output { get => _ripemd160; set => _ripemd160 = value; }

        public ProgressBar HashingProgress { get => _hashingProgress; set => _hashingProgress = value; }

        public ToolStripProgressBar HashingProgressBar { get => _toolStripHashingProgress; set => _toolStripHashingProgress = value; }

        public ToolStripLabel HashingProgressValueLabel { get => _toolStripProgressValueLabel; set => _toolStripProgressValueLabel = value; }

        public KryptonLabel ProgressValueLabel { get => _kryptonProgressValueLabel; set => _kryptonProgressValueLabel = value; }
        #endregion

        #region Constructor
        public HashingAlgorithms()
        {

        }
        #endregion

        #region Methods
        public static void GenerateMD5Hash(BackgroundWorker md5Worker, string filePath)
        {
            md5Worker = new BackgroundWorker();

            md5Worker.WorkerReportsProgress = true;

            md5Worker.WorkerSupportsCancellation = true;

            SetMD5Worker(md5Worker);

            md5Worker.DoWork += MD5Worker_DoWork;

            md5Worker.ProgressChanged += MD5Worker_ProgressChanged;

            md5Worker.RunWorkerCompleted += MD5Worker_RunWorkerCompleted;

            md5Worker.RunWorkerAsync(filePath);
        }

        #endregion

        #region Event Handlers
        private static void MD5Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HashingAlgorithms algorithims = new HashingAlgorithms();

            algorithims.HashingProgress.Value = 0;

            algorithims.HashingProgressBar.Value = 0;

            algorithims.HashingProgressValueLabel.Text = string.Empty;

            algorithims.ProgressValueLabel.Text = string.Empty;

            algorithims.MD5Output = e.Result.ToString();

        }

        private static void MD5Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            HashingAlgorithms algorithims = new HashingAlgorithms();

            algorithims.HashingProgress.Value = e.ProgressPercentage;

            algorithims.HashingProgressBar.Value = e.ProgressPercentage;

            algorithims.HashingProgressValueLabel.Text = $"{ e.ProgressPercentage.ToString() }%";

            algorithims.ProgressValueLabel.Text = $"{ e.ProgressPercentage.ToString() }%";
        }

        private static void MD5Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream fileStream = File.OpenRead(filePath))
            {
                size = fileStream.Length;

                using (HashAlgorithm md5 = MD5.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        md5.TransformBlock(buffer, 0, bytesRead, null, 0);

                        GetMD5Worker().ReportProgress((int)((double)totalBytesRead / size * 100));

                    } while (bytesRead != 0);

                    md5.TransformFinalBlock(buffer, 0, 0);

                    e.Result = md5.Hash;
                }
            }
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of MD5Worker to value.
        /// </summary>
        /// <param name="value">The value of MD5Worker.</param>
        public static void SetMD5Worker(BackgroundWorker value)
        {
            HashingAlgorithms algorithims = new HashingAlgorithms();

            algorithims.MD5Worker = value;
        }

        /// <summary>
        /// Returns the value of MD5Worker.
        /// </summary>
        /// <returns>The value of MD5Worker.</returns>
        public static BackgroundWorker GetMD5Worker()
        {
            HashingAlgorithms algorithims = new HashingAlgorithms();

            return algorithims.MD5Worker;
        }
        #endregion
    }
}