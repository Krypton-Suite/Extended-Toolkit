namespace TestApp
{
    public partial class FloatingMenuToolbarExampleMain : KryptonForm
    {
        public FloatingMenuToolbarExampleMain()
        {
            InitializeComponent();
        }

        private void kbtnFloatingAdvanced_Click(object sender, EventArgs e)
        {
            FloatingMenuToolbarAdvancedExample floatingMenuToolbarAdvanced = new FloatingMenuToolbarAdvancedExample();

            floatingMenuToolbarAdvanced.Show();
        }
    }
}
