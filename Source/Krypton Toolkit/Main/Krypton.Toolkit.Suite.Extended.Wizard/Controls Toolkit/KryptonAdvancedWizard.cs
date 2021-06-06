namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// AdvancedWizard is a wizard control for the .Net platform
    /// </summary>
    [DefaultProperty("Pages")]
    [DefaultEvent("Finish")]
    [ToolboxBitmap(typeof(Bitmap))]
    [Designer(typeof(AdvancedWizardDesigner))]
    public partial class KryptonAdvancedWizard : UserControl, IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            throw new NotImplementedException();
        }
    }
}
