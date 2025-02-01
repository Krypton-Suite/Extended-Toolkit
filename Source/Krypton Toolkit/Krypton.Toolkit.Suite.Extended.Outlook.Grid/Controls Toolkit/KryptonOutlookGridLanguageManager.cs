using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class KryptonOutlookGridLanguageManager : Component
    {
        #region Public

        /// <summary>
        /// Gets a set of language strings used by KryptonOutlookGrid that can be localized.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Collection of language strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public OutlookGridGeneralStrings OutlookGridGeneralStrings => GeneralStrings;

        private bool ShouldSerializeOutlookGridGeneralStrings() => !GeneralStrings.IsDefault;

        public void ResetOutlookGridGeneralStrings() => GeneralStrings.Reset();

        #endregion

        #region Static Strings

        public static OutlookGridGeneralStrings GeneralStrings { get; } = new();

        #endregion

        #region Identity

        public KryptonOutlookGridLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !ShouldSerializeOutlookGridGeneralStrings();

        public void Reset()
        {
            ResetOutlookGridGeneralStrings();
        }

        #endregion
    }
}
