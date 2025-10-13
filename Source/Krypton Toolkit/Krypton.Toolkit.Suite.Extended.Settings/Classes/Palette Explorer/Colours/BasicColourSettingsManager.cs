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

namespace Krypton.Toolkit.Suite.Extended.Settings;

public class BasicColourSettingsManager
{
    #region Variables
    private bool _alwaysUsePrompt = false, _settingsModified = false;

    private BasicColourSettings _basicColourSettings = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets a value indicating whether [always use prompt].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [always use prompt]; otherwise, <c>false</c>.
    /// </value>
    public bool AlwaysUsePrompt
    {
        get => _alwaysUsePrompt;

        set => _alwaysUsePrompt = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [settings modified].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [settings modified]; otherwise, <c>false</c>.
    /// </value>
    public bool SettingsModified
    {
        get => _settingsModified;

        set => _settingsModified = value;
    }
    #endregion

    #region Settings Manipulation
    /// <summary>
    /// Sets the value of AlwaysUsePrompt to value.
    /// </summary>
    /// <param name="value">The value of AlwaysUsePrompt.</param>
    public void SetAlwaysUsePrompt(bool value)
    {
        AlwaysUsePrompt = value;
    }

    /// <summary>
    /// Returns the value of AlwaysUsePrompt.
    /// </summary>
    /// <returns>The value of AlwaysUsePrompt.</returns>
    public bool GetAlwaysUsePrompt()
    {
        return AlwaysUsePrompt;
    }

    /// <summary>
    /// Sets the value of SettingsModified to value.
    /// </summary>
    /// <param name="value">The value of SettingsModified.</param>
    public void SetSettingsModified(bool value)
    {
        SettingsModified = value;
    }

    /// <summary>
    /// Returns the value of SettingsModified.
    /// </summary>
    /// <returns>The value of SettingsModified.</returns>
    public bool GetSettingsModified()
    {
        return SettingsModified;
    }
    #endregion

    #region Constructors
    public BasicColourSettingsManager()
    {

    }
    #endregion

    #region Setters and Getters
    /// <summary>
    /// Sets the value of BaseColour to colour.
    /// </summary>
    /// <param name="colour">The value of BaseColour.</param>
    public void SetBaseColour(Color colour)
    {
        _basicColourSettings.BaseColour = colour;

        SetSettingsModified(true);
    }

    /// <summary>
    /// Returns the value of BaseColour.
    /// </summary>
    /// <returns>The value of BaseColour.</returns>
    public Color GetBaseColour()
    {
        return _basicColourSettings.BaseColour;
    }

    /// <summary>
    /// Sets the value of DarkColour to colour.
    /// </summary>
    /// <param name="colour">The value of DarkColour.</param>
    public void SetDarkColour(Color colour)
    {
        _basicColourSettings.DarkColour = colour;

        SetSettingsModified(true);
    }

    /// <summary>
    /// Returns the value of DarkColour.
    /// </summary>
    /// <returns>The value of DarkColour.</returns>
    public Color GetDarkColour()
    {
        return _basicColourSettings.DarkColour;
    }

    /// <summary>
    /// Sets the value of MediumColour to colour.
    /// </summary>
    /// <param name="colour">The value of MediumColour.</param>
    public void SetMediumColour(Color colour)
    {
        _basicColourSettings.MediumColour = colour;

        SetSettingsModified(true);
    }

    /// <summary>
    /// Returns the value of MediumColour.
    /// </summary>
    /// <returns>The value of MediumColour.</returns>
    public Color GetMediumColour()
    {
        return _basicColourSettings.MediumColour;
    }

    /// <summary>
    /// Sets the value of LightColour to colour.
    /// </summary>
    /// <param name="colour">The value of LightColour.</param>
    public void SetLightColour(Color colour)
    {
        _basicColourSettings.LightColour = colour;

        SetSettingsModified(true);
    }

    /// <summary>
    /// Returns the value of LightColour.
    /// </summary>
    /// <returns>The value of LightColour.</returns>
    public Color GetLightColour()
    {
        return _basicColourSettings.LightColour;
    }

    /// <summary>
    /// Sets the value of LightestColour to colour.
    /// </summary>
    /// <param name="colour">The value of LightestColour.</param>
    public void SetLightestColour(Color colour)
    {
        _basicColourSettings.LightestColour = colour;

        SetSettingsModified(true);
    }

    /// <summary>
    /// Returns the value of LightestColour.
    /// </summary>
    /// <returns>The value of LightestColour.</returns>
    public Color GetLightestColour()
    {
        return _basicColourSettings.LightestColour;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Resets to defaults.
    /// </summary>
    public void ResetToDefaults()
    {
        if (MessageBox.Show(@"WARNING! You are about to reset these settings back to their original state. This action cannot be undone!
Do you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
            SetBaseColour(Color.Empty);

            SetDarkColour(Color.Empty);

            SetMediumColour(Color.Empty);

            SetLightColour(Color.Empty);

            SetLightestColour(Color.Empty);

            if (MessageBox.Show($@"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }

    /// <summary>
    /// Saves the basic colour settings.
    /// </summary>
    /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
    public void SaveBasicColourSettings(bool alwaysUsePrompt = false)
    {
        if (alwaysUsePrompt)
        {
            if (MessageBox.Show(@"You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _basicColourSettings.Save();

                SetSettingsModified(false);
            }
        }
        else
        {
            _basicColourSettings.Save();

            SetSettingsModified(false);
        }
    }

    /// <summary>
    /// Writes the ARGB colours to file.
    /// </summary>
    /// <param name="colourFileName">Name of the colour file.</param>
    public static void WriteARGBColoursToFile(string colourFileName)
    {
        BasicColourSettingsManager manager = new();

        StreamWriter writer = new(colourFileName);

        writer.WriteLine(TranslationMethods.ColourARGBToString(manager.GetBaseColour()));

        writer.WriteLine(TranslationMethods.ColourARGBToString(manager.GetDarkColour()));

        writer.WriteLine(TranslationMethods.ColourARGBToString(manager.GetMediumColour()));

        writer.WriteLine(TranslationMethods.ColourARGBToString(manager.GetLightColour()));

        writer.WriteLine(TranslationMethods.ColourARGBToString(manager.GetLightestColour()));

        writer.Flush();

        writer.Close();

        writer.Dispose();
    }

    public static void WriteRGBColoursToFile(string colourFilePath)
    {
        BasicColourSettingsManager manager = new();

        StreamWriter writer = new(colourFilePath);

        writer.WriteLine(TranslationMethods.RGBColourToString(manager.GetBaseColour()));

        writer.WriteLine(TranslationMethods.RGBColourToString(manager.GetDarkColour()));

        writer.WriteLine(TranslationMethods.RGBColourToString(manager.GetLightColour()));

        writer.WriteLine(TranslationMethods.RGBColourToString(manager.GetLightestColour()));

        writer.Flush();

        writer.Close();

        writer.Dispose();
    }
    #endregion

    #region Detection        
    /// <summary>
    /// Are the basic palette colours empty.
    /// </summary>
    /// <returns></returns>
    public static bool AreBasicPaletteColoursEmpty()
    {
        BasicColourSettingsManager basicPaletteColourManager = new();

        if (basicPaletteColourManager.GetBaseColour() == Color.Empty || basicPaletteColourManager.GetDarkColour() == Color.Empty || basicPaletteColourManager.GetMediumColour() == Color.Empty || basicPaletteColourManager.GetLightColour() == Color.Empty || basicPaletteColourManager.GetLightestColour() == Color.Empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region IO Methods
    /// <summary>
    /// Creates a ARGB colour configuration file.
    /// </summary>
    public static void CreateARGBConfigurationFile(FileDialogType fileDialogType = FileDialogType.Standard)
    {
        try
        {
            switch (fileDialogType)
            {
                case FileDialogType.Krypton:
                    KryptonSaveFileDialog sfd = new();

                    sfd.Title = @"Save Colours To:";

                    sfd.Filter = @"Colour Configuration File | *.ccf | Normal Text Files | *.txt";

                    sfd.DefaultExt = "ccf";

                    sfd.FileName = $"Basic Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        WriteARGBColoursToFile(sfd.FileName);
                    }
                    break;
                case FileDialogType.Standard:
                    SaveFileDialog dialog = new();

                    dialog.Title = @"Save Colours To:";

                    dialog.Filter = @"Colour Configuration File | *.ccf | Normal Text Files | *.txt";

                    dialog.DefaultExt = "ccf";

                    dialog.FileName = $"Basic Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        WriteARGBColoursToFile(dialog.FileName);
                    }
                    break;
                case FileDialogType.WindowsAPICodePack:
                    CommonSaveFileDialog csfd = new();

                    csfd.Title = "Save Colours To:";

                    csfd.Filters.Add(new("Colour Configuration File", ".ccf"));

                    csfd.Filters.Add(new("Normal Text File", ".txt"));

                    csfd.DefaultFileName = $"Basic Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    csfd.AlwaysAppendDefaultExtension = true;

                    csfd.DefaultExtension = "ccf";

                    if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        WriteARGBColoursToFile(csfd.FileName);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileDialogType), fileDialogType, null);
            }
            if (OSHelper.IsSevenOrHigher())
            {
            }
            else
            {
            }
        }
        catch (Exception exc)
        {
            ExceptionHandler.CaptureException(exc);
        }
    }

    /// <summary>
    /// Creates a RGB colour configuration file.
    /// </summary>
    public static void CreateRGBConfigurationFile(FileDialogType fileDialogType = FileDialogType.Standard)
    {
        try
        {
            switch (fileDialogType)
            {
                case FileDialogType.Krypton:
                    KryptonSaveFileDialog sfd = new();

                    sfd.Title = @"Save Colours To:";

                    sfd.Filter = @"Colour Configuration File | *.ccf | Normal Text Files | *.txt";

                    sfd.DefaultExt = "ccf";

                    sfd.FileName = $"All Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        WriteRGBColoursToFile(sfd.FileName);
                    }
                    break;
                case FileDialogType.Standard:
                    SaveFileDialog dialog = new();

                    dialog.Title = @"Save Colours To:";

                    dialog.Filter = @"Colour Configuration File | *.ccf | Normal Text Files | *.txt";

                    dialog.DefaultExt = "ccf";

                    dialog.FileName = $"All Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        WriteRGBColoursToFile(dialog.FileName);
                    }
                    break;
                case FileDialogType.WindowsAPICodePack:
                    CommonSaveFileDialog csfd = new();

                    csfd.Title = "Save Colours To:";

                    csfd.Filters.Add(new("Colour Configuration File", ".ccf"));

                    csfd.Filters.Add(new("Normal Text File", ".txt"));

                    csfd.DefaultFileName = $"Basic Colour Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                    csfd.AlwaysAppendDefaultExtension = true;

                    csfd.DefaultExtension = "ccf";

                    if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        WriteRGBColoursToFile(csfd.FileName);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileDialogType), fileDialogType, null);
            }
        }
        catch (Exception exc)
        {
            ExceptionHandler.CaptureException(exc);
        }
    }
    #endregion
}