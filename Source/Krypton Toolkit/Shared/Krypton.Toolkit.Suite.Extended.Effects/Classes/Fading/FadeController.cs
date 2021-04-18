using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    /// <summary>Handles the fading effects. Original library: https://gist.github.com/nathan-fiscaletti/3c0514862fe88b5664b10444e1098778.</summary>
    public class FadeController
    {
        #region Variables
        private readonly KryptonForm form;                                           // The form to modify the opacity of.
        private readonly KryptonForm parentForm;                                     // The parent form if being displayed as a dialog.
        private FadeDirection fadeDirection;                                         // The direction in which to fade.
        private float fadeSpeed;                                                     // The speed at which to fade.
        private FadeCompleted fadeFinished;                                          // The delegate to call when a fade has completed.
        private bool shouldClose;                                                    // If set to true, the form will close after fading out.
        private readonly TaskCompletionSource<DialogResult> showDialogResult         // The Async Task Completion Source for displaying as a dialog.
            = new TaskCompletionSource<DialogResult>();
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
                        form.Opacity += (fadeSpeed / 1000.0);
                    else
                        return;

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
                            form.Hide();
                        else
                            form.Close();

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
        private async Task<DialogResult> ShowDialog(float fadeSpeed, FadeCompleted finished)
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

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed.
        /// </summary>
        public static async Task<DialogResult> ShowDialog(KryptonForm form, KryptonForm parent, float fadeSpeed)
        {
            FadeController fader = new FadeController(form, parent);
            return await fader.ShowDialog(fadeSpeed, null);
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed
        /// and call the finished delegate.)
        /// </summary>
        public static async Task<DialogResult> ShowDialog(KryptonForm form, KryptonForm parent, float fadeSpeed, FadeCompleted finished)
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

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(KryptonForm form, float fadeSpeed, FadeCompleted finished)
        {
            FadeController fader = new FadeController(form);
            fader.FadeOut(fadeSpeed, finished);
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
        #endregion
    }
}