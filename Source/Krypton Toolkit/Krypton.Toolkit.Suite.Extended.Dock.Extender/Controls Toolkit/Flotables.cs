using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Dock.Extender;

public class Flotables : List<IFloatable>
{
    #region Implementation

    public IFloatable? FindFloatables(Control control)
    {
        foreach (KryptonFloatableForm floatable in this.Cast<KryptonFloatableForm>())
        {
            if (floatable.DockState.Container != null && floatable.DockState.Container.Equals(control))
            {
                return floatable;
            }
        }

        return null;
    }

    #endregion
}