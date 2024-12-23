﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /*public class PaletteFormRedirectExtended : PaletteFormDoubleRedirectExtended,
                                       IPaletteMetric
    {
        #region Instance Fields
        private readonly PaletteRedirectExtended _redirect;
        #endregion

        #region Identity

        /// <summary>
        /// Initialize a new instance of the PaletteFormRedirect class.
        /// </summary>
        /// <param name="redirect">inheritance redirection instance.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        /// <param name="ownerForm"></param>
        public PaletteFormRedirectExtended(PaletteRedirectExtended redirect,
                                   NeedPaintHandler needPaint,
                                   VisualKryptonFormExtended ownerForm)
            : this(redirect, redirect, needPaint, ownerForm)
        {
        }

        /// <summary>
        /// Initialize a new instance of the PaletteFormRedirect class.
        /// </summary>
        /// <param name="redirectForm">inheritance redirection for form group.</param>
        /// <param name="redirectHeader">inheritance redirection for header.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        /// <param name="ownerForm"></param>
        public PaletteFormRedirectExtended([DisallowNull] PaletteRedirectExtended redirectForm,
                                   [DisallowNull] PaletteRedirectExtended redirectHeader,
                                   NeedPaintHandler needPaint,
                                   VisualKryptonFormExtended ownerForm)
            : base(redirectForm,
                   PaletteBackStyle.FormMain,
                   PaletteBorderStyle.FormMain,
                   needPaint,
                   ownerForm)
        {
            Debug.Assert(redirectForm != null);
            Debug.Assert(redirectHeader != null);

            // Remember the redirect reference
            _redirect = redirectForm!;

            // Create the palette storage
            Header = new PaletteHeaderButtonRedirect(redirectHeader!, PaletteBackStyle.HeaderForm, PaletteBorderStyle.HeaderForm, PaletteContentStyle.HeaderForm, needPaint);

            // Default other values
            OverlayHeaders = InheritBool.Inherit;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool IsDefault => base.IsDefault &&
                                            Header.IsDefault &&
                                            (OverlayHeaders == InheritBool.Inherit);

        #endregion

        #region Header
        /// <summary>
        /// Gets access to the header appearance entries.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Overrides for defining header appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteHeaderButtonRedirect Header { get; }

        private bool ShouldSerializeHeader() => !Header.IsDefault;

        #endregion

        #region OverlayHeaders

        /// <summary>
        /// Gets and sets a value indicating if headers should overlay the border.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Should headers overlay the border.")]
        [DefaultValue(InheritBool.Inherit)]
        [RefreshProperties(RefreshProperties.All)]
        public InheritBool OverlayHeaders
        {
            get;

            set
            {
                if (field != value)
                {
                    field = value;
                    PerformNeedPaint();
                }
            }
        }

        #endregion

        #region IPaletteMetric

        /// <summary>
        /// Gets an integer metric value.
        /// </summary>
        /// <param name="owningForm"></param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>Integer value.</returns>
        public int GetMetricInt(KryptonForm? owningForm, PaletteState state, PaletteMetricInt metric) =>
            // Pass onto the inheritance
            _redirect.GetMetricInt(owningForm, state, metric);

        /// <summary>
        /// Gets a boolean metric value.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>InheritBool value.</returns>
        public InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
        {
            // Is this the metric we provide?
            if (metric == PaletteMetricBool.HeaderGroupOverlay)
            {
                // If the user has defined an actual value to use
                if (OverlayHeaders != InheritBool.Inherit)
                {
                    return OverlayHeaders;
                }
            }

            // Pass onto the inheritance
            return _redirect.GetMetricBool(state, metric);
        }

        /// <summary>
        /// Gets a padding metric value.
        /// </summary>
        /// <param name="owningForm"></param>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <param name="metric">Requested metric.</param>
        /// <returns>Padding value.</returns>
        public Padding GetMetricPadding(KryptonFormExtended? owningForm, PaletteState state, PaletteMetricPadding metric) =>
            // Always pass onto the inheritance
            _redirect.GetMetricPadding(owningForm, state, metric);

        #endregion
    }*/
}