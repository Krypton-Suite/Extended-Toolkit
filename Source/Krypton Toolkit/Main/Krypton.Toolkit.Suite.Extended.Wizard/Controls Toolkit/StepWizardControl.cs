#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Wizard control that shows a step summary on the left of the wizard page area.
    /// </summary>
    [ProvideProperty("StepText", typeof(WizardPage))]
    [ProvideProperty("StepTextIndentLevel", typeof(WizardPage))]
    [ToolboxItem(true), ToolboxBitmap(typeof(StepWizardControl), "Resources\\StepWizardControl.bmp")]
    [Description("Wizard control that shows a step summary on the left of the wizard page area.")]
    public class StepWizardControl : WizardControl, IExtenderProvider
    {
        private StepList list;
        private Splitter splitter;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepWizardControl"/> class.
        /// </summary>
        public StepWizardControl()
        {
            var ds = RightToLeft == RightToLeft.Yes ? DockStyle.Right : DockStyle.Left;
            pageContainer.Controls.Add(splitter = new Splitter() { Dock = ds, BorderStyle = BorderStyle.FixedSingle, Width = 1, Name = "splitter" });
            pageContainer.Controls.Add(list = new StepList() { Dock = ds, Name = "stepList" });
            list.DrawItem += list_DrawItem;
            list.MeasureItem += list_MeasureItem;
            Pages.Reset += Pages_Reset;
        }

        /// <summary>
        /// Occurs when a visual aspect of an owner-drawn StepList changes.
        /// </summary>
        [Category("Appearance")]
        public event EventHandler<DrawStepListItemEventArgs> DrawStepListItem;

        /// <summary>
        /// Occurs when an owner-drawn StepList is created and the sizes of the list items are determined.
        /// </summary>
        [Category("Appearance")]
        public event EventHandler<MeasureStepListItemEventArgs> MeasureStepListItem;

        /// <summary>
        /// Gets or sets a value indicating whether the StepWizardControl step list is drawn by the operating system or by code that you provide.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the StepWizardControl step list is drawn by code that you provide; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Appearance"), Description("Indicates if step list items are drawn by owner.")]
        public bool OwnerDrawStepList
        {
            get { return list.OwnerDraw; }
            set { list.OwnerDraw = value; }
        }

        /// <summary>
        /// Gets or sets the StepList font.
        /// </summary>
        /// <value>
        /// The StepList font.
        /// </value>
        [Category("Appearance"), Description("Font for drawing StepList.")]
        public Font StepListFont
        {
            get { return list.Font; }
            set { list.Font = value; }
        }

        /// <summary>
        /// Gets or sets the width of the step list.
        /// </summary>
        /// <value>
        /// The width of the step list.
        /// </value>
        [DefaultValue(150), Category("Appearance"), Description("Determines width of step list on left.")]
        public int StepListWidth
        {
            get { return list.Width; }
            set { list.Width = value; }
        }

        /// <summary>
        /// Gets the step text.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Step text for the specified wizard page.</returns>
        [DefaultValue((string)null), Category("Appearance"), Description("Alternate text to provide to the StepList. Default value comes the Text property of the WizardPage.")]
        public string GetStepText(WizardPage page) => list.GetStepText(page);

        /// <summary>
        /// Gets the step text indent level.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Step text indent level for the specified wizard page.</returns>
        [DefaultValue(0), Category("Appearance"), Description("Indentation level for text provided to the StepList.")]
        public int GetStepTextIndentLevel(WizardPage page) => list.GetStepTextIndentLevel(page);

        /// <summary>
        /// Specifies whether this object can provide its extender properties to the specified object.
        /// </summary>
        /// <param name="extendee">The <see cref="T:System.Object" /> to receive the extender properties.</param>
        /// <returns>
        /// true if this object can provide extender properties to the specified object; otherwise, false.
        /// </returns>
        bool IExtenderProvider.CanExtend(object extendee) => (extendee is WizardPage);

        /// <summary>
        /// Sets the step text.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The value.</param>
        public void SetStepText(WizardPage page, string value)
        {
            list.SetStepText(page, value);
        }

        /// <summary>
        /// Sets the step text indent level.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The indent level.</param>
        public void SetStepTextIndentLevel(WizardPage page, int value)
        {
            list.SetStepTextIndentLevel(page, value);
        }

        /// <summary>
        /// Raises the <see cref="E:AeroWizard.StepWizardControl.DrawStepListItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DrawStepListItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDrawStepListItem(DrawStepListItemEventArgs e)
        {
            var h = DrawStepListItem;
            if (h != null)
                h(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:AeroWizard.StepWizardControl.MeasureStepListItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MeasureStepListItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMeasureStepListItem(MeasureStepListItemEventArgs e)
        {
            var h = MeasureStepListItem;
            if (h != null)
                h(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.RightToLeftChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            var ds = RightToLeft == RightToLeft.Yes ? DockStyle.Right : DockStyle.Left;
            if (pageContainer.Controls.Count > 1)
            {
                pageContainer.Controls["splitter"].Dock = ds;
                pageContainer.Controls["stepList"].Dock = ds;
            }
        }

        private void list_DrawItem(object sender, DrawStepListItemEventArgs e)
        {
            OnDrawStepListItem(e);
        }

        private void list_MeasureItem(object sender, MeasureStepListItemEventArgs e)
        {
            OnMeasureStepListItem(e);
        }

        void Pages_Reset(object sender, System.Collections.Generic.EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            pageContainer.Controls.Add(splitter);
            pageContainer.Controls.Add(list);
        }

        private void ResetStepListFont()
        {
            list.Font = Font;
        }

        private void ResetStepText(WizardPage page)
        {
            SetStepText(page, null);
        }

        private bool ShouldSerializeStepListFont() => Font != list.Font;

        private bool ShouldSerializeStepText(WizardPage page) => (GetStepText(page) != page.Text);
    }