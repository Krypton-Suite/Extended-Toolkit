#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// The RGBA channel
    /// </summary>
    public enum RGBAChannel
    {
        /// <summary>
        /// The red channel.
        /// </summary>
        RED,
        /// <summary>
        /// The green channel.
        /// </summary>
        GREEN,
        /// <summary>
        /// The blue channel.
        /// </summary>
        BLUE,
        /// <summary>
        /// The alpha channel.
        /// </summary>
        ALPHA
    }

    /// <summary>
    /// Specifies the origin of a navigation operation
    /// </summary>
    public enum NavigationOrigin
    {
        /// <summary>
        /// Specifies the beginning
        /// </summary>
        BEGIN,

        /// <summary>
        /// Specifies the current position
        /// </summary>
        CURRENT,

        /// <summary>
        /// Specifies the end
        /// </summary>
        END
    }

    public enum ColourSource
    {
        NONE,
        STANDARD,
        CUSTOM
    }

    public enum ColourSliderNubStyle
    {
        NONE,
        TOPLEFT,
        BOTTOMRIGHT
    }

    public enum ColourPalette
    {
        NONE,

        NAMED,

        OFFICE2010,

        PAINT,

        STANDARD,

        WEBSAFE,

        STANDARD256
    }

    /// <summary>
    /// Specifies the edit mode of a <see cref="ColourGridControl" />.
    /// </summary>
    public enum ColourEditingMode
    {
        /// <summary>
        /// None. No editing is allowed.
        /// </summary>
        NONE,

        /// <summary>
        /// Only custom colours can be edited.
        /// </summary>
        CUSTOMONLY,

        /// <summary>
        /// Custom or standard colours can be edited.
        /// </summary>
        BOTH
    }

    /// <summary>
    /// Determines how the selected cell in a <see cref="ColourGridControl" /> control is rendered.
    /// </summary>
    public enum ColourGridSelectedCellStyle
    {
        /// <summary>
        /// The selected cell is drawn no differently to any other cell.
        /// </summary>
        NONE,

        /// <summary>
        /// The selected cell displays a basic outline and focus rectangle.
        /// </summary>
        STANDARD,

        /// <summary>
        /// The selected cell is displayed larger than other cells
        /// </summary>
        ZOOMED
    }

    /// <summary>
    /// Specifies the sort order of colours
    /// </summary>
    public enum ColourCollectionSortOrder
    {
        /// <summary>
        /// Ordered by hue.
        /// </summary>
        HUE,

        /// <summary>
        /// Ordered by brightness.
        /// </summary>
        BRIGHTNESS,

        /// <summary>
        /// Ordered by value
        /// </summary>
        VALUE
    }

    /// <summary>
    /// Specifies the style of a colour cell border.
    /// </summary>
    public enum ColourCellBorderStyle
    {
        /// <summary>
        /// No border.
        /// </summary>
        NONE,

        /// <summary>
        /// A single line border.
        /// </summary>
        FIXEDSINGLE,

        /// <summary>
        /// A contrasting double border with a soft inner outline using the colour of the cell.
        /// </summary>
        DOUBLESOFT
    }

    /// <summary>
    /// Specifies the style of a colour bar
    /// </summary>
    public enum ColourBarStyle
    {
        /// <summary>
        /// A gradient from one colour to another.
        /// </summary>
        TWOCOLOUR,

        /// <summary>
        /// A gradient between three colours.
        /// </summary>
        THREECOLOUR,

        /// <summary>
        /// A gradient between a user defined number of colours.
        /// </summary>
        CUSTOM
    }

    /// <summary>
    /// Specifies the version of a Abode Photoshop colour swatch file
    /// </summary>
    public enum AdobePhotoshopColourSwatchFileVersion
    {
        /// <summary>
        /// Version 1
        /// </summary>
        VERSION1 = 1,

        /// <summary>
        /// Version 2
        /// </summary>
        VERSION2
    }

    /// <summary>
    /// Specifies the colour space of an Adobe Photoshop colour swatch file
    /// </summary>
    public enum AdobePhotoshopColourSwatchColourSpace
    {
        /// <summary>
        /// RGB
        /// </summary>
        RGB = 0,

        /// <summary>
        /// HSB
        /// </summary>
        HSB = 1,

        /// <summary>
        /// CMYK
        /// </summary>
        CMYK = 2,

        /// <summary>
        /// Lab
        /// </summary>
        LAB = 7,

        /// <summary>
        /// Grayscale
        /// </summary>
        GRAYSCALE = 8
    }

    public enum MiscellaneousColourDefinitions
    {
        /// <summary>
        /// The border colour
        /// </summary>
        BORDERCOLOUR,
        /// <summary>
        /// The alternative normal text colour
        /// </summary>
        ALTERNATIVENORMALTEXTCOLOUR,
        /// <summary>
        /// The normal text colour
        /// </summary>
        NORMALTEXTCOLOUR,
        /// <summary>
        /// The disabled text colour
        /// </summary>
        DISABLEDTEXTCOLOUR,
        /// <summary>
        /// The focused text colour
        /// </summary>
        FOCUSEDTEXTCOLOUR,
        /// <summary>
        /// The pressed text colour
        /// </summary>
        PRESSEDTEXTCOLOUR,
        /// <summary>
        /// The link normal text colour
        /// </summary>
        LINKNORMALTEXTCOLOUR,
        /// <summary>
        /// The link disabled text colour
        /// </summary>
        LINKDISABLEDTEXTCOLOUR,
        /// <summary>
        /// The link hover text colour
        /// </summary>
        LINKHOVERTEXTCOLOUR,
        /// <summary>
        /// The link visited text colour
        /// </summary>
        LINKVISITEDTEXTCOLOUR,
        /// <summary>
        /// The disabled control colour
        /// </summary>
        DISABLEDCONTROLCOLOUR,
        /// <summary>
        /// The custom colour one
        /// </summary>
        CUSTOMCOLOURONE,
        /// <summary>
        /// The custom colour two
        /// </summary>
        CUSTOMCOLOURTWO,
        /// <summary>
        /// The custom colour three
        /// </summary>
        CUSTOMCOLOURTHREE,
        /// <summary>
        /// The custom colour four
        /// </summary>
        CUSTOMCOLOURFOUR,
        /// <summary>
        /// The custom colour five
        /// </summary>
        CUSTOMCOLOURFIVE,
        /// <summary>
        /// The menu text colour
        /// </summary>
        MENUTEXTCOLOUR,
        /// <summary>
        /// The custom text colour one
        /// </summary>
        CUSTOMTEXTCOLOURONE,
        /// <summary>
        /// The custom text colour two
        /// </summary>
        CUSTOMTEXTCOLOURTWO,
        /// <summary>
        /// The custom text colour three
        /// </summary>
        CUSTOMTEXTCOLOURTHREE,
        /// <summary>
        /// The custom text colour four
        /// </summary>
        CUSTOMTEXTCOLOURFOUR,
        /// <summary>
        /// The custom text colour five
        /// </summary>
        CUSTOMTEXTCOLOURFIVE,
        /// <summary>
        /// The status text colour
        /// </summary>
        STATUSTEXTCOLOUR,
        RIBBONTABTEXTCOLOUR
    }

    public enum BasicPaletteColourDefinitions
    {
        BASECOLOUR = 0,
        DARKESTCOLOUR = 1,
        MIDDLECOLOUR = 2,
        LIGHTCOLOUR = 3,
        LIGHTESTCOLOUR = 4
    }

    public enum AllAvailableColourTypes
    {
        ALTERNATIVENORMALTEXTCOLOUR,
        BASECOLOUR,
        BORDERCOLOUR,
        CUSTOMCOLOURONE,
        CUSTOMCOLOURTWO,
        CUSTOMCOLOURTHREE,
        CUSTOMCOLOURFOUR,
        CUSTOMCOLOURFIVE,
        CUSTOMCOLOURSIX,
        CUSTOMTEXTCOLOURONE,
        CUSTOMTEXTCOLOURTWO,
        CUSTOMTEXTCOLOURTHREE,
        CUSTOMTEXTCOLOURFOUR,
        CUSTOMTEXTCOLOURFIVE,
        CUSTOMTEXTCOLOURSIX,
        DARKESTCOLOUR,
        DISABLEDCONTROLCOLOUR,
        DISABLEDTEXTCOLOUR,
        FOCUSEDTEXTCOLOUR,
        LIGHTCOLOUR,
        LIGHTESTCOLOUR,
        LINKDISABLEDCOLOUR,
        LINKHOVERCOLOUR,
        LINKNORMALCOLOUR,
        LINKVISITEDCOLOUR,
        MEDIUMCOLOUR,
        MENUTEXTCOLOUR,
        NORMALTEXTCOLOUR,
        PRESSEDTEXTCOLOUR,
        STATUSTEXTCOLOUR
    }

    public enum SettingTypes
    {
        BOOLEAN,
        COLOUR,
        COLOURSTRING,
        COLOURINTEGER,
        STRING,
        INTEGER
    }

    public enum ColourDialogLayoutType
    {
        STANDARD,
        ENHANCED
    }

    /// <summary>The chosen language for buttons.</summary>
    public enum Language
    {
        /// <summary>The Czech definition.</summary>
        CZECH,
        /// <summary>The English definition.</summary>
        ENGLISH,
        /// <summary>The Français definition.</summary>
        FRANÇAIS,
        /// <summary>The Deutsch definition.</summary>
        DEUTSCH,
        /// <summary>The Slovakian definition.</summary>
        SLOVAKIAN,
        /// <summary>The Español definition.</summary>
        ESPAÑOL,
        /// <summary>A custom language definition.</summary>
        CUSTOM
    }

    /// <summary>Specifies the button layout in the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedMessageBoxButtons
    {
        /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonOptions"/> values.</summary>
        Custom = 0,
        /// <summary>Defines a 'OK' button only.</summary>
        OK = 5,
        /// <summary>Defines both 'OK' and 'Cancel' buttons.</summary>
        OkCancel = 6,
        /// <summary>Defines 'Abort', 'Retry' and 'Ignore' buttons.</summary>
        AbortRetryIgnore = 7,
        /// <summary>Defines 'Yes', 'No' and 'Cancel' buttons.</summary>
        YesNoCancel = 8,
        /// <summary>Defines both 'Yes' and 'No' buttons.</summary>
        YesNo = 9,
        /// <summary>Defines both 'Retry' and 'Cancel' buttons.</summary>
        RetryCancel = 10,
        /// <summary>Defines 'Cancel', 'Try Again' and 'Continue' buttons.</summary>
        CancelTryContinue = 11
    }

    /// <summary>Specifies an icon for the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedKryptonMessageBoxIcon
    {
        /// <summary>Specify a custom icon.</summary>
        Custom = 0,
        /// <summary>Specify no icon.</summary>
        None = 1,
        /// <summary>Specify a hand icon.</summary>
        Hand = 2,
        /// <summary>Specify a question icon.</summary>
        Question = 3,
        /// <summary>Specify a exclamation icon.</summary>
        Exclamation = 4,
        /// <summary>Specify a asterisk icon.</summary>
        Asterisk = 5,
        /// <summary>Specify a stop icon.</summary>
        Stop = 6,
        /// <summary>Specify a error icon.</summary>
        Error = 7,
        /// <summary>Specify a warning icon.</summary>
        Warning = 8,
        /// <summary>Specify a information icon.</summary>
        Information = 9,
        /// <summary>Specify a UAC shield icon.</summary>
        Shield = 10,
        /// <summary>Specify a Windows logo icon.</summary>
        WindowsLogo = 11
    }

    /// <summary>Specifies a custom button layout.</summary>
    public enum ExtendedMessageBoxCustomButtonOptions
    {
        /// <summary>Do not use custom buttons, instead default to an 'OK' only button.</summary>
        None = 0,
        /// <summary>Use a one button layout.</summary>
        OneButton = 1,
        /// <summary>Use a two button layout.</summary>
        TwoButtons = 2,
        /// <summary>Use a three button layout.</summary>
        ThreeButtons = 3,
        /// <summary>Use a four button layout.</summary>
        FourButtons = 4
    }

    public enum ExtendedMessageBoxTimeoutAction
    {
        Close = 0,
        ButtonOne = 1,
        ButtonTwo = 2,
        ButtonThree = 3,
        ButtonFour = 4
    }

    public enum ExtendedMessageBoxTimeoutButton
    {
        FirstButton = 0,
        SECONDBUTTON = 1,
        THIRDBUTTON = 2
    }

    public enum ExtendedMessageBoxDialogResult
    {
        NONE = 0,
        OK = 1,
        CANCEL = 2,
        ABORT = 3,
        RETRY = 4,
        IGNORE = 5,
        YES = 6,
        NO = 7,
        TRYAGAIN = 8,
        CONTINUE = 9
    }
}