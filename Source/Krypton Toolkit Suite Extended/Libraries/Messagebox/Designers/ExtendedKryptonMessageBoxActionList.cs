using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class ExtendedKryptonMessageBoxActionList : DesignerActionList
    {
        private ExtendedKryptonMessageBoxDesigner extendedKryptonMessageBoxDesigner;

        public ExtendedKryptonMessageBoxActionList(ExtendedKryptonMessageBoxDesigner extendedKryptonMessageBoxDesigner)
        {
            this.extendedKryptonMessageBoxDesigner = extendedKryptonMessageBoxDesigner;
        }
    }
}