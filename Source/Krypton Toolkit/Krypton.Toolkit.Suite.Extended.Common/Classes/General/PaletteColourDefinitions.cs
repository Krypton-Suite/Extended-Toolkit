#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        public string[] OrignalCustomPaletteColourDefinitions { get => _originalCustomPaletteColourDefinitions; }

        public string[] NewCustomPaletteColourDefinitions { get => _newCustomPaletteColourDefinitions; }
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