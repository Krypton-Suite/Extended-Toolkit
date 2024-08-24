#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class PaletteColourDefinitions
    {
        #region Variables
        private ArrayList _originalCustomPaletteColourDefinitionList, _newCustomPaletteColourDefinitionList;

        // TODO: Update arrays
        private string[] _originalCustomPaletteColourDefinitions = new string[] {
            "Alternative Normal Text Colour",
            "Border Colour",
            "Custom Colour One",
            "Custom Colour Two",
            "Custom Colour Three",
            "Custom Colour Four",
            "Custom Colour Five",
            "Custom Colour Six",
            "Custom Text Colour One",
            "Custom Text Colour Two",
            "Custom Text Colour Three",
            "Custom Text Colour Four",
            "Custom Text Colour Five",
            "Custom Text Colour Six",
            "Disabled Control Colour",
            "Focused Text Colour",
            "Link Hover Text Colour",
            "Link Normal Text Colour",
            "Link Visited Text Colour",
            "Menu Text Colour",
            "Normal Text Colour",
            "Pressed Text Colour",
            "Ribbon Tab Text Colour",
            "Status Text Colour"
        },
        _newCustomPaletteColourDefinitions = new string[] {
            "Alternative Normal Text Colour",
            "Border Colour",
            "Custom Colour One",
            "Custom Colour Two",
            "Custom Colour Three",
            "Custom Colour Four",
            "Custom Colour Five",
            "Custom Colour Six",
            "Custom Text Colour One",
            "Custom Text Colour Two",
            "Custom Text Colour Three",
            "Custom Text Colour Four",
            "Custom Text Colour Five",
            "Custom Text Colour Six",
            "Disabled Control Colour",
            "Focused Text Colour",
            "Link Disabled Text Colour",
            "Link Focused Text Colour",
            "Link Hover Text Colour",
            "Link Normal Text Colour",
            "Link Visited Text Colour",
            "Menu Text Colour",
            "Normal Text Colour",
            "Pressed Text Colour",
            "Ribbon Tab Text Colour",
            "Status Text Colour"
        };
        #endregion

        #region Properties
        public string[] OrignalCustomPaletteColourDefinitions => _originalCustomPaletteColourDefinitions;

        public string[] NewCustomPaletteColourDefinitions => _newCustomPaletteColourDefinitions;

        #endregion

        #region Constructor
        public PaletteColourDefinitions()
        {

        }
        #endregion

        #region Methods
        public void PropagateOriginalDefinitionsKryptonListBox(KryptonListBox target)
        {
            _originalCustomPaletteColourDefinitionList = new ArrayList(23);

            foreach (string colourDefinition in OrignalCustomPaletteColourDefinitions)
            {
                _originalCustomPaletteColourDefinitionList.Add(colourDefinition);
            }

            foreach (string definition in _originalCustomPaletteColourDefinitionList)
            {
                target.Items.Add(definition);
            }
        }

        public void PropagateOriginalDefinitionsKryptonComboBox(KryptonComboBox target)
        {
            _originalCustomPaletteColourDefinitionList = new ArrayList(23);

            foreach (string colourDefinition in OrignalCustomPaletteColourDefinitions)
            {
                _originalCustomPaletteColourDefinitionList.Add(colourDefinition);
            }

            foreach (string definition in _originalCustomPaletteColourDefinitionList)
            {
                target.Items.Add(definition);
            }
        }
        #endregion
    }
}