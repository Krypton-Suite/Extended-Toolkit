namespace Krypton.Toolkit.Suite.Extended.Forms;

public class FadeControllerNETCoreSafe
{
    #region Variables

    private float _fadeIn, _fadeOut;

    private int _fadeSpeed;

    #endregion

    #region Properties

    public float FadeIn
    {
        get => _fadeIn;
        set => _fadeIn = value;
    }

    public float FadeOut
    {
        get => _fadeOut;
        set => _fadeOut = value;
    }

    public int FadeSpeed
    {
        get => _fadeSpeed;
        set => _fadeSpeed = value;
    }

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
    public async void FadeWindowIn(KryptonFormExtended owner)
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

    public static void FadeWindowInExtended(KryptonFormExtended owner, int fadeSpeed)
    {
        FadeControllerNETCoreSafe controller = new FadeControllerNETCoreSafe();

        for (controller._fadeIn = 0.0f; controller._fadeIn <= 1.1f; controller._fadeIn += 0.1f)
        {
            owner.Opacity = controller._fadeIn;

            owner.Refresh();

            Thread.Sleep(fadeSpeed);
        }
    }

    public static void FadeWindowOutExtended(KryptonFormExtended owner, int fadeSpeed)
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
    public async void FadeWindowOut(KryptonFormExtended owner, KryptonFormExtended? nextWindow = null)
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