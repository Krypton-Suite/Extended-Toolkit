#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    public delegate void TabSelectionChangedHandler(ToolBoxTab sender, EventArgs e);
    public delegate void TabMouseEventHandler(ToolBoxTab sender, MouseEventArgs e);
    public delegate void ItemSelectionChangedHandler(ToolBoxItem sender, EventArgs e);
    public delegate void ItemMouseEventHandler(ToolBoxItem sender, MouseEventArgs e);
    public delegate void ItemKeyEventHandler(ToolBoxItem sender, KeyEventArgs e);
    public delegate void ItemKeyPressEventHandler(ToolBoxItem sender, KeyPressEventArgs e);
    public delegate void DragDropFinishedHandler(ToolBoxItem sender, DragDropEffects e);
    public delegate void RenameFinishedHandler(ToolBoxItem sender, ToolBoxRenameFinishedEventArgs e);
    public delegate void XmlSerializerHandler(ToolBoxItem sender, ToolBoxXmlSerializationEventArgs e);
    public delegate void PreDragDropHandler(ToolBoxItem sender, ToolBoxPreDragDropEventArgs e);

    public delegate void LayoutFinished();
}