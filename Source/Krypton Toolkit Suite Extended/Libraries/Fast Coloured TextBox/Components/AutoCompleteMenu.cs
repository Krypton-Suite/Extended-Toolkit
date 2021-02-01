#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Popup menu for autocomplete
    /// </summary>
    [Browsable(false)]
    public class AutoCompleteMenu : ToolStripDropDown, IDisposable
    {
        AutoCompleteListView listView;
        public ToolStripControlHost host;
        public Range Fragment { get; internal set; }

        /// <summary>
        /// Regex pattern for serach fragment around caret
        /// </summary>
        public string SearchPattern { get; set; }
        /// <summary>
        /// Minimum fragment length for popup
        /// </summary>
        public int MinFragmentLength { get; set; }
        /// <summary>
        /// User selects item
        /// </summary>
        public event EventHandler<SelectingEventArgs> Selecting;
        /// <summary>
        /// It fires after item inserting
        /// </summary>
        public event EventHandler<SelectedEventArgs> Selected;
        /// <summary>
        /// Occurs when popup menu is opening
        /// </summary>
        public new event EventHandler<CancelEventArgs> Opening;
        /// <summary>
        /// Allow TAB for select menu item
        /// </summary>
        public bool AllowTabKey { get { return listView.AllowTabKey; } set { listView.AllowTabKey = value; } }
        /// <summary>
        /// Interval of menu appear (ms)
        /// </summary>
        public int AppearInterval { get { return listView.AppearInterval; } set { listView.AppearInterval = value; } }
        /// <summary>
        /// Sets the max tooltip window size
        /// </summary>
        public Size MaxTooltipSize { get { return listView.MaxToolTipSize; } set { listView.MaxToolTipSize = value; } }
        /// <summary>
        /// Tooltip will perm show and duration will be ignored
        /// </summary>
        public bool AlwaysShowTooltip { get { return listView.AlwaysShowTooltip; } set { listView.AlwaysShowTooltip = value; } }

        /// <summary>
        /// Back color of selected item
        /// </summary>
        [DefaultValue(typeof(Color), "Orange")]
        public Color SelectedColour
        {
            get { return listView.SelectedColour; }
            set { listView.SelectedColour = value; }
        }

        /// <summary>
        /// Border color of hovered item
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        public Color HoveredColour
        {
            get { return listView.HoveredColour; }
            set { listView.HoveredColour = value; }
        }

        public AutoCompleteMenu(FastColouredTextBox tb)
        {
            // create a new popup and add the list view to it 
            AutoClose = false;
            AutoSize = false;
            Margin = Padding.Empty;
            Padding = Padding.Empty;
            BackColor = Color.White;
            listView = new AutoCompleteListView(tb);
            host = new ToolStripControlHost(listView);
            host.Margin = new Padding(2, 2, 2, 2);
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.AutoToolTip = false;
            CalcSize();
            base.Items.Add(host);
            listView.Parent = this;
            SearchPattern = @"[\w\.]";
            MinFragmentLength = 2;

        }

        public new Font Font
        {
            get { return listView.Font; }
            set { listView.Font = value; }
        }

        new internal void OnOpening(CancelEventArgs args)
        {
            if (Opening != null)
                Opening(this, args);
        }

        public new void Close()
        {
            listView.toolTip.Hide(listView);
            base.Close();
        }

        internal void CalcSize()
        {
            host.Size = listView.Size;
            Size = new System.Drawing.Size(listView.Size.Width + 4, listView.Size.Height + 4);
        }

        public virtual void OnSelecting()
        {
            listView.OnSelecting();
        }

        public void SelectNext(int shift)
        {
            listView.SelectNext(shift);
        }

        internal void OnSelecting(SelectingEventArgs args)
        {
            if (Selecting != null)
                Selecting(this, args);
        }

        public void OnSelected(SelectedEventArgs args)
        {
            if (Selected != null)
                Selected(this, args);
        }

        public new AutoCompleteListView Items
        {
            get { return listView; }
        }

        /// <summary>
        /// Shows popup menu immediately
        /// </summary>
        /// <param name="forced">If True - MinFragmentLength will be ignored</param>
        public void Show(bool forced)
        {
            Items.DoAutocomplete(forced);
        }

        /// <summary>
        /// Minimal size of menu
        /// </summary>
        public new Size MinimumSize
        {
            get { return Items.MinimumSize; }
            set { Items.MinimumSize = value; }
        }

        /// <summary>
        /// Image list of menu
        /// </summary>
        public new ImageList ImageList
        {
            get { return Items.ImageList; }
            set { Items.ImageList = value; }
        }

        /// <summary>
        /// Tooltip duration (ms)
        /// </summary>
        public int ToolTipDuration
        {
            get { return Items.ToolTipDuration; }
            set { Items.ToolTipDuration = value; }
        }

        /// <summary>
        /// Tooltip
        /// </summary>
        public ToolTip ToolTip
        {
            get { return Items.toolTip; }
            set { Items.toolTip = value; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (listView != null && !listView.IsDisposed)
                listView.Dispose();
        }
    }
}