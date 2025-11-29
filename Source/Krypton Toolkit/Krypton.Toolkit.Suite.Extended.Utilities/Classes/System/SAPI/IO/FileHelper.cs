#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.IO;

internal static class FileHelper
{
    [SecurityCritical]
    internal static FileStream CreateAndOpenTemporaryFile(out string filePath, FileAccess fileAccess = FileAccess.Write, FileOptions fileOptions = FileOptions.None, string? extension = null, string subFolder = "WPF")
    {
        int num = 5;
        filePath = null;
        bool flag = SecurityManager.CurrentThreadRequiresSecurityContextCapture();
        string text = Path.GetTempPath();
        if (!string.IsNullOrEmpty(subFolder))
        {
            string text2 = Path.Combine(text, subFolder);
            if (!Directory.Exists(text2))
            {
                if (!flag)
                {
                    Directory.CreateDirectory(text2);
                }
                else
                {
                    new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, text).Assert();
                    Directory.CreateDirectory(text2);
                    CodeAccessPermission.RevertAssert();
                }
            }
            text = text2;
        }
        if (flag)
        {
            new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, text).Assert();
        }
        FileStream fileStream = null;
        while (fileStream == null)
        {
            string text3 = Path.Combine(text, Path.GetRandomFileName());
            if (!string.IsNullOrEmpty(extension))
            {
                text3 = Path.ChangeExtension(text3, extension);
            }
            num--;
            try
            {
                fileStream = new FileStream(text3, FileMode.CreateNew, fileAccess, FileShare.None, 4096, fileOptions);
                filePath = text3;
            }
            catch (Exception ex) when (num > 0 && ex is IOException or UnauthorizedAccessException)
            {
            }
        }
        return fileStream;
    }

    [SecurityCritical]
    internal static void DeleteTemporaryFile(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            if (SecurityManager.CurrentThreadRequiresSecurityContextCapture())
            {
                new FileIOPermission(FileIOPermissionAccess.Write, filePath).Assert();
            }
            try
            {
                File.Delete(filePath);
            }
            catch (IOException)
            {
            }
        }
    }
}