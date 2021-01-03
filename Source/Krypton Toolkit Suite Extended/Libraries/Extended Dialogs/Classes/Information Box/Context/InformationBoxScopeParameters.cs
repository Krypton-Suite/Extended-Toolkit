#region License
// <copyright file="InformationBoxScopeParameters.cs" company="Johann Blais">
// Copyright (c) 2008 All Right Reserved
// </copyright>
// <author>Johann Blais</author>
// <summary>Contains the parameters used by a specific scope</summary>
#endregion

using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Contains the parameters used by a specific scope.
    /// </summary>
    [DebuggerStepThrough]
    public struct InformationBoxScopeParameters
    {
        #region Properties

        /// <summary>
        /// Gets or sets the auto close.
        /// </summary>
        /// <value>The auto close.</value>
        public AutoCloseParameters AutoClose { get; set; }

        /// <summary>
        /// Gets or sets the auto size mode.
        /// </summary>
        /// <value>The auto size mode.</value>
        public InformationBoxAutoSizeMode? AutoSizeMode { get; set; }

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        /// <value>The behavior.</value>
        public InformationBoxBehavior? Behavior { get; set; }

        /// <summary>
        /// Gets or sets the buttons.
        /// </summary>
        /// <value>The buttons.</value>
        public InformationBoxButtons? Buttons { get; set; }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        /// <value>The layout.</value>
        public InformationBoxButtonsLayout? Layout { get; set; }

        /// <summary>
        /// Gets or sets the checkbox.
        /// </summary>
        /// <value>The checkbox.</value>
        public InformationBoxCheckBox? CheckBox { get; set; }

        /// <summary>
        /// Gets or sets the default button.
        /// </summary>
        /// <value>The default button.</value>
        public InformationBoxDefaultButton? DefaultButton { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The main icon.</value>
        public InformationBoxIcon? Icon { get; set; }

        /// <summary>
        /// Gets or sets the title icon.
        /// </summary>
        /// <value>The title icon.</value>
        public Icon TitleIcon { get; set; }

        /// <summary>
        /// Gets or sets the custom icon.
        /// </summary>
        /// <value>The custom icon.</value>
        public Icon CustomIcon { get; set; }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public InformationBoxOpacity? Opacity { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public InformationBoxPosition? Position { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public InformationBoxStyle? Style { get; set; }

        /// <summary>
        /// Gets or sets the title icon style.
        /// </summary>
        /// <value>The title icon style.</value>
        public InformationBoxTitleIconStyle? TitleIconStyle { get; set; }

        /// <summary>
        /// Gets or sets the help.
        /// </summary>
        /// <value>The help value.</value>
        public bool? Help { get; set; }

        /// <summary>
        /// Gets or sets the help navigator.
        /// </summary>
        /// <value>The help navigator.</value>
        public HelpNavigator? HelpNavigator { get; set; }

        /// <summary>
        /// Gets or sets the design.
        /// </summary>
        /// <value>The design.</value>
        public DesignParameters Design { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public InformationBoxOrder? Order { get; set; }

        /// <summary>
        /// Gets or sets the sound.
        /// </summary>
        /// <value>The sound.</value>
        public InformationBoxSound? Sound { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Merges the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The result of the merge operation </returns>
        public InformationBoxScopeParameters Merge(InformationBoxScopeParameters parameters)
        {
            if (parameters.Icon.HasValue && !this.Icon.HasValue)
            {
                this.Icon = parameters.Icon.Value;
            }

            if (parameters.CustomIcon != null && null == this.CustomIcon)
            {
                this.CustomIcon = parameters.CustomIcon;
            }

            if (parameters.Buttons.HasValue && !this.Buttons.HasValue)
            {
                this.Buttons = parameters.Buttons.Value;
            }

            if (parameters.DefaultButton.HasValue && !this.DefaultButton.HasValue)
            {
                this.DefaultButton = parameters.DefaultButton.Value;
            }

            if (parameters.Layout.HasValue && !this.Layout.HasValue)
            {
                this.Layout = parameters.Layout.Value;
            }

            if (parameters.AutoSizeMode.HasValue && !this.AutoSizeMode.HasValue)
            {
                this.AutoSizeMode = parameters.AutoSizeMode.Value;
            }

            if (parameters.Position.HasValue && !this.Position.HasValue)
            {
                this.Position = parameters.Position.Value;
            }

            if (parameters.CheckBox.HasValue && !this.CheckBox.HasValue)
            {
                this.CheckBox = parameters.CheckBox.Value;
            }

            if (parameters.Style.HasValue && !this.Style.HasValue)
            {
                this.Style = parameters.Style.Value;
            }

            if (parameters.AutoClose != null && null == this.AutoClose)
            {
                this.AutoClose = parameters.AutoClose;
            }

            if (parameters.Design != null && null == this.Design)
            {
                this.Design = parameters.Design;
            }

            if (parameters.TitleIconStyle.HasValue && !this.TitleIconStyle.HasValue)
            {
                this.TitleIconStyle = parameters.TitleIconStyle.Value;
            }

            if (parameters.TitleIcon != null && null == this.TitleIcon)
            {
                this.TitleIcon = parameters.TitleIcon;
            }

            if (parameters.Behavior.HasValue && !this.Behavior.HasValue)
            {
                this.Behavior = parameters.Behavior.Value;
            }

            if (parameters.Opacity.HasValue && !this.Opacity.HasValue)
            {
                this.Opacity = parameters.Opacity.Value;
            }

            if (parameters.Help.HasValue && !this.Help.HasValue)
            {
                this.Help = parameters.Help.Value;
            }

            if (parameters.HelpNavigator.HasValue && !this.HelpNavigator.HasValue)
            {
                this.HelpNavigator = parameters.HelpNavigator.Value;
            }

            if (parameters.Order.HasValue && !this.Order.HasValue)
            {
                this.Order = parameters.Order.Value;
            }

            if (parameters.Sound.HasValue && !this.Sound.HasValue)
            {
                this.Sound = parameters.Sound.Value;
            }

            return this;
        }

        #endregion Methods

        #region Overrides

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }

            if (!(obj is InformationBoxScopeParameters))
            {
                return false;
            }

            InformationBoxScopeParameters compared = (InformationBoxScopeParameters)obj;

            return this.AutoClose == compared.AutoClose &&
                   this.AutoSizeMode == compared.AutoSizeMode &&
                   this.Behavior == compared.Behavior &&
                   this.Buttons == compared.Buttons &&
                   this.CheckBox == compared.CheckBox &&
                   this.CustomIcon == compared.CustomIcon &&
                   this.DefaultButton == compared.DefaultButton &&
                   this.Design == compared.Design &&
                   this.Help == compared.Help &&
                   this.HelpNavigator == compared.HelpNavigator &&
                   this.Icon == compared.Icon &&
                   this.Layout == compared.Layout &&
                   this.Opacity == compared.Opacity &&
                   this.Order == compared.Order &&
                   this.Position == compared.Position &&
                   this.Sound == compared.Sound &&
                   this.Style == compared.Style &&
                   this.TitleIcon == compared.TitleIcon &&
                   this.TitleIconStyle == compared.TitleIconStyle;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode ^= this.AutoClose == null ? 0 : this.AutoClose.GetHashCode();
            hashCode ^= this.AutoSizeMode == null ? 0 : this.AutoSizeMode.GetHashCode();
            hashCode ^= this.Behavior == null ? 0 : this.Behavior.GetHashCode();
            hashCode ^= this.Buttons == null ? 0 : this.Buttons.GetHashCode();
            hashCode ^= this.CheckBox == null ? 0 : this.CheckBox.GetHashCode();
            hashCode ^= this.CustomIcon == null ? 0 : this.CustomIcon.GetHashCode();
            hashCode ^= this.DefaultButton == null ? 0 : this.DefaultButton.GetHashCode();
            hashCode ^= this.Design == null ? 0 : this.Design.GetHashCode();
            hashCode ^= this.Help == null ? 0 : this.Help.GetHashCode();
            hashCode ^= this.HelpNavigator == null ? 0 : this.HelpNavigator.GetHashCode();
            hashCode ^= this.Icon == null ? 0 : this.Icon.GetHashCode();
            hashCode ^= this.Layout == null ? 0 : this.Layout.GetHashCode();
            hashCode ^= this.Opacity == null ? 0 : this.Opacity.GetHashCode();
            hashCode ^= this.Order == null ? 0 : this.Order.GetHashCode();
            hashCode ^= this.Position == null ? 0 : this.Position.GetHashCode();
            hashCode ^= this.Sound == null ? 0 : this.Sound.GetHashCode();
            hashCode ^= this.Style == null ? 0 : this.Style.GetHashCode();
            hashCode ^= this.TitleIcon == null ? 0 : this.TitleIcon.GetHashCode();
            hashCode ^= this.TitleIconStyle == null ? 0 : this.TitleIconStyle.GetHashCode();

            return hashCode;
        }

        #endregion Overrides

        #region Operators

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="parameter1">The first parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(InformationBoxScopeParameters parameter1, InformationBoxScopeParameters parameter2)
        {
            return parameter1.Equals(parameter2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(InformationBoxScopeParameters parameter1, InformationBoxScopeParameters parameter2)
        {
            return !(parameter1 == parameter2);
        }

        #endregion Operators
    }
}