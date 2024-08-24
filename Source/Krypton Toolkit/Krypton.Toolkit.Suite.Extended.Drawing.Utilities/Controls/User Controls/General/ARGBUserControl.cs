#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ArgbUserControl : UserControl
    {
        #region Designer Code
        private KryptonAlphaValueNumericBox _avnbValue;
        private KryptonBlueValueNumericBox _bvnbValue;
        private KryptonGreenValueNumericBox _gvnbValue;
        private KryptonRedValueNumericBox _rvnbValue;
        private Krypton.Toolkit.KryptonLabel _kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel _kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel _kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel _kryptonLabel4;

        private void InitializeComponent()
        {
            this._kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this._kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this._kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this._kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this._rvnbValue = new KryptonRedValueNumericBox();
            this._gvnbValue = new KryptonGreenValueNumericBox();
            this._bvnbValue = new KryptonBlueValueNumericBox();
            this._avnbValue = new KryptonAlphaValueNumericBox();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this._kryptonLabel1.Location = new System.Drawing.Point(8, 5);
            this._kryptonLabel1.Name = "_kryptonLabel1";
            this._kryptonLabel1.Size = new System.Drawing.Size(58, 24);
            this._kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel1.TabIndex = 4;
            this._kryptonLabel1.Values.Text = "Alpha:";
            // 
            // kryptonLabel2
            // 
            this._kryptonLabel2.Location = new System.Drawing.Point(8, 71);
            this._kryptonLabel2.Name = "_kryptonLabel2";
            this._kryptonLabel2.Size = new System.Drawing.Size(59, 24);
            this._kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel2.TabIndex = 5;
            this._kryptonLabel2.Values.Text = "Green:";
            // 
            // kryptonLabel3
            // 
            this._kryptonLabel3.Location = new System.Drawing.Point(8, 100);
            this._kryptonLabel3.Name = "_kryptonLabel3";
            this._kryptonLabel3.Size = new System.Drawing.Size(48, 24);
            this._kryptonLabel3.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel3.TabIndex = 6;
            this._kryptonLabel3.Values.Text = "Blue:";
            // 
            // kryptonLabel4
            // 
            this._kryptonLabel4.Location = new System.Drawing.Point(8, 38);
            this._kryptonLabel4.Name = "_kryptonLabel4";
            this._kryptonLabel4.Size = new System.Drawing.Size(44, 24);
            this._kryptonLabel4.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this._kryptonLabel4.TabIndex = 7;
            this._kryptonLabel4.Values.Text = "Red:";
            // 
            // rvnbValue
            // 
            this._rvnbValue.DecimalPlaces = 99;
            this._rvnbValue.Location = new System.Drawing.Point(71, 37);
            this._rvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._rvnbValue.Name = "_rvnbValue";
            this._rvnbValue.Size = new System.Drawing.Size(120, 26);
            this._rvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this._rvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this._rvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._rvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this._rvnbValue.TabIndex = 3;
            // 
            // gvnbValue
            // 
            this._gvnbValue.DecimalPlaces = 99;
            this._gvnbValue.Location = new System.Drawing.Point(71, 69);
            this._gvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._gvnbValue.Name = "_gvnbValue";
            this._gvnbValue.Size = new System.Drawing.Size(120, 26);
            this._gvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this._gvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this._gvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._gvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this._gvnbValue.TabIndex = 2;
            // 
            // bvnbValue
            // 
            this._bvnbValue.DecimalPlaces = 99;
            this._bvnbValue.Location = new System.Drawing.Point(71, 101);
            this._bvnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._bvnbValue.Name = "_bvnbValue";
            this._bvnbValue.Size = new System.Drawing.Size(120, 26);
            this._bvnbValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this._bvnbValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this._bvnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._bvnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this._bvnbValue.TabIndex = 1;
            // 
            // avnbValue
            // 
            this._avnbValue.DecimalPlaces = 99;
            this._avnbValue.Location = new System.Drawing.Point(71, 5);
            this._avnbValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._avnbValue.Name = "_avnbValue";
            this._avnbValue.Size = new System.Drawing.Size(120, 26);
            this._avnbValue.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this._avnbValue.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this._avnbValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._avnbValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this._avnbValue.TabIndex = 0;
            // 
            // ARGBUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._kryptonLabel4);
            this.Controls.Add(this._kryptonLabel3);
            this.Controls.Add(this._kryptonLabel2);
            this.Controls.Add(this._kryptonLabel1);
            this.Controls.Add(this._rvnbValue);
            this.Controls.Add(this._gvnbValue);
            this.Controls.Add(this._bvnbValue);
            this.Controls.Add(this._avnbValue);
            this.Name = "ArgbUserControl";
            this.Size = new System.Drawing.Size(198, 128);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private decimal _alphaValue, _redValue, _greenValue, _blueValue;
        #endregion

        #region Public

        public decimal AlphaValue
        {
            get => _alphaValue; set => _alphaValue = value;
        }

        public decimal RedValue
        {
            get => _redValue; set => _redValue = value;
        }

        public decimal GreenValue
        {
            get => _greenValue; set => _greenValue = value;
        }

        public decimal BlueValue
        {
            get => _blueValue; set => _blueValue = value;
        }

        #endregion

        #region Constructors
        public ArgbUserControl()
        {
            InitializeComponent();

            _alphaValue = 255;

            _redValue = 255;

            _greenValue = 255;

            _blueValue = 255;
        }
        #endregion
    }
}