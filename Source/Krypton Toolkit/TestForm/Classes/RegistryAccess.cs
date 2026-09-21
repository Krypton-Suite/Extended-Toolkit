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

using Microsoft.Win32;

namespace TestForm;

/// <summary>
/// Persists TestForm window size, dock state, and last filter text.
/// </summary>
public class RegistryAccess
{
    private readonly RegistryKey _registryKey;
    private const string RegistryPath = @"Software\Krypton-Suite\Extended-Toolkit\TestForm";
    private const string RvLastFilterString = "LastFilterString";
    private const string RvDockTopRight = "DockTopRight";
    private const string RvFormWidth = "FormWidth";
    private const string RvFormHeight = "FormHeight";

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <exception cref="Exception">Thrown when the registry key cannot be opened.</exception>
    public RegistryAccess()
    {
        _registryKey = Registry.CurrentUser.CreateSubKey(RegistryPath)
            ?? throw new Exception("Registry.CurrentUser.CreateSubKey() returned null.");
    }

    public int FormWidth
    {
        get => int.TryParse(_registryKey.GetValue(RvFormWidth, -1)?.ToString(), out int width)
            ? width
            : -1;

        set => _registryKey.SetValue(RvFormWidth, value);
    }

    public int FormHeight
    {
        get => int.TryParse(_registryKey.GetValue(RvFormHeight, -1)?.ToString(), out int height)
            ? height
            : -1;

        set => _registryKey.SetValue(RvFormHeight, value);
    }

    public Size FormSize
    {
        get => new Size(FormWidth, FormHeight);

        set
        {
            FormWidth = value.Width;
            FormHeight = value.Height;
        }
    }

    public string LastFilterString
    {
        get => _registryKey.GetValue(RvLastFilterString) as string ?? string.Empty;
        set => _registryKey.SetValue(RvLastFilterString, value);
    }

    public bool DockTopRight
    {
        get => (_registryKey.GetValue(RvDockTopRight, "0") as string) == "1";
        set => _registryKey.SetValue(RvDockTopRight, value ? "1" : "0");
    }
}
