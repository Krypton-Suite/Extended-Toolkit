#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// Controls the situations where files have to be signed with the private key.
/// If both a public key and a signature are present, they always have to be valid.
/// 
/// We recommend using <see cref="SecurityMode.Strict"/> if at all possible.
/// 
/// Note that <see cref="ReleaseNotesGrabber"/> needs to have 
/// <see cref="ReleaseNotesGrabber.ChecksReleaseNotesSignature"/> set to true in order
/// to verify signatures.
/// </summary>
public enum SecurityMode
{
    /// <summary>
    /// All files (with or without signature) will be accepted.
    /// This mode is strongly NOT recommended. It can cause critical security issues.
    /// </summary>
    Unsafe = 1,

    /// <summary>
    /// If there is a public key, the app cast and download file have to be signed. 
    /// If there isn't a public key, files without a signature will also be accepted. 
    /// This mode is a mix between Unsafe and Strict and can have some security issues if the 
    /// public key gets lost in the application.
    /// </summary>
    UseIfPossible = 2,

    /// <summary>
    /// The app cast and download file have to be signed. This means the public key must exist. This is the default mode.
    /// </summary>
    Strict = 3,

    /// <summary>
    /// Only verify the signature of software downloads (via an ISignatureVerifier).
    /// Do not verify the signature of anything else: app casts, release notes, etc.
    /// </summary>
    OnlyVerifySoftwareDownloads = 4,
}