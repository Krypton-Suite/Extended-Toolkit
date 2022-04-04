namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// winforms and wpf have different means of taking screenshots, hence this abstraction
    /// </summary>
    public interface IScreenShooter
    {
        /// <summary />
        /// <returns></returns>
        string TakeScreenShot();
    }
}