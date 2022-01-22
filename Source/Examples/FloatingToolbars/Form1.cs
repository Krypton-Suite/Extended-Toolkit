using Krypton.Toolkit;

namespace FloatingToolbars
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnFloatableMenuStrip_Click(object sender, System.EventArgs e)
        {
            Form2 form = new Form2();

            form.Show();
        }

        private void kbtnFloatableToolStrip_Click(object sender, System.EventArgs e)
        {
            Form3 form = new Form3();

            form.Show();
        }
    }
}
