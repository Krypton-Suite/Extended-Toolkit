using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Represents a grid control, which displays a collection of colors using different styles.
    /// </summary>
    [DefaultProperty("Colour")]
    [DefaultEvent("ColourChanged")]
    public class ColourGrid : Control, IColourEditor
    {
        #region Constants
        private const int INVALID_INDEX = -1;
        #endregion

        #region Read Only
        private readonly IDictionary<int, Rectangle> _colourRegions;

        private static readonly object _eventAutoAddColoursChanged = new object(), _eventAutoFitChanged = new object(),
                                       _eventCellBorderColourChanged = new object(), _eventCellBorderStyleChanged = new object(),
                                       _eventCellContextMenuStripChanged = new object(), _eventCellSizeChanged = new object(),
                                       _eventColourChanged = new object(), _eventColourIndexChanged = new object(),
                                       _eventColoursChanged = new object(), _eventColumnsChanged = new object(),
                                       _eventCustomColoursChanged = new object(), _eventEditingColour = new object(),
                                       _eventEditModeChanged = new object(), _eventHotIndexChanged = new object(),
                                       _eventPaletteChanged = new object(), _eventSelectedCellStyleChanged = new object(),
                                       _eventShowCustomColoursChanged = new object(), _eventShowToolTipsChanged = new object(),
                                       _eventSpacingChanged = new object();
        #endregion

        #region Variables
        private bool _autoAddColours, _autoFit, _showCustomColours, _showToolTips;

        private Brush _cellBackgroundBrush;

        private Color _cellBorderColour, _colour;

        private ColourCellBorderStyle _cellBorderStyle;

        private ColourCollection _colours;

        private ColourPalette _palette;

        private ColourEditingMode _colourEditingMode;

        private ColourGridSelectedCellStyle _selectedCellStyle;

        private ContextMenuStrip _cellContextMenu;

        private int _colourIndex, _columns, _hotIndex, _previousColourIndex, _previousHotIndex, _updateCount;

        private ToolTip _toolTip;

        private Size _cellSize, _spacing;
        #endregion

        #region IColourEditor Implementation
        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color Colour
        {
            get => _colour;

            set
            {
                int newIndex;

                _colour = value;

                if (!value.IsEmpty)
                {
                    newIndex = GetColour(ColourIndex) == value ? ColourIndex : GetColourIndex(value);

                    if (newIndex == INVALID_INDEX)
                    {
                        newIndex = AddCustomColour(value);
                    }
                }
                else
                {
                    newIndex = INVALID_INDEX;
                }

                ColourIndex = newIndex;

                OnColourChanged(EventArgs.Empty);
            }
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged { add => Events.AddHandler(_eventColourChanged, value); remove => Events.RemoveHandler(_eventColourChanged, value); }
        #endregion
    }
}