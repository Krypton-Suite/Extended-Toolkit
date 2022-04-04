#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ARGBUserControl : UserControl
    {
        #region Designer Code
        private KryptonAlphaValueNumericBox avnbValue;
        private KryptonBlueValueNumericBox bvnbValue;
        private KryptonGreenValueNumericBox gvnbValue;
        private KryptonRedValueNumericBox rvnbValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;

        private void InitializeComponent()
        {
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.rvnbValue = new KryptonRedValueNumericBox();
            this.gvnbValue = new KryptonGreenValueNumericBox();
            this.bvnbValue = new KryptonBlueValueNumericBox();
            this.avnbValue = new KryptonAlphaValueNumericBox();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(8, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(58, 24);
            this.kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Alpha:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(8, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(59, 24);
            this.kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Green:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(8, 100);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(48, 24);
            this.kryptonLabel3.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Blue:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(8, 38);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(44, 24);
            this.kryptonLabel4.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "Red:";
            // 
            // rvnbValue
            // 
            this.rvnbValue.DecimalPlaces = 99;
            this.rvnbValue.Location = new System.Drawing.Point(71, 37);
            this.rvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rvnbValue.Name = "rvnbValue";
            this.rvnbValue.Size = new System.Drawing.Size(120, 26);
            this.rvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.rvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.rvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.rvnbValue.TabIndex = 3;
            // 
            // gvnbValue
            // 
            this.gvnbValue.DecimalPlaces = 99;
            this.gvnbValue.Location = new System.Drawing.Point(71, 69);
            this.gvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.gvnbValue.Name = "gvnbValue";
            this.gvnbValue.Size = new System.Drawing.Size(120, 26);
            this.gvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.gvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.gvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.gvnbValue.TabIndex = 2;
            // 
            // bvnbValue
            // 
            this.bvnbValue.DecimalPlaces = 99;
            this.bvnbValue.Location = new System.Drawing.Point(71, 101);
            this.bvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bvnbValue.Name = "bvnbValue";
            this.bvnbValue.Size = new System.Drawing.Size(120, 26);
            this.bvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.bvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.bvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.bvnbValue.TabIndex = 1;
            // 
            // avnbValue
            // 
            this.avnbValue.DecimalPlaces = 99;
            this.avnbValue.Location = new System.Drawing.Point(71, 5);
            this.avnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.avnbValue.Name = "avnbValue";
            this.avnbValue.Size = new System.Drawing.Size(120, 26);
            this.avnbValue.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.avnbValue.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.avnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.avnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.avnbValue.TabIndex = 0;
            // 
            // ARGBUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.rvnbValue);
            this.Controls.Add(this.gvnbValue);
            this.Controls.Add(this.bvnbValue);
            this.Controls.Add(this.avnbValue);
            this.Name = "ARGBUserControl";
            this.Size = new System.Drawing.Size(198, 128);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private decimal _alphaValue, _redValue, _greenValue, _blueValue;
        #endregion


        #region Constructors
        public ARGBUserControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}