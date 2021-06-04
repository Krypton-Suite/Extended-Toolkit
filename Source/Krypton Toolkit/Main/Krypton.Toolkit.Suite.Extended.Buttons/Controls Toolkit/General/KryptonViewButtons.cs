namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxItem(true), ToolboxBitmap(typeof(KryptonButton))]
    public partial class KryptonViewButtons : UserControl
    {
        #region Design Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kcmdPercentage = new Krypton.Toolkit.KryptonButton();
            this.kcmdmiddleright = new Krypton.Toolkit.KryptonCheckButton();
            this.kcmdmiddleleft = new Krypton.Toolkit.KryptonCheckButton();
            this.kcheckset = new Krypton.Toolkit.KryptonCheckSet(this.components);
            this.kcmdleft = new Krypton.Toolkit.KryptonCheckButton();
            this.kcmdright = new Krypton.Toolkit.KryptonCheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.kcheckset)).BeginInit();
            this.SuspendLayout();
            // 
            // kcmdPercentage
            // 
            this.kcmdPercentage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kcmdPercentage.ButtonStyle = Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kcmdPercentage.Location = new System.Drawing.Point(77, 0);
            this.kcmdPercentage.Name = "kcmdPercentage";
            this.kcmdPercentage.Size = new System.Drawing.Size(40, 18);
            this.kcmdPercentage.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-4);
            this.kcmdPercentage.TabIndex = 14;
            this.kcmdPercentage.Values.Text = "100%";
            // 
            // kcmdmiddleright
            // 
            this.kcmdmiddleright.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kcmdmiddleright.Location = new System.Drawing.Point(37, 0);
            this.kcmdmiddleright.Name = "kcmdmiddleright";
            this.kcmdmiddleright.Size = new System.Drawing.Size(17, 18);
            this.kcmdmiddleright.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom)));
            this.kcmdmiddleright.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2, -3, -4, -4);
            this.kcmdmiddleright.TabIndex = 13;
            this.kcmdmiddleright.Values.Text = "";
            // 
            // kcmdmiddleleft
            // 
            this.kcmdmiddleleft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kcmdmiddleleft.Location = new System.Drawing.Point(19, 0);
            this.kcmdmiddleleft.Name = "kcmdmiddleleft";
            this.kcmdmiddleleft.Size = new System.Drawing.Size(17, 18);
            this.kcmdmiddleleft.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom)));
            this.kcmdmiddleleft.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2, -3, -4, -4);
            this.kcmdmiddleleft.TabIndex = 12;
            this.kcmdmiddleleft.Values.Text = "";
            // 
            // kcheckset
            // 
            this.kcheckset.AllowUncheck = true;
            this.kcheckset.CheckButtons.Add(this.kcmdmiddleright);
            this.kcheckset.CheckButtons.Add(this.kcmdmiddleleft);
            this.kcheckset.CheckButtons.Add(this.kcmdleft);
            this.kcheckset.CheckButtons.Add(this.kcmdright);
            this.kcheckset.CheckedButton = this.kcmdright;
            // 
            // kcmdleft
            // 
            this.kcmdleft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kcmdleft.Location = new System.Drawing.Point(0, 0);
            this.kcmdleft.Name = "kcmdleft";
            this.kcmdleft.Size = new System.Drawing.Size(18, 18);
            this.kcmdleft.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)(((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.kcmdleft.TabIndex = 11;
            this.kcmdleft.Values.Text = "";
            // 
            // kcmdright
            // 
            this.kcmdright.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kcmdright.Checked = true;
            this.kcmdright.Location = new System.Drawing.Point(55, 0);
            this.kcmdright.Name = "kcmdright";
            this.kcmdright.Size = new System.Drawing.Size(18, 18);
            this.kcmdright.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)(((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kcmdright.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2, -3, -4, -4);
            this.kcmdright.TabIndex = 10;
            this.kcmdright.Values.Text = "";
            // 
            // KryptonViewButtons
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kcmdPercentage);
            this.Controls.Add(this.kcmdmiddleright);
            this.Controls.Add(this.kcmdmiddleleft);
            this.Controls.Add(this.kcmdleft);
            this.Controls.Add(this.kcmdright);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "KryptonViewButtons";
            this.Size = new System.Drawing.Size(117, 18);
            ((System.ComponentModel.ISupportInitialize)(this.kcheckset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal KryptonCheckSet kcheckset;
        public KryptonButton kcmdPercentage;
        public KryptonCheckButton kcmdmiddleright;
        public KryptonCheckButton kcmdmiddleleft;
        public KryptonCheckButton kcmdleft;
        public KryptonCheckButton kcmdright;
        #endregion

        private string _percentageLabel = "100%";
        [Category("ViewButtons"), DefaultValue(typeof(string), "100%")]
        public string PercentageLabel
        {
            get { return _percentageLabel; }
            set
            {
                this.kcmdPercentage.Text = value;
                _percentageLabel = value;
                Invalidate();
            }
        }


        public KryptonViewButtons()
        {
            InitializeComponent();
            //(1) To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            //Set Back Color
            this.BackColor = System.Drawing.Color.Transparent;

            //Set Label Text
            this.kcmdPercentage.Text = _percentageLabel;
        }




    }
}