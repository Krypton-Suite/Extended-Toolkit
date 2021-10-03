#region BSD License
/*
 *
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 *
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// WizardDesigner:
    /// 
    /// Primarily allows design-time navigation through the wizard buttons.
    /// 
    /// Allows common operations to be performed through a verb menu, either by 
    /// right-clicking or the section underneath the property grid;
    /// 
    /// Ensures buttons are enabled/disabled correctly depending on the circumstances;
    /// 
    /// Implements a number of designer-related interfaces to control adding and
    /// removing pages from the AdvancedWizard control;
    /// 
    /// Assigned to the AdvancedWizard through the [Designer(typeof(WizardDesigner))]
    /// attribute;
    /// </summary>
    internal class AdvancedWizardDesigner : ParentControlDesigner
    {
        public override DesignerVerbCollection Verbs => _verbs ?? (_verbs = new DesignerVerbCollection { new DesignerVerb("New WizardPage", OnVerbNew), new DesignerVerb("Prev WizardPage", OnVerbPrev), new DesignerVerb("Next WizardPage", OnVerbNext), new DesignerVerb("About", OnVerbAbout) });

        public override void Initialize(IComponent c)
        {
            base.Initialize(c);
            GetReferenceToWizardControl(c);
            GetReferenceToIDesignerHost();
            GetReferenceToIComponentChangeService();
            GetReferenceToISelectionService();
            InitializeWizardControl();
            InitializeDesigner();
        }

        protected override void Dispose(bool disposing)
        {
            _changeService.ComponentAdded -= ChangeServiceComponentAdded;
            _changeService.ComponentRemoved -= ChangeServiceComponentRemoved;

            base.Dispose(disposing);
        }

        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
        }

        protected override bool GetHitTest(Point point)
        {
            Point clientPoint = Control.PointToClient(point);
            UpdateMenuCommands();
            return _wizard.UserClickedAButtonAtDesignTime(clientPoint);
        }

        protected void UpdateMenuCommands()
        {
            if (_wizard.WizardPages.Count > 1)
            {
                if (_wizard.IndexOfCurrentPage() == _wizard.WizardPages.Count - 1)
                {
                    Verbs[1].Enabled = true;
                    Verbs[2].Enabled = false;
                }
                else
                {
                    if (_wizard.IndexOfCurrentPage() == 0)
                    {
                        Verbs[1].Enabled = false;
                        Verbs[2].Enabled = true;
                    }
                    else
                    {
                        Verbs[1].Enabled = true;
                        Verbs[2].Enabled = true;
                    }
                }
            }
            else
            {
                Verbs[VerbPrevious].Enabled = false;
                Verbs[VerbNext].Enabled = false;
            }
        }

        private void OnVerbPrev(object sender, EventArgs e)
        {
            if (!_wizard.WizardHasNoPages() && _wizard.IndexOfCurrentPage() > 0)
            {
                _wizard.ClickBack();
                Verbs[VerbNext].Enabled = true;
                if (_wizard.OnFirstPage())
                    Verbs[VerbPrevious].Enabled = false;
            }
        }

        private void OnVerbNext(object sender, EventArgs e)
        {
            if (((KryptonAdvancedWizard)Control).WizardPages.Count > 0)
            {
                _wizard.ClickNext();
                Verbs[VerbPrevious].Enabled = true;
                if (_wizard.OnLastPage())
                    Verbs[VerbNext].Enabled = false;
            }
        }

        private static void OnVerbAbout(object sender, EventArgs e) => MessageBox.Show("Written by Steve Bate", "About AdvancedWizard", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void OnVerbNew(object sender, EventArgs e)
        {
            try
            {
                _designer.CreateComponent(typeof(KryptonAdvancedWizardPage));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitializeWizardControl() => _wizard.AllowDrop = false;

        private void InitializeDesigner() => DrawGrid = false;

        private void GetReferenceToWizardControl(IComponent c) => _wizard = ((Control)c as KryptonAdvancedWizard);

        private void GetReferenceToIDesignerHost() => _designer = (IDesignerHost)GetService(typeof(IDesignerHost));

        private void GetReferenceToISelectionService() => _selectionService = (ISelectionService)GetService(typeof(ISelectionService));

        private void SelectPageInProperyGrid(KryptonAdvancedWizardPage page) => _selectionService.SetSelectedComponents(new object[] { page }, SelectionTypes.MouseDown);

        private void GetReferenceToIComponentChangeService()
        {
            _changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (_changeService == null) return;
            _changeService.ComponentAdded += ChangeServiceComponentAdded;
            _changeService.ComponentRemoved += ChangeServiceComponentRemoved;
        }

        private void UpdateWizard(KryptonAdvancedWizardPage page)
        {
            _wizard.SelectWizardPage(page);
            _wizard.SetButtonStates();
        }

        private static void DisplayPage(KryptonAdvancedWizardPage page)
        {
            page.Dock = DockStyle.Fill;
            page.BringToFront();
        }

        private void AddPageToContainers(KryptonAdvancedWizardPage page)
        {
            _wizard.WizardPages.Add(page);
            _wizard.Controls.Add(page);
        }

        private void ChangeServiceComponentAdded(object sender, ComponentEventArgs e)
        {
            if (((IDesignerHost)sender).Loading) return;
            if (!(e.Component is KryptonAdvancedWizardPage)) return;
            var page = e.Component as KryptonAdvancedWizardPage;
            if (_wizard.WizardPages.Contains(page)) return;

            AddPageToContainers(page);
            DisplayPage(page);
            SelectPageInProperyGrid(page);
            UpdateWizard(page);
        }

        private void ChangeServiceComponentRemoved(object sender, ComponentEventArgs e)
        {
            if (((IDesignerHost)sender).Loading) return;
            var advancedWizardPage = e.Component as KryptonAdvancedWizardPage;
            if (advancedWizardPage == null) return;

            _wizard.WizardPages.Remove(advancedWizardPage);
            _wizard.SelectPreviousPage();
            _wizard.SetButtonStates();
        }

        private IComponentChangeService _changeService;
        private IDesignerHost _designer;
        private ISelectionService _selectionService;
        private DesignerVerbCollection _verbs;
        private KryptonAdvancedWizard _wizard;
        private const int VerbPrevious = 1;
        private const int VerbNext = 2;
    }
}