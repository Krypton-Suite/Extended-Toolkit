#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools;

public class HashingHelpers
{
    #region Methods

#if !NETCOREAPP3_1_OR_GREATER
    public static SupportedHashAlgorithims ReturnHashType(string hashType) =>
        hashType switch
        {
            @"MD-5" or @"md-5" or @"MD5" or @"md5" => SupportedHashAlgorithims.MD5,
            @"SHA-1" or @"sha-1" or @"SHA1" or @"sha1" => SupportedHashAlgorithims.SHA1,
            @"SHA-256" or @"sha-256" or @"SHA256" or @"sha256" => SupportedHashAlgorithims.SHA256,
            @"SHA-384" or @"sha-384" or @"SHA384" or @"sha384" => SupportedHashAlgorithims.SHA384,
            @"SHA-512" or @"sha-512" or @"SHA512" or @"sha512" => SupportedHashAlgorithims.SHA512,
            @"RIPEMD-160" or @"ripemd-160" or @"RIPEMD160" or @"ripemd160" => SupportedHashAlgorithims.RIPEMD160,
            _ => SupportedHashAlgorithims.MD5
        };
#else
        public static SafeNETCoreAndNewerSupportedHashAlgorithims ReturnHashType(string hashType) =>
            hashType switch
            {
                @"MD-5" or @"md-5" or @"MD5" or @"md5" => SafeNETCoreAndNewerSupportedHashAlgorithims.MD5,
                @"SHA-1" or @"sha-1" or @"SHA1" or @"sha1" => SafeNETCoreAndNewerSupportedHashAlgorithims.SHA1,
                @"SHA-256" or @"sha-256" or @"SHA256" or @"sha256" =>
                    SafeNETCoreAndNewerSupportedHashAlgorithims.SHA256,
                @"SHA-384" or @"sha-384" or @"SHA384" or @"sha384" =>
                    SafeNETCoreAndNewerSupportedHashAlgorithims.SHA384,
                @"SHA-512" or @"sha-512" or @"SHA512" or @"sha512" =>
                    SafeNETCoreAndNewerSupportedHashAlgorithims.SHA512,
                _ => SafeNETCoreAndNewerSupportedHashAlgorithims.MD5
            };
#endif

    /// <summary>
    /// Builds a string representation of the MD5 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the MD5 hash.</returns>
    public static string BuildMD5HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

       // Set aside 32 bits in memory, for the total string length of the MD5 hash
        StringBuilder builder = new StringBuilder(32);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    private static void CheckHashBytesNull(byte[]? hashBytes)
    {
        if (hashBytes is null)
        {
            throw new ArgumentNullException(nameof(hashBytes));
        }
    }

    /// <summary>
    /// Builds a string representation of the SHA-1 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the SHA-1 hash.</returns>
    public static string BuildSHA1HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

        // Set aside 40 bits in memory, for the total string length of the SHA-1 hash
        StringBuilder builder = new StringBuilder(40);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Builds a string representation of the SHA-256 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the SHA-256 hash.</returns>
    public static string BuildSHA256HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

        // Set aside 64 bits in memory, for the total string length of the SHA-256 hash
        StringBuilder builder = new StringBuilder(64);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Builds a string representation of the SHA-384 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the SHA-384 hash.</returns>
    public static string BuildSHA384HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

        // Set aside 96 bits in memory, for the total string length of the SHA-384 hash
        StringBuilder builder = new StringBuilder(96);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Builds a string representation of the SHA-512 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the SHA-512 hash.</returns>
    public static string BuildSHA512HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

        // Set aside 128 bits in memory, for the total string length of the SHA-512 hash
        StringBuilder builder = new StringBuilder(128);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Builds a string representation of the RIPEMD-160 hash from the given byte array.
    /// </summary>
    /// <param name="hashBytes">The byte array containing the hash value.</param>
    /// <returns>A string representing the RIPEMD-160 hash.</returns>
    public static string BuildRIPEMD160HashString(byte[]? hashBytes)
    {
        CheckHashBytesNull(hashBytes);

        // Set aside 40 bits in memory, for the total string length of the RIPEMD-160 hash
        StringBuilder builder = new StringBuilder(40);

        if (hashBytes != null)
        {
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }
    #endregion
}