#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Contains the values of the design parameters.
    /// </summary>
    public class DesignParameters
    {
        #region Internals

        /// <summary>
        /// Contains the form back color
        /// </summary>
        private readonly Color formBackColor = SystemColors.Control;

        /// <summary>
        /// Contains the bars back color
        /// </summary>
        private readonly Color barsBackColor = SystemColors.Control;

        #endregion Internals

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignParameters"/> class.
        /// </summary>
        /// <param name="formBackColor">BackColor of the form.</param>
        /// <param name="barsBackColor">BackColor of the bars.</param>
        public DesignParameters(Color formBackColor, Color barsBackColor)
        {
            this.formBackColor = formBackColor;
            this.barsBackColor = barsBackColor;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the back color of the form.
        /// </summary>
        /// <value>The back color of the form.</value>
        public Color FormBackColor
        {
            get { return this.formBackColor; }
        }

        /// <summary>
        /// Gets the back color of the bars.
        /// </summary>
        /// <value>The back color of the bars.</value>
        public Color BarsBackColor
        {
            get { return this.barsBackColor; }
        }

        #endregion Properties

        #region Overrides

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            DesignParameters compared = (DesignParameters)obj;

            return this.BarsBackColor == compared.BarsBackColor &&
                   this.FormBackColor == compared.FormBackColor;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.BarsBackColor.GetHashCode() ^
                   this.FormBackColor.GetHashCode();
        }

        #endregion Overrides
    }
}