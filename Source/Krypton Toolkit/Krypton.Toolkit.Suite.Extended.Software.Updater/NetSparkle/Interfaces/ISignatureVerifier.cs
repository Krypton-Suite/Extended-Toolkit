#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Interface for objects that can verify a signature for an app cast, a
    /// downloaded file, or some other item. This is used to verify that the
    /// correct data was downloaded from the internet and there wasn't any 
    /// nefarious play or manipulation of items when something was delivered
    /// to the end user.
    /// </summary>
    public interface ISignatureVerifier
    {
        /// <summary>
        /// The <see cref="SecurityMode"/> for the signature verifier. This determines
        /// the level of security for the application and the items that it downloads
        /// from the internet.
        /// </summary>
        SecurityMode SecurityMode { get; set; }

        /// <summary>
        /// Check to see if we have valid public (or other) key information so
        /// that we can verify signatures properly.
        /// </summary>
        /// <returns>true if this object has valid public/other key information
        /// and can safely verify the signature of a given item; false otherwise</returns>
        bool HasValidKeyInformation();

        /// <summary>
        /// Verify that the given data has the same signature as the passed-in signature
        /// </summary>
        /// <param name="signature">the signature to validate against dataToVerify's signature</param>
        /// <param name="dataToVerify">the data that should be used to obtain a signature and
        /// checked against the passed-in signature</param>
        /// <returns>the <see cref="ValidationResult"/> result of the verification process</returns>
        ValidationResult VerifySignature(string signature, byte[] dataToVerify);

        /// <summary>
        /// Verify that the file at the given path has the same signature as the passed-in
        /// signature
        /// </summary>
        /// <param name="signature">the signature to validate against the signature of 
        /// the file at binaryPath</param>
        /// <param name="binaryPath">the file path to the file whose signature you want to verify</param>
        /// <returns>the <see cref="ValidationResult"/> result of the verification process</returns>
        ValidationResult VerifySignatureOfFile(string signature, string binaryPath);

        /// <summary>
        /// Verify that the file at the given path has the same signature as the passed-in
        /// string
        /// </summary>
        /// <param name="signature">the signature to validate against the signature
        /// of the passed-in string</param>
        /// <param name="data">the string whose signature you want to verify</param>
        /// <returns>the <see cref="ValidationResult"/> result of the verification process</returns>
        ValidationResult VerifySignatureOfString(string signature, string? data);
    }
}