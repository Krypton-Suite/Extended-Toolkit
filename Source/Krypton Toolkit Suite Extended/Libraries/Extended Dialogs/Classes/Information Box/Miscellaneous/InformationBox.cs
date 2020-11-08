using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
    /// </summary>
    [UIPermission(SecurityAction.Demand)]
    public static class InformationBox
    {
        #region Show

        /// <summary>
        /// Displays a message box with the specified text and parameters.
        /// <list type="table">
        ///     <listheader><term>If the type of the parameter is</term>
        ///                 <description>The value will be used as</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="System.String"/></term>
        ///         <description>the title of the <see cref="InformationBox"/> for the first string, the second string for the help file name, and the third one for the help topic id</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxButtons"/></term>
        ///         <description>which buttons to display on the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxIcon"/></term>
        ///         <description>which predefined icon to use for the <see cref="InformationBoxIcon"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Drawing.Icon"/></term>
        ///         <description>the icon to use for the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxDefaultButton"/></term>
        ///         <description>which button to set as default for the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.String"/>[]</term>
        ///         <description>the text for the custom buttons of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxBehavior"/></term>
        ///         <description>the modal/modeless state of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxButtonsLayout"/></term>
        ///         <description>the layout for the buttons of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxAutoSizeMode"/></term>
        ///         <description>how the <see cref="InformationBox"/> will resize itself according to the text.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxPosition"/></term>
        ///         <description>where the <see cref="InformationBox"/> will appear on the screen.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Boolean"/></term>
        ///         <description>whether the help button is displayed or not.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Windows.Forms.HelpNavigator"/></term>
        ///         <description>the Help content. You can use the following values for navigator: TableOfContents, Find, Index, or Topic.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxCheckBox"/></term>
        ///         <description>whether the "Do not show this dialog again" checkbox is displayed or not.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="AutoCloseParameters"/></term>
        ///         <description>The parameters for the auto-close feature.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="DesignParameters"/></term>
        ///         <description>the parameters for the design (colors).</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxTitleIconStyle"/></term>
        ///         <description>which icon will be displayed in the title bar.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxTitleIcon"/></term>
        ///         <description>the custom icon that will be displayed in the title bar.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxOpacity"/></term>
        ///         <description>the opacity of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="AsyncResultCallback"/></term>
        ///         <description>a method that will be called when a modeless dialog is closed.</description>
        ///     </item>
        ///     <item>
        ///         <term>A MessageBox enum value</term>
        ///         <description>the value for the corresponding <see cref="InformationBox"/> enum value.</description>
        ///     </item>
        ///     <item>
        ///         <term>A Form instance</term>
        ///         <description>the parent of the <see cref="InformationBox"/>.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="parameters">The parameters of the message box.</param>
        /// <returns>One of the <see cref="InformationBoxResult"/> values.</returns>
        public static InformationBoxResult Show(string text, params object[] parameters)
        {
            return new KryptonInformationBoxWindow(text, parameters).Show();
        }

        /// <summary>
        /// Displays a message box with the specified text and parameters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="helpFile">The help file.</param>
        /// <param name="helpTopic">The help topic.</param>
        /// <param name="initialization">The initialization.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="customIcon">The custom icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="customButtons">The custom buttons.</param>
        /// <param name="buttonsLayout">The buttons layout.</param>
        /// <param name="autoSizeMode">The auto size mode.</param>
        /// <param name="position">The position.</param>
        /// <param name="showHelpButton">if set to <c>true</c> shows help button.</param>
        /// <param name="helpNavigator">The help navigator.</param>
        /// <param name="showDoNotShowAgainCheckBox">if set to <c>true</c> shows the do not show again check box.</param>
        /// <param name="style">The style.</param>
        /// <param name="autoClose">The auto close configuration.</param>
        /// <param name="design">The design.</param>
        /// <param name="titleStyle">The title style.</param>
        /// <param name="titleIcon">The title icon.</param>
        /// <param name="legacyButtons">The legacy buttons.</param>
        /// <param name="legacyIcon">The legacy icon.</param>
        /// <param name="legacyDefaultButton">The legacy default button.</param>
        /// <param name="behavior">The behavior.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="parentWindow">The <see cref="KryptonForm">parent window.</see></param>
        /// <param name="parent">The parent form.</param>
        /// <param name="order">The z-order</param>
        /// <param name="sound">The sound configuration</param>
        /// <returns>One of the <see cref="InformationBoxResult"/> values.</returns>
        public static InformationBoxResult Show(string text,
                                                string title = "",
                                                string helpFile = "",
                                                string helpTopic = "",
                                                InformationBoxInitialization initialization = InformationBoxInitialization.FromScopeAndParameters,
                                                InformationBoxButtons buttons = InformationBoxButtons.OK,
                                                InformationBoxIcon icon = InformationBoxIcon.None,
                                                Icon customIcon = null,
                                                InformationBoxDefaultButton defaultButton = InformationBoxDefaultButton.Button1,
                                                string[] customButtons = null,
                                                InformationBoxButtonsLayout buttonsLayout = InformationBoxButtonsLayout.GroupMiddle,
                                                InformationBoxAutoSizeMode autoSizeMode = InformationBoxAutoSizeMode.None,
                                                InformationBoxPosition position = InformationBoxPosition.CenterOnParent,
                                                bool showHelpButton = false,
                                                HelpNavigator helpNavigator = HelpNavigator.TableOfContents,
                                                InformationBoxCheckBox showDoNotShowAgainCheckBox = 0,
                                                InformationBoxStyle style = InformationBoxStyle.Standard,
                                                AutoCloseParameters autoClose = null,
                                                DesignParameters design = null,
                                                InformationBoxTitleIconStyle titleStyle = InformationBoxTitleIconStyle.None,
                                                InformationBoxTitleIcon titleIcon = null,
                                                MessageBoxButtons? legacyButtons = null,
                                                MessageBoxIcon? legacyIcon = null,
                                                MessageBoxDefaultButton? legacyDefaultButton = null,
                                                InformationBoxBehavior behavior = InformationBoxBehavior.Modal,
                                                AsyncResultCallback callback = null,
                                                InformationBoxOpacity opacity = InformationBoxOpacity.NoFade,
                                                KryptonForm parentWindow = null,
                                                Form parent = null,
                                                InformationBoxOrder order = InformationBoxOrder.Default,
                                                InformationBoxSound sound = InformationBoxSound.Default)
        {
            var parameters = new object[]{ title, helpFile, helpTopic, initialization, buttons, icon, customIcon, defaultButton,
                 customButtons, buttonsLayout, autoSizeMode, position, showHelpButton, helpNavigator, showDoNotShowAgainCheckBox,
                 style, autoClose, design, titleStyle, titleIcon, legacyButtons, legacyIcon, legacyDefaultButton, behavior, callback, opacity, parentWindow, parent, order, sound };

            return new KryptonInformationBoxWindow(text, parameters).Show();
        }

        /// <summary>
        /// Displays a message box with the specified text and parameters.
        /// <list type="table">
        ///     <listheader><term>If the type of the parameter is</term>
        ///                 <description>The value will be used as</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="System.String"/></term>
        ///         <description>the title of the <see cref="InformationBox"/> for the first string, the second string for the help file name, and the third one for the help topic id</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxButtons"/></term>
        ///         <description>which buttons to display on the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxIcon"/></term>
        ///         <description>which predefined icon to use for the <see cref="InformationBoxIcon"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Drawing.Icon"/></term>
        ///         <description>the icon to use for the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxDefaultButton"/></term>
        ///         <description>which button to set as default for the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.String"/>[]</term>
        ///         <description>the text for the custom buttons of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxBehavior"/></term>
        ///         <description>the modal/modeless state of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxButtonsLayout"/></term>
        ///         <description>the layout for the buttons of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxAutoSizeMode"/></term>
        ///         <description>how the <see cref="InformationBox"/> will resize itself according to the text.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxPosition"/></term>
        ///         <description>where the <see cref="InformationBox"/> will appear on the screen.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxOrder"/></term>
        ///         <description>how the <see cref="InformationBox"/> will appear on the screen compared to the other forms.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Boolean"/></term>
        ///         <description>whether the help button is displayed or not.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="System.Windows.Forms.HelpNavigator"/></term>
        ///         <description>the Help content. You can use the following values for navigator: TableOfContents, Find, Index, or Topic.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxCheckBox"/></term>
        ///         <description>whether the "Do not show this dialog again" checkbox is displayed or not.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="AutoCloseParameters"/></term>
        ///         <description>the parameters for the auto-close feature.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="DesignParameters"/></term>
        ///         <description>the parameters for the design (colors).</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxTitleIconStyle"/></term>
        ///         <description>which icon will be displayed in the title bar.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxTitleIcon"/></term>
        ///         <description>the custom icon that will be displayed in the title bar.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxOpacity"/></term>
        ///         <description>the opacity of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="AsyncResultCallback"/></term>
        ///         <description>a method that will be called when a modeless dialog is closed.</description>
        ///     </item>
        ///     <item>
        ///         <term>A MessageBox enum value</term>
        ///         <description>the value for the corresponding <see cref="InformationBox"/> enum value.</description>
        ///     </item>
        ///     <item>
        ///         <term>A Form instance</term>
        ///         <description>the parent of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term>A Form instance</term>
        ///         <description>the parent of the <see cref="InformationBox"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="InformationBoxOrder"/></term>
        ///         <description>how the <see cref="InformationBox"/> will appear on the screen compared to the other forms.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="checkBoxState">The final value of the "Do not show this dialog again" checkbox.</param>
        /// <param name="parameters">The parameters of the message box.</param>
        /// <returns>
        /// One of the <see cref="InformationBoxResult"/> values.
        /// </returns>
        public static InformationBoxResult Show(string text, out CheckState checkBoxState, params object[] parameters)
        {
            return new KryptonInformationBoxWindow(text, parameters).Show(out checkBoxState);
        }

        /// <summary>
        /// Displays a message box with the specified text and parameters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="checkBoxState">The final value of the "Do not show this dialog again" checkbox.</param>
        /// <param name="title">The title.</param>
        /// <param name="helpFile">The help file.</param>
        /// <param name="helpTopic">The help topic.</param>
        /// <param name="initialization">The initialization.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="customIcon">The custom icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="customButtons">The custom buttons.</param>
        /// <param name="buttonsLayout">The buttons layout.</param>
        /// <param name="autoSizeMode">The auto size mode.</param>
        /// <param name="position">The position.</param>
        /// <param name="showHelpButton">if set to <c>true</c> shows help button.</param>
        /// <param name="helpNavigator">The help navigator.</param>
        /// <param name="showDoNotShowAgainCheckBox">if set to <c>true</c> shows the do not show again check box.</param>
        /// <param name="style">The style.</param>
        /// <param name="autoClose">The auto close configuration.</param>
        /// <param name="design">The design.</param>
        /// <param name="titleStyle">The title style.</param>
        /// <param name="titleIcon">The title icon.</param>
        /// <param name="legacyButtons">The legacy buttons.</param>
        /// <param name="legacyIcon">The legacy icon.</param>
        /// <param name="legacyDefaultButton">The legacy default button.</param>
        /// <param name="behavior">The behavior.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="parentWindow">The parent <see cref="KryptonForm">window.</see></param>
        /// <param name="parent">The parent form.</param>
        /// <param name="order">The z-order</param>
        /// <param name="sound">The sound configuration</param>
        /// <returns>
        /// One of the <see cref="InformationBoxResult"/> values.
        /// </returns>
        public static InformationBoxResult Show(string text,
                                                out CheckState checkBoxState,
                                                string title = "",
                                                string helpFile = "",
                                                string helpTopic = "",
                                                InformationBoxInitialization initialization = InformationBoxInitialization.FromScopeAndParameters,
                                                InformationBoxButtons buttons = InformationBoxButtons.OK,
                                                InformationBoxIcon icon = InformationBoxIcon.None,
                                                Icon customIcon = null,
                                                InformationBoxDefaultButton defaultButton = InformationBoxDefaultButton.Button1,
                                                string[] customButtons = null,
                                                InformationBoxButtonsLayout buttonsLayout = InformationBoxButtonsLayout.GroupMiddle,
                                                InformationBoxAutoSizeMode autoSizeMode = InformationBoxAutoSizeMode.None,
                                                InformationBoxPosition position = InformationBoxPosition.CenterOnParent,
                                                bool showHelpButton = false,
                                                HelpNavigator helpNavigator = HelpNavigator.TableOfContents,
                                                InformationBoxCheckBox showDoNotShowAgainCheckBox = 0,
                                                InformationBoxStyle style = InformationBoxStyle.Standard,
                                                AutoCloseParameters autoClose = null,
                                                DesignParameters design = null,
                                                InformationBoxTitleIconStyle titleStyle = InformationBoxTitleIconStyle.None,
                                                InformationBoxTitleIcon titleIcon = null,
                                                MessageBoxButtons? legacyButtons = null,
                                                MessageBoxIcon? legacyIcon = null,
                                                MessageBoxDefaultButton? legacyDefaultButton = null,
                                                InformationBoxBehavior behavior = InformationBoxBehavior.Modal,
                                                AsyncResultCallback callback = null,
                                                InformationBoxOpacity opacity = InformationBoxOpacity.NoFade,
                                                KryptonForm parentWindow = null,
                                                Form parent = null,
                                                InformationBoxOrder order = InformationBoxOrder.Default,
                                                InformationBoxSound sound = InformationBoxSound.Default)
        {
            var parameters = new object[]{ title, helpFile, helpTopic, initialization, buttons, icon, customIcon, defaultButton,
                 customButtons, buttonsLayout, autoSizeMode, position, showHelpButton, helpNavigator, showDoNotShowAgainCheckBox,
                 style, autoClose, design, titleStyle, titleIcon, legacyButtons, legacyIcon, legacyDefaultButton, behavior, callback, opacity, parentWindow, parent, order, sound };

            return new KryptonInformationBoxWindow(text, parameters).Show(out checkBoxState);
        }

        #endregion Show
    }
}