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

namespace Krypton.Toolkit.Suite.Extended.Tool.Box;

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