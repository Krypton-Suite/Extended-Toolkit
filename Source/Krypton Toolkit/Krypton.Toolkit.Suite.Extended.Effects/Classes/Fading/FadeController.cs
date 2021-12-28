#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    /// <summary>Handles the fading effects. Original library: (https://gist.github.com/nathan-fiscaletti/3c0514862fe88b5664b10444e1098778)</summary>
    public class FadeController
    {
        #region Variables
        private readonly KryptonForm form;                                           // The form to modify the opacity of.
        private readonly KryptonForm parentForm;                                     // The parent form if being displayed as a dialog.
        private FadeDirection fadeDirection;                                         // The direction in which to fade.
        private float fadeSpeed;                                                     // The speed at which to fade.
        private FadeCompleted fadeFinished;                                          // The delegate to call when a fade has completed.
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
        private FadeController(KryptonForm form) => this.form = form;

        /// <summary>
        /// Construct a FadeController object with a form and a parent form.
        /// </summary>
        private FadeController(KryptonForm form, KryptonForm parent) : this(form) => parentForm = parent;
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
                case FadeDirection.IN:
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
                case FadeDirection.OUT:
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
        private async System.Threading.Tasks.Task<DialogResult> ShowDialog(float fadeSpeed, FadeCompleted finished)
        {
            parentForm.BeginInvoke(new Action(() => showDialogResult.SetResult(form.ShowDialog(parentForm))));

            fadeFinished = finished;
            form.Opacity = 0;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.IN;
            BeginFade();

            return await showDialogResult.Task;
        }

        /// <summary>
        /// Fade the form in at the defined speed.
        /// </summary>
        private void FadeIn(float fadeSpeed, FadeCompleted finished)
        {
            form.Opacity = 0;
            form.Show();

            fadeFinished = finished;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.IN;

            BeginFade();
        }

        private void FadeIn(FadeSpeedChoice fadeSpeedChoice, FadeCompleted finished, float fadeSpeed = 0)
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

            fadeDirection = FadeDirection.IN;

            BeginFade();
        }

        /// <summary>
        /// Fade the form out at the defined speed.
        /// </summary>
        private void FadeOut(float fadeSpeed, FadeCompleted finished)
        {
            if (form.Opacity < 0.1)
            {
                finished?.Invoke();
                return;
            }

            fadeFinished = finished;
            form.Opacity = 100;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.OUT;

            BeginFade();
        }

        private void FadeOut(FadeSpeedChoice fadeSpeedChoice, FadeCompleted finished, float fadeSpeed = 0)
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

            fadeDirection = FadeDirection.OUT;

            BeginFade();
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed.
        /// </summary>
        public static async System.Threading.Tasks.Task<DialogResult> ShowDialog(KryptonForm form, KryptonForm parent, float fadeSpeed)
        {
            FadeController fader = new FadeController(form, parent);
            return await fader.ShowDialog(fadeSpeed, null);
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed
        /// and call the finished delegate.)
        /// </summary>
        public static async System.Threading.Tasks.Task<DialogResult> ShowDialog(KryptonForm form, KryptonForm parent, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form, parent);
            return await fader.ShowDialog(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(KryptonForm form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form);
            fader.FadeIn(fadeSpeed, finished);
        }

        public static void FadeIn(KryptonForm form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted finished = null)
        {
            FadeController fader = new FadeController(form);

            fader.FadeIn(fadeSpeedChoice, finished, fadeSpeed);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(KryptonForm form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form);
            fader.FadeOut(fadeSpeed, finished);
        }

        public static void FadeOut(KryptonForm form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted finished = null)
        {
            FadeController fader = new FadeController(form);

            fader.FadeOut(fadeSpeedChoice, finished, fadeSpeed);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(KryptonForm form, float fadeSpeed)
        {
            FadeController fader = new FadeController(form);
            fader.FadeIn(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(KryptonForm form, float fadeSpeed)
        {
            FadeController fader = new FadeController(form);
            fader.FadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// </summary>
        public static void FadeOutAndClose(KryptonForm form, float fadeSpeed)
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
        public static void FadeOutAndClose(KryptonForm form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form)
            {
                shouldClose = true
            };
            fader.FadeOut(fadeSpeed, finished);
        }

        public static void FadeOutAndClose(KryptonForm form, FadeSpeedChoice fadeSpeedChoice, float fadeSpeed = 0, FadeCompleted finished = null)
        {
            FadeController fader = new FadeController(form) { shouldClose = true };

            fader.FadeOut(fadeSpeedChoice, finished, fadeSpeed);
        }
        #endregion
    }

    public class FadeControllerNETCoreSafe
    {
        #region Variables
        private float _fadeIn, _fadeOut;

        private int _fadeSpeed;
        #endregion

        #region Properties
        public float FadeIn { get => _fadeIn; set => _fadeIn = value; }

        public float FadeOut { get => _fadeOut; set => _fadeOut = value; }

        public int FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }
        #endregion

        #region Constructor
        public FadeControllerNETCoreSafe(float fadeIn, float fadeOut, int fadeSpeed)
        {
            _fadeIn = fadeIn;

            _fadeOut = fadeOut;

            _fadeSpeed = fadeSpeed;
        }

        public FadeControllerNETCoreSafe()
        {

        }
        #endregion

        #region Methods
        /// <summary>Fades the window in. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        public async void FadeWindowIn(KryptonForm owner)
        {
            // The window is not visible, so fade it in
            while (owner.Opacity <= 1.0)
            {
                await Task.Delay(_fadeSpeed);

                owner.Opacity += 0.05;
            }

            // Now, the window is fully visible
            owner.Opacity = 1;
        }

        public static void FadeWindowInExtended(KryptonForm owner, int fadeSpeed)
        {
            FadeControllerNETCoreSafe controller = new FadeControllerNETCoreSafe();

            for (controller._fadeIn = 0.0f; controller._fadeIn <= 1.1f; controller._fadeIn += 0.1f)
            {
                owner.Opacity = controller._fadeIn;

                owner.Refresh();

                Thread.Sleep(fadeSpeed);
            }
        }

        public static void FadeWindowOutExtended(KryptonForm owner, int fadeSpeed)
        {
            FadeControllerNETCoreSafe controller = new FadeControllerNETCoreSafe();

            for (controller._fadeOut = 90; controller._fadeOut >= 10; controller._fadeOut += 10)
            {
                owner.Opacity = controller._fadeOut / 100;

                owner.Refresh();

                Thread.Sleep(fadeSpeed);
            }
        }

        /// <summary>Fades the window out. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public async void FadeWindowOut(KryptonForm owner, KryptonForm nextWindow = null)
        {
            // The window is visible, so fade it out
            while (owner.Opacity > 0.0)
            {
                await Task.Delay(_fadeSpeed);

                owner.Opacity -= 0.05;
            }

            // Now, the window is invisible
            owner.Opacity = 0;

            // Move on to the next window if necessary
            if (nextWindow != null)
            {
                nextWindow.Show();
            }
        }
        #endregion
    }
}