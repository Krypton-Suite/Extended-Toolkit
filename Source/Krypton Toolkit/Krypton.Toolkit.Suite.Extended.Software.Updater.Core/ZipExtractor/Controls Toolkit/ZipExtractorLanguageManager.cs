using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core.ZipExtractor.Controls_Toolkit
{
    [Category(@"code")]
    [Description(@"")]
    [ToolboxItem(true)]
    public class ZipExtractorLanguageManager : Component
    {
        #region Public

        public ZipExtractorStrings ZipExtractorStrings => ExtractorStrings;

        private bool ShouldSerializeZipExtractorStrings() => !ExtractorStrings.IsDefault;

        public void ResetZipExtractorStrings() => ExtractorStrings.Reset();

        #endregion

        #region Static Strings

        public static ZipExtractorStrings ExtractorStrings { get; } = new();

        #endregion

        #region Identity

        public ZipExtractorLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !ShouldSerializeZipExtractorStrings();

        public void Reset() => ResetZipExtractorStrings();

        #endregion
    }
}