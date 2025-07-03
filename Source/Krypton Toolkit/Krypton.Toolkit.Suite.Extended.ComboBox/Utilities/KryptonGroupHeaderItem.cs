using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.ComboBox;

internal class KryptonGroupHeaderItem
{
    #region Public

    public string HeaderText { get; }

    #endregion

    #region Identity

    public KryptonGroupHeaderItem(string headerText)
    {
        HeaderText = headerText ?? throw new ArgumentNullException(nameof(headerText));
    }

    #endregion

    #region Overrides

    public override string ToString() => HeaderText;

    #endregion
}