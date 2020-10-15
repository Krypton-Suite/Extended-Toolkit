﻿namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class SubscriptTextValue : NullContentValues
    {
        #region Instance Fields

        #endregion

        #region Identity
        /// <summary>
        /// Gets and sets the short text value to use.
        /// </summary>
        public string LongText { get; set; }

        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public override string GetLongText()
        {
            return LongText;
        }
        #endregion
    }
}