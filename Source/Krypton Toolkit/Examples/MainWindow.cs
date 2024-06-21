namespace Examples
{
    public partial class MainWindow : KryptonForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kbtnButtonItems_Click(object sender, EventArgs e)
        {
            var buttonItems = new ButtonItems();

            buttonItems.Show();
        }

        private void ktnToolStripItems_Click(object sender, EventArgs e)
        {
            var tsi = new ToolStripItems();

            tsi.Show();
        }

        private void kbtnCalendarItems_Click(object sender, EventArgs e)
        {
            var calendar = new CalendarItems();

            calendar.Show();
        }

        private void kbtnCircularProgressBarItem_Click(object sender, EventArgs e)
        {
            var circularProgressBar = new CircularProgressBarExample();

            circularProgressBar.Show();
        }

        private void kbtnCheckSum_Click(object sender, EventArgs e)
        {
            var checkSum = new CheckSumExample();

            checkSum.Show();
        }

        private void kbtnExtendedControls_Click(object sender, EventArgs e)
        {
            var extendedControlExamples = new ExtendedControlExamples();

            extendedControlExamples.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            var messageBoxExample = new MessageBoxExample();

            messageBoxExample.Show();
        }

        private void kbtnFloating_Click(object sender, EventArgs e)
        {
            var floating = new FloatingMenuToolbarExampleMain();

            floating.Show();
        }

        private void kbtnKryptonFormExtendedExample_Click(object sender, EventArgs e)
        {
            var kryptonFormExtended = new KryptonFormExtended1();

            kryptonFormExtended.Show();
        }

        private void kbtnDialogExamples_Click(object sender, EventArgs e)
        {
            var dialogExamples = new DialogExamples();

            dialogExamples.Show();
        }

        private void kbtnInputBoxExamples_Click(object sender, EventArgs e)
        {
            var example = new KryptonInputBoxExtendedExample();

            example.Show();
        }

        private void kbtnTreeGridViewExample_Click(object sender, EventArgs e)
        {
            TreeGridViewExample treeGridView = new();

            treeGridView.Show();
        }

        private void kbtnTreeGridView2Example_Click(object sender, EventArgs e)
        {
            var treeGridViewAdvanced = new TreeGridViewAdvancedExample();

            treeGridViewAdvanced.Show();
        }

        private void kbtnAdvancedDataGridExample_Click(object sender, EventArgs e)
        {
            var advancedDataGrid = new AdvancedDataGridView();

            advancedDataGrid.Show();
        }

        private void kbtnDockExtenderExample_Click(object sender, EventArgs e)
        {
            var dockExtenderExample = new DockExtenderExample();

            dockExtenderExample.Show();
        }

        private void kbtnThemeTools_Click(object sender, EventArgs e)
        {
            ThemeTools themeTools = new();

            themeTools.Show();
        }

        private void kbtnRibbonExtended_Click(object sender, EventArgs e)
        {
            var ribbonExtendedExample = new KryptonRibbonExtendedExample();

            ribbonExtendedExample.Show();
        }

        private void kbtnMemoryBoxExample_Click(object sender, EventArgs e)
        {
            var memoryBoxExample = new MemoryBoxExample();

            memoryBoxExample.Show();
        }

        private void kbtnProgressBars_Click(object sender, EventArgs e)
        {
            var progressBarExtendedExamples = new KryptonProgressBarExtendedExamples();

            progressBarExtendedExamples.Show();
        }

        private void kbtnCheckBoxComboBoxExample_Click(object sender, EventArgs e)
        {
            var example = new CheckBoxComboBoxTest();

            example.Show();
        }

        private void kbtnNotificationExample_Click(object sender, EventArgs e)
        {

        }

        private void kbtnControls_Click(object sender, EventArgs e)
        {
            var controls = new ExtendedControlExamples();

            controls.Show();
        }
    }
}