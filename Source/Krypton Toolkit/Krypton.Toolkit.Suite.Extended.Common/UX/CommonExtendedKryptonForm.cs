#region MIT License
/*
 *
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

using Krypton.Toolkit.Suite.Extended.Effects;

namespace Krypton.Toolkit.Suite.Extended.Common;

public class CommonExtendedKryptonForm : KryptonForm
{
    #region Variables
    private float _fadeSpeed;

    private FadeSpeedChoice _fadeSpeedChoice;
    #endregion

    #region Properties
    public bool UseBlur { get; set; }

    [DefaultValue(true), Description("")]
    public bool UseFade { get; set; }

    [DefaultValue(50), Description("")]
    public int SleepInterval { get; set; }

    [DefaultValue(0), Description("")]
    public float FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

    [DefaultValue(typeof(FadeSpeedChoice), "FadeSpeedChoice.Normal"), Description("")]
    public FadeSpeedChoice FadeSpeedChoice { get => _fadeSpeedChoice; set => _fadeSpeedChoice = value; }
    #endregion

    #region Identity
    public CommonExtendedKryptonForm()
    {
        UseBlur = false;

        UseFade = true;

        SleepInterval = 50;

        _fadeSpeedChoice = FadeSpeedChoice.Normal;
    }
    #endregion

    #region Overrides
    protected override void OnLoad(EventArgs e)
    {
        if (UseFade)
        {
#if NETCOREAPP3_1_OR_GREATER
                FadeControllerNETCoreSafe.FadeWindowInExtended(this, SleepInterval);
#else
            FadeController.FadeIn(this, FadeSpeed);
#endif
        }

        BlurValues.BlurWhenFocusLost = UseBlur;

        base.OnLoad(e);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (UseFade)
        {
#if NETCOREAPP3_1_OR_GREATER
                FadeControllerNETCoreSafe.FadeWindowOutExtended(this, SleepInterval);
#else
            FadeController.FadeOutAndClose(this, _fadeSpeed);
#endif
        }

        base.OnFormClosing(e);
    }
    #endregion

    private void FadeInComplete() { }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // CommonExtendedKryptonForm
        // 
        this.ClientSize = new System.Drawing.Size(284, 261);
        this.Name = "CommonExtendedKryptonForm";
        this.ResumeLayout(false);

    }
}