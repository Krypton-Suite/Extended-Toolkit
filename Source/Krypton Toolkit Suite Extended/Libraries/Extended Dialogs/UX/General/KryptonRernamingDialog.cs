namespace Krypton.Toolkit.Extended.Dialogs
{
    public enum ReplaceType
    {
        DIRECTORY,
        FILE
    }

    /*
    public class KryptonRernamingDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnRename;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtReplaceText;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel klblNewName;
        private KryptonLinkLabel klblCurrentName;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnRename = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.klblCurrentName = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblNewName = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtReplaceText = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnRename);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 168);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(566, 44);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(464, 7);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnRename
            // 
            this.kbtnRename.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnRename.Enabled = false;
            this.kbtnRename.Location = new System.Drawing.Point(368, 7);
            this.kbtnRename.Name = "kbtnRename";
            this.kbtnRename.Size = new System.Drawing.Size(90, 25);
            this.kbtnRename.TabIndex = 1;
            this.kbtnRename.Values.Text = "&Rename";
            this.kbtnRename.Click += new System.EventHandler(this.kbtnRename_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtReplaceText);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.klblNewName);
            this.kryptonPanel2.Controls.Add(this.klblCurrentName);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(566, 165);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Current Name:";
            // 
            // klblCurrentName
            // 
            this.klblCurrentName.Location = new System.Drawing.Point(108, 12);
            this.klblCurrentName.Name = "klblCurrentName";
            this.klblCurrentName.Size = new System.Drawing.Size(25, 20);
            this.klblCurrentName.TabIndex = 3;
            this.klblCurrentName.Values.Text = "{0}";
            this.klblCurrentName.LinkClicked += new System.EventHandler(this.klblCurrentName_LinkClicked);
            this.klblCurrentName.MouseHover += new System.EventHandler(this.klblCurrentName_MouseHover);
            // 
            // klblNewName
            // 
            this.klblNewName.Location = new System.Drawing.Point(12, 59);
            this.klblNewName.Name = "klblNewName";
            this.klblNewName.Size = new System.Drawing.Size(74, 20);
            this.klblNewName.TabIndex = 4;
            this.klblNewName.Values.Text = "New Name:";
            this.klblNewName.MouseHover += new System.EventHandler(this.klblNewName_MouseHover);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 106);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Replace With:";
            // 
            // ktxtReplaceText
            // 
            this.ktxtReplaceText.Hint = "Enter text...";
            this.ktxtReplaceText.Location = new System.Drawing.Point(108, 106);
            this.ktxtReplaceText.Name = "ktxtReplaceText";
            this.ktxtReplaceText.Size = new System.Drawing.Size(446, 23);
            this.ktxtReplaceText.TabIndex = 6;
            this.ktxtReplaceText.TextChanged += new System.EventHandler(this.ktxtReplaceText_TextChanged);
            // 
            // KryptonRernamingDialog
            // 
            this.ClientSize = new System.Drawing.Size(566, 212);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRernamingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonRernamingDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Variables
        private ReplaceType _replaceType;

        private string _currentName, _newName, _filePath;
        #endregion

        #region Properties
        public ReplaceType ReplaceType { get => _replaceType; set => _replaceType = value; }

        public string CurrentName { get => _currentName; private set => _currentName = value; }

        public string NewName { get => _newName; private set => _newName = value; }

        public string FilePath { get => _filePath; set => _filePath = value; }
        #endregion

        #region Constructors
        public KryptonRernamingDialog()
        {
            InitializeComponent();
        }

        public KryptonRernamingDialog(ReplaceType type)
        {
            InitializeComponent();

            AlterUI(type);
        }

        public KryptonRernamingDialog(string path)
        {
            InitializeComponent();

            FilePath = path;
        }

        public KryptonRernamingDialog(ReplaceType type, string path)
        {
            InitializeComponent();

            FilePath = path;

            AlterUI(type);
        }
        #endregion

        private void KryptonRernamingDialog_Load(object sender, EventArgs e)
        {

        }

        private void klblCurrentName_LinkClicked(object sender, EventArgs e)
        {

        }

        private void ktxtReplaceText_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbtnRename_Click(object sender, EventArgs e)
        {

        }

        private void klblCurrentName_MouseHover(object sender, EventArgs e)
        {

        }

        private void klblNewName_MouseHover(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        #region Methosd
        private void AlterUI(ReplaceType type)
        {
            ReplaceType = type;

            switch (type)
            {
                case ReplaceType.DIRECTORY:
                    break;
                case ReplaceType.FILE:
                    break;
                default:
                    break;
            }
        }

        private string Replace(string inputString, string existingString, string newString)
        {
            CurrentName = existingString;

            NewName = newString;

            string modified = Regex.Replace(existingString, newString);

            return modified;
        }
        #endregion
    }
    */
}