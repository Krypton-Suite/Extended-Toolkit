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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>Handles the fading effects. Original library: (https://gist.github.com/nathan-fiscaletti/3c0514862fe88b5664b10444e1098778)</summary>
    public class FadeController
    {
        #region Variables
        private readonly KryptonFormExtended form;                                           // The form to modify the opacity of.
        private readonly KryptonFormExtended parentForm;                                     // The parent form if being displayed as a dialog.
        private FadeDirection fadeDirection;                                         // The direction in which to fade.
        private float fadeSpeed;                                                     // The speed at which to fade.
        private FadeCompleted? fadeFinished;                                          // The delegate to call when a fade has completed.
        private bool shouldClose;                                                    // If set to true, the form will close after fading out.
        private readonly System.Threading.Tasks.TaskCompletionSource<DialogResult> showDialogResult         // The Async Task Completion Source for displaying as a dialog.
            = new System.Threading.Tasks.TaskCompletionSource<DialogResult>();
        #endregion

        #region Delegate
        public delegate void FadeCompleted();
        #endregion

        #region Constructors
        /// <summary>
        /// Construct the FadeController object with a form.
        /// </summary>
        private FadeController(KryptonFormExtended form) => this.form = form;

        /// <summary>
        /// Construct a FadeController object with a form and a parent form.
        /// </summary>
        private FadeController(KryptonFormExtended form, KryptonFormExtended parent) : this(form) => parentForm = parent;
        #endregion

        #region Methods
        /// <summary>
        /// Begin fading the form.
        /// </summary>
        private void BeginFade()
        {
            UpdateOpacity();
            fadeFinished?.Invoke();
        }

        /// <summary>
        /// Update the opacity of the form using the timer.
        /// </summary>
        private void UpdateOpacity()
        {
            if (form.IsDisposed)
            {
                return;
            }

            switch (fadeDirection)
            {
                // Fade in
                case FadeDirection.In:
                    if (form.Opacity < 1.0)
                    {
                        form.Opacity += (fadeSpeed / 1000.0);
                    }
                    else
                    {
                        return;
                    }

                    break;

                // Fade out
                case FadeDirection.Out:
                    if (form.Opacity > 0.1)
                    {
                        form.Opacity -= (fadeSpeed / 1000.0);
                    }
                    else
                    {
                        if (!shouldClose)
                        {
                            form.Hide();
                        }
                        else
                        {
                            form.Close();
                        }

                        return;
                    }
                    break;
            }

            // Have to use a thread sleep, rather than an await, otherwise on close would have completed as disposed on the first await Task.Delay()
            Thread.Sleep(10);
            UpdateOpacity();
        }

        /// <summary>
        /// Fade the form in at the defined speed as a dialog
        /// based on parent form.
        /// </summary>
        private async System.Threading.Tasks.Task<DialogResult> ShowDialog(float fadeSpeed, FadeCompleted? finished)
        {
            parentForm.BeginInvoke(new Action(() => showDialogResult.SetResult(form.ShowDialog(parentForm))));

            fadeFinished = finished;
            form.Opacity = 0;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;
            BeginFade();

            return await showDialogResult.Task;
        }

        /// <summary>
        /// Fade the form in at the defined speed.
        /// </summary>
        private void FadeIn(float fadeSpeed, FadeCompleted? finished)
        {
            form.Opacity = 0;
            form.Show();

            fadeFinished = finished;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;

            BeginFade();
        }

        private void FadeIn(FadeSpeedChoice fadeSpeedChoice, FadeCompleted? finished, float fadeSpeed = 0)
        {
            form.Opacity = 0;

            form.Show();

            fadeFinished = finished;

            switch (fadeSpeedChoice)
            {
                case FadeSpeedChoice.Slowest:
                    this.fadeSpeed = FadeSpeed.Slowest;
                    break;
                case FadeSpeedChoice.Slower:
                    this.fadeSpeed = FadeSpeed.Slower;
                    break;
                case FadeSpeedChoice.Slow:
                    this.fadeSpeed = FadeSpeed.Slow;
                    break;
                case FadeSpeedChoice.Normal:
                    this.fadeSpeed = FadeSpeed.Normal;
                    break;
                case FadeSpeedChoice.Fast:
                    this.fadeSpeed = FadeSpeed.Fast;
                    break;
                case FadeSpeedChoice.Faster:
                    this.fadeSpeed = FadeSpeed.Faster;
                    break;
                case FadeSpeedChoice.Fastest:
                    this.fadeSpeed = FadeSpeed.Fastest;
                    break;
                case FadeSpeedChoice.Custom:
                    this.fadeSpeed = fadeSpeed;
                    break;
            }

            fadeDirection = FadeDirection.In;

            BeginFade();
        }

        /// <summary>
        /// Fade the form out at the defined speed.
        /// </summary>
        private void FadeOut(float fadeSpeed, FadeCompleted? finished)
        {
            if (form.Opacity < 0.1)
            {
                finished?.Invoke();
                return;
            }

            fadeFinished = finished;
            form.Opacity = 100;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.Out;

            BeginFade();
        }

        private void FadeOut(FadeSpeedChoice fadeSpeedChoice, FadeCompleted? finished, float fadeSpeed = 0)
        {
            if (form.Opacity < 0.1)
            {
                finished?.Invoke();

                return;
            }

            fadeFinished = finished;

            form.Opacity = 100;

            switch (fadeSpeedChoice)
            {
                case FadeSpeedChoice.Slowest:
                    this.fadeSpeed = FadeSpeed.Slowest;
                    break;
                case FadeSpeedChoice.Slower:
                    this.fadeSpeed = FadeSpeed.Slower;
                    break;
                case FadeSpeedChoice.Slow:
                    this.fadeSpeed = FadeSpeed.Slow;
                    break;
                case FadeSpeedChoice.Normal:
                    this.fadeSpeed = FadeSpeed.Normal;
                    break;
                case FadeSpeedChoice.Fast:
                    this.fadeSpeed = FadeSpeed.Fast;
                    break;
                case FadeSpeedChoice.Faster:
                    this.fadeSpeed = FadeSpeed.Faster;
                    break;
                case FadeSpeedChoice.Fastest:
                    this.fadeSpeed = FadeSpeed.Fastest;
                    break;
                case FadeSpeedChoice.Custom:
                    this.fadeSpeed = fadeSpeed;
                    break;
            }

            fadeDirection = FadeDirection.Out;

            BeginFade();
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed.
        /// </summary>
        public static async Task<DialogResult> ShowDialog(KryptonFormExtended form, KryptonFormExtended parent, float fadeSpeed)
        {
            FadeController fader = new FadeController(form, parent);
            return await fader.ShowDialog(fadeSpeed, null);
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed
        /// and call the finished delegate.)
        /// </summary>
        public static async Task<DialogResult> ShowDialog(KryptonFormExtended form, KryptonFormExtended parent, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form, parent);
            return await fader.ShowDialog(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(KryptonFormExtended form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form);
            fader.FadeIn(fadeSpeed, finished);
        }

        public static void FadeIn(KryptonFormExtended form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted? finished = null)
        {
            FadeController fader = new FadeController(form);

            fader.FadeIn(fadeSpeedChoice, finished, fadeSpeed);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(KryptonFormExtended form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form);
            fader.FadeOut(fadeSpeed, finished);
        }

        public static void FadeOut(KryptonFormExtended form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted? finished = null)
        {
            FadeController fader = new FadeController(form);

            fader.FadeOut(fadeSpeedChoice, finished, fadeSpeed);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(KryptonFormExtended form, float fadeSpeed)
        {
            FadeController fader = new FadeController(form);
            fader.FadeIn(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(KryptonFormExtended form, float fadeSpeed)
        {
            FadeController fader = new FadeController(form);
            fader.FadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// </summary>
        public static void FadeOutAndClose(KryptonFormExtended form, float fadeSpeed)
        {
            FadeController fader = new FadeController(form)
            {
                shouldClose = true
            };
            fader.FadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// After the form has closed, call the FadeComplete delegate.
        /// </summary>
        public static void FadeOutAndClose(KryptonFormExtended form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form)
            {
                shouldClose = true
            };
            fader.FadeOut(fadeSpeed, finished);
        }

        public static void FadeOutAndClose(KryptonFormExtended form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted? finished = null)
        {
            FadeController fader = new FadeController(form) { shouldClose = true };

            fader.FadeOut(fadeSpeedChoice, finished, fadeSpeed);
        }
        #endregion
    }
}