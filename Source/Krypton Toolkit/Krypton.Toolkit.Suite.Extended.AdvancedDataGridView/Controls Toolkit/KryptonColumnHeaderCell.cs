#region Original License
/*
 *
 * Microsoft Public License (Ms-PL)
 *
 * This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
 *
 * 1. Definitions 
 *
 * The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
 *
 * A "contribution" is the original software, or any additions or changes to the software.
 *
 * A "contributor" is any person that distributes its contribution under this license.
 *
 * "Licensed patents" are a contributor's patent claims that read directly on its contribution.
 *
 * 2. Grant of Rights
 *
 * (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
 *
 * (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
 *
 * 3. Conditions and Limitations
 *
 * (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
 *
 * (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
 *
 * (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
 *
 * (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
 *
 * (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
 *
 */
#endregion

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

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView
{
    internal class KryptonColumnHeaderCell : DataGridViewColumnHeaderCell
    {
        #region Instance Fields

        private Image _filterImage = Properties.Resources.ColumnHeader_UnFiltered;
        private Size _filterButtonImageSize = new Size(16, 16);
        private bool _filterButtonPressed = false;
        private bool _filterButtonOver = false;
        private Rectangle _filterButtonOffsetBounds = Rectangle.Empty;
        private Rectangle _filterButtonImageBounds = Rectangle.Empty;
        private Padding _filterButtonMargin = new Padding(3, 4, 3, 4);
        private bool _filterEnabled = false;

        /// <summary>
        /// Get the MenuStrip for this ColumnHeaderCell
        /// </summary>
        public MenuStrip MenuStrip { get; private set; }


        #endregion

        #region Constants

        /// <summary>
        /// Default behaviour for Date and Time filter
        /// </summary>
        private const bool FILTER_DATE_AND_TIME_DEFAULT_ENABLED = false;

        #endregion

        #region Events

        public event ColumnHeaderCellEventHandler FilterPopup;
        public event ColumnHeaderCellEventHandler SortChanged;
        public event ColumnHeaderCellEventHandler FilterChanged;

        #endregion

        #region Identity

        public KryptonColumnHeaderCell(DataGridViewColumnHeaderCell oldCell, bool filterEnabled) : base()
        {
            Tag = oldCell.Tag;

            ErrorText = oldCell.ErrorText;

            ToolTipText = oldCell.ToolTipText;

            Value = oldCell.Value;

            ValueType = oldCell.ValueType;

            ContextMenuStrip = oldCell.ContextMenuStrip;

            Style = oldCell.Style;

            _filterEnabled = filterEnabled;

            KryptonColumnHeaderCell? oldCellt = oldCell as KryptonColumnHeaderCell;
            if (oldCellt != null && oldCellt.MenuStrip != null)
            {
                MenuStrip = oldCellt.MenuStrip;
                _filterImage = oldCellt._filterImage;
                _filterButtonPressed = oldCellt._filterButtonPressed;
                _filterButtonOver = oldCellt._filterButtonOver;
                _filterButtonOffsetBounds = oldCellt._filterButtonOffsetBounds;
                _filterButtonImageBounds = oldCellt._filterButtonImageBounds;
                MenuStrip.FilterChanged += new EventHandler(MenuStrip_FilterChanged);
                MenuStrip.SortChanged += new EventHandler(MenuStrip_SortChanged);
            }
            else
            {
                MenuStrip = new MenuStrip(oldCell.OwningColumn.ValueType);
                MenuStrip.FilterChanged += new EventHandler(MenuStrip_FilterChanged);
                MenuStrip.SortChanged += new EventHandler(MenuStrip_SortChanged);
            }

            IsFilterDateAndTimeEnabled = FILTER_DATE_AND_TIME_DEFAULT_ENABLED;
            IsSortEnabled = true;
            IsFilterEnabled = true;
            IsFilterChecklistEnabled = true;
        }

        ~KryptonColumnHeaderCell()
        {
            if (MenuStrip != null)
            {
                MenuStrip.FilterChanged -= MenuStrip_FilterChanged;
                MenuStrip.SortChanged -= MenuStrip_SortChanged;
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Get or Set the Filter and Sort enabled status
        /// </summary>
        public bool FilterAndSortEnabled
        {
            get
            {
                return _filterEnabled;
            }
            set
            {
                if (!value)
                {
                    _filterButtonPressed = false;
                    _filterButtonOver = false;
                }

                if (value != _filterEnabled)
                {
                    _filterEnabled = value;
                    bool refreshed = false;
                    if (MenuStrip.FilterString.Length > 0)
                    {
                        MenuStrip_FilterChanged(this, new EventArgs());
                        refreshed = true;
                    }
                    if (MenuStrip.SortString.Length > 0)
                    {
                        MenuStrip_SortChanged(this, new EventArgs());
                        refreshed = true;
                    }
                    if (!refreshed)
                    {
                        RepaintCell();
                    }
                }
            }
        }

        /// <summary>
        /// Set or Unset the Filter and Sort to Loaded mode
        /// </summary>
        /// <param name="enabled"></param>
        public void SetLoadedMode(bool enabled)
        {
            MenuStrip.SetLoadedMode(enabled);
            RefreshImage();
            RepaintCell();
        }

        /// <summary>
        /// Clean Sort
        /// </summary>
        public void CleanSort()
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                MenuStrip.CleanSort();
                RefreshImage();
                RepaintCell();
            }
        }

        /// <summary>
        /// Clean Filter
        /// </summary>
        public void CleanFilter()
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                MenuStrip.CleanFilter();
                RefreshImage();
                RepaintCell();
            }
        }

        /// <summary>
        /// Sort ASC
        /// </summary>
        public void SortASC()
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                MenuStrip.SortAsc();
            }
        }

        /// <summary>
        /// Sort DESC
        /// </summary>
        public void SortDESC()
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                MenuStrip.SortDesc();
            }
        }

        /// <summary>
        /// Clone the ColumnHeaderCell
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new KryptonColumnHeaderCell(this, FilterAndSortEnabled);
        }

        /// <summary>
        /// Get the MenuStrip SortType
        /// </summary>
        public MenuStrip.SortType ActiveSortType
        {
            get
            {
                if (MenuStrip != null && FilterAndSortEnabled)
                {
                    return MenuStrip.ActiveSortType;
                }
                else
                {
                    return MenuStrip.SortType.None;
                }
            }
        }

        /// <summary>
        /// Get the MenuStrip FilterType
        /// </summary>
        public MenuStrip.FilterType ActiveFilterType
        {
            get
            {
                if (MenuStrip != null && FilterAndSortEnabled)
                {
                    return MenuStrip.ActiveFilterType;
                }
                else
                {
                    return MenuStrip.FilterType.None;
                }
            }
        }

        /// <summary>
        /// Get the Sort string
        /// </summary>
        public string? SortString
        {
            get
            {
                if (MenuStrip != null && FilterAndSortEnabled)
                {
                    return MenuStrip.SortString;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Get the Filter string
        /// </summary>
        public string? FilterString
        {
            get
            {
                if (MenuStrip != null && FilterAndSortEnabled)
                {
                    return MenuStrip.FilterString;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Get the Minimum size
        /// </summary>
        public Size MinimumSize
        {
            get
            {
                return new Size(_filterButtonImageSize.Width + _filterButtonMargin.Left + _filterButtonMargin.Right,
                    _filterButtonImageSize.Height + _filterButtonMargin.Bottom + _filterButtonMargin.Top);
            }
        }

        /// <summary>
        /// Get or Set the Sort enabled status
        /// </summary>
        public bool IsSortEnabled
        {
            get
            {
                return MenuStrip.IsSortEnabled;
            }
            set
            {
                MenuStrip.IsSortEnabled = value;
            }
        }

        /// <summary>
        /// Get or Set the Filter enabled status
        /// </summary>
        public bool IsFilterEnabled
        {
            get
            {
                return MenuStrip.IsFilterEnabled;
            }
            set
            {
                MenuStrip.IsFilterEnabled = value;
            }
        }

        /// <summary>
        /// Get or Set the Filter enabled status
        /// </summary>
        public bool IsFilterChecklistEnabled
        {
            get
            {
                return MenuStrip.IsFilterChecklistEnabled;
            }
            set
            {
                MenuStrip.IsFilterChecklistEnabled = value;
            }
        }

        /// <summary>
        /// Get or Set the FilterDateAndTime enabled status
        /// </summary>
        public bool IsFilterDateAndTimeEnabled
        {
            get
            {
                return MenuStrip.IsFilterDateAndTimeEnabled;
            }
            set
            {
                MenuStrip.IsFilterDateAndTimeEnabled = value;
            }
        }

        /// <summary>
        /// Get or Set the NOT IN logic for Filter
        /// </summary>
        public bool IsMenuStripFilterNOTINLogicEnabled
        {
            get
            {
                return MenuStrip.IsFilterNotinLogicEnabled;
            }
            set
            {
                MenuStrip.IsFilterNotinLogicEnabled = value;
            }
        }

        /// <summary>
        /// Set the text filter search nodes behaviour
        /// </summary>
        public bool DoesTextFilterRemoveNodesOnSearch
        {
            get
            {
                return MenuStrip.DoesTextFilterRemoveNodesOnSearch;
            }
            set
            {
                MenuStrip.DoesTextFilterRemoveNodesOnSearch = value;
            }
        }

        /// <summary>
        /// Number of nodes to enable the TextChanged delay on text filter
        /// </summary>
        public int TextFilterTextChangedDelayNodes
        {
            get
            {
                return MenuStrip.TextFilterTextChangedDelayNodes;
            }
            set
            {
                MenuStrip.TextFilterTextChangedDelayNodes = value;
            }
        }

        /// <summary>
        /// Enabled or disable Sort capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetSortEnabled(bool enabled)
        {
            if (MenuStrip != null)
            {
                MenuStrip.IsSortEnabled = enabled;
                MenuStrip.SetSortEnabled(enabled);
            }
        }

        /// <summary>
        /// Enable or disable Filter capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterEnabled(bool enabled)
        {
            if (MenuStrip != null)
            {
                MenuStrip.IsFilterEnabled = enabled;
                MenuStrip.SetFilterEnabled(enabled);
            }
        }

        /// <summary>
        /// Enable or disable Filter checklist capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterChecklistEnabled(bool enabled)
        {
            if (MenuStrip != null)
            {
                MenuStrip.IsFilterChecklistEnabled = enabled;
                MenuStrip.SetFilterChecklistEnabled(enabled);
            }
        }

        /// <summary>
        /// Set Filter checklist nodes max
        /// </summary>
        /// <param name="maxnodes"></param>
        public void SetFilterChecklistNodesMax(int maxnodes)
        {
            if (maxnodes >= 0)
            {
                MenuStrip.MaxChecklistNodes = maxnodes;
            }
        }

        /// <summary>
        /// Enable or disable Filter checklist nodes max
        /// </summary>
        /// <param name="enabled"></param>
        public void EnabledFilterChecklistNodesMax(bool enabled)
        {
            if (MenuStrip.MaxChecklistNodes == 0 && enabled)
            {
                MenuStrip.MaxChecklistNodes = MenuStrip.DefaultMaxChecklistNodes;
            }
            else if (MenuStrip.MaxChecklistNodes != 0 && !enabled)
            {
                MenuStrip.MaxChecklistNodes = 0;
            }
        }

        /// <summary>
        /// Enable or disable Filter custom capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterCustomEnabled(bool enabled)
        {
            if (MenuStrip != null)
            {
                MenuStrip.IsFilterCustomEnabled = enabled;
                MenuStrip.SetFilterCustomEnabled(enabled);
            }
        }

        /// <summary>
        /// Enable or disable Text filter on checklist remove node mode
        /// </summary>
        /// <param name="enabled"></param>
        public void SetChecklistTextFilterRemoveNodesOnSearchMode(bool enabled)
        {
            if (MenuStrip != null)
            {
                MenuStrip.SetChecklistTextFilterRemoveNodesOnSearchMode(enabled);
            }
        }

        /// <summary>
        /// Disable text filter TextChanged delay
        /// </summary>
        public void SetTextFilterTextChangedDelayNodesDisabled()
        {
            if (MenuStrip != null)
            {
                MenuStrip.SetTextFilterTextChangedDelayNodesDisabled();
            }
        }

        /// <summary>
        /// Set text filter TextChanged delay milliseconds
        /// </summary>
        public void SetTextFilterTextChangedDelayMs(int milliseconds)
        {
            if (MenuStrip != null)
            {
                MenuStrip.TextFilterTextChangedDelayMs = milliseconds;
            }
        }

        #endregion


        #region menustrip events

        /// <summary>
        /// OnFilterChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_FilterChanged(object sender, EventArgs e)
        {
            RefreshImage();
            RepaintCell();
            if (FilterAndSortEnabled && FilterChanged != null)
            {
                FilterChanged(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
            }
        }

        /// <summary>
        /// OnSortChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_SortChanged(object sender, EventArgs e)
        {
            RefreshImage();
            RepaintCell();
            if (FilterAndSortEnabled && SortChanged != null)
            {
                SortChanged(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
            }
        }

        /// <summary>
        /// Clean attached events
        /// </summary>
        public void CleanEvents()
        {
            MenuStrip.FilterChanged -= MenuStrip_FilterChanged;
            MenuStrip.SortChanged -= MenuStrip_SortChanged;
        }


        #endregion


        #region paint methods

        /// <summary>
        /// Repaint the Cell
        /// </summary>
        private void RepaintCell()
        {
            if (Displayed && DataGridView != null)
            {
                DataGridView.InvalidateCell(this);
            }
        }

        /// <summary>
        /// Refrash the Cell image
        /// </summary>
        private void RefreshImage()
        {
            if (ActiveFilterType == MenuStrip.FilterType.Loaded)
            {
                _filterImage = Properties.Resources.ColumnHeader_SavedFilters;
            }
            else
            {
                if (ActiveFilterType == MenuStrip.FilterType.None)
                {
                    if (ActiveSortType == MenuStrip.SortType.None)
                    {
                        _filterImage = Properties.Resources.ColumnHeader_UnFiltered;
                    }
                    else if (ActiveSortType == MenuStrip.SortType.Asc)
                    {
                        _filterImage = Properties.Resources.ColumnHeader_OrderedASC;
                    }
                    else
                    {
                        _filterImage = Properties.Resources.ColumnHeader_OrderedDESC;
                    }
                }
                else
                {
                    if (ActiveSortType == MenuStrip.SortType.None)
                    {
                        _filterImage = Properties.Resources.ColumnHeader_Filtered;
                    }
                    else if (ActiveSortType == MenuStrip.SortType.Asc)
                    {
                        _filterImage = Properties.Resources.ColumnHeader_FilteredAndOrderedASC;
                    }
                    else
                    {
                        _filterImage = Properties.Resources.ColumnHeader_FilteredAndOrderedDESC;
                    }
                }
            }
        }

        /// <summary>
        /// Pain method
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (SortGlyphDirection != SortOrder.None)
            {
                SortGlyphDirection = SortOrder.None;
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                cellState, value, formattedValue,
                errorText, cellStyle, advancedBorderStyle, paintParts);

            // Don't display a dropdown for Image columns
            if (OwningColumn.ValueType == typeof(Bitmap))
            {
                return;
            }

            if (FilterAndSortEnabled && paintParts.HasFlag(DataGridViewPaintParts.ContentBackground))
            {
                _filterButtonOffsetBounds = GetFilterBounds(true);
                _filterButtonImageBounds = GetFilterBounds(false);
                Rectangle buttonBounds = _filterButtonOffsetBounds;
                if (clipBounds.IntersectsWith(buttonBounds))
                {
                    ControlPaint.DrawBorder(graphics, buttonBounds, Color.Gray, ButtonBorderStyle.Solid);
                    buttonBounds.Inflate(-1, -1);
                    using (Brush b = new SolidBrush(_filterButtonOver ? Color.WhiteSmoke : Color.White))
                        graphics.FillRectangle(b, buttonBounds);
                    graphics.DrawImage(_filterImage, buttonBounds);
                }
            }
        }

        /// <summary>
        /// Get the ColumnHeaderCell Bounds
        /// </summary>
        /// <param name="withOffset"></param>
        /// <returns></returns>
        private Rectangle GetFilterBounds(bool withOffset = true)
        {
            Rectangle cell = DataGridView.GetCellDisplayRectangle(ColumnIndex, -1, false);

            Point p = new Point(
                (withOffset ? cell.Right : cell.Width) - _filterButtonImageSize.Width - _filterButtonMargin.Right,
                (withOffset ? cell.Bottom : cell.Height) - _filterButtonImageSize.Height - _filterButtonMargin.Bottom);

            return new Rectangle(p, _filterButtonImageSize);
        }

        #endregion


        #region mouse events

        /// <summary>
        /// OnMouseMove event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            if (FilterAndSortEnabled)
            {
                if (_filterButtonImageBounds.Contains(e.X, e.Y) && !_filterButtonOver)
                {
                    _filterButtonOver = true;
                    RepaintCell();
                }
                else if (!_filterButtonImageBounds.Contains(e.X, e.Y) && _filterButtonOver)
                {
                    _filterButtonOver = false;
                    RepaintCell();
                }
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// OnMouseDown event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (FilterAndSortEnabled && _filterButtonImageBounds.Contains(e.X, e.Y))
            {
                if (e.Button == MouseButtons.Left && !_filterButtonPressed)
                {
                    _filterButtonPressed = true;
                    _filterButtonOver = true;
                    RepaintCell();
                }
            }
            else
            {
                base.OnMouseDown(e);
            }
        }

        /// <summary>
        /// OnMouseUp event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            if (FilterAndSortEnabled && e.Button == MouseButtons.Left && _filterButtonPressed)
            {
                _filterButtonPressed = false;
                _filterButtonOver = false;
                RepaintCell();
                if (_filterButtonImageBounds.Contains(e.X, e.Y) && FilterPopup != null)
                {
                    FilterPopup(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
                }
            }
            base.OnMouseUp(e);
        }

        /// <summary>
        /// OnMouseLeave event
        /// </summary>
        /// <param name="rowIndex"></param>
        protected override void OnMouseLeave(int rowIndex)
        {
            if (FilterAndSortEnabled && _filterButtonOver)
            {
                _filterButtonOver = false;
                RepaintCell();
            }

            base.OnMouseLeave(rowIndex);
        }

        #endregion
    }
}
