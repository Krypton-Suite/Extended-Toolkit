#region License
// <copyright file="InformationBoxScope.cs" company="Johann Blais">
// Copyright (c) 2008 All Right Reserved
// </copyright>
// <author>Johann Blais</author>
#endregion

using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Represents the scope of a set of parameters for the InformationBoxes.
    /// </summary>
    public class InformationBoxScope : IDisposable
    {
        #region Attributes

        /// <summary>
        /// Stack of all scopes
        /// </summary>
        private static readonly Stack<InformationBoxScope> scopesStack = new Stack<InformationBoxScope>();

        /// <summary>
        /// Contains the parameters defined within the scope
        /// </summary>
        private readonly InformationBoxScopeParameters definedParameters = new InformationBoxScopeParameters();

        #endregion Attributes

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxScope"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public InformationBoxScope(InformationBoxScopeParameters parameters)
        {
            this.definedParameters = parameters;

            scopesStack.Push(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxScope"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="behavior">The behavior.</param>
        public InformationBoxScope(InformationBoxScopeParameters parameters, InformationBoxScopeBehavior behavior)
        {
            this.definedParameters = parameters;
            this.EffectiveParameters = parameters;

            if (behavior == InformationBoxScopeBehavior.INHERITPARENT)
            {
                if (null != Current)
                {
                    // Merge with the parameters defined explicitly in the direct parent
                    this.EffectiveParameters.Merge(Current.definedParameters);
                }
            }
            else if (behavior == InformationBoxScopeBehavior.INHERITALL)
            {
                if (null != Current)
                {
                    // Merge the effective parameters from the parent
                    this.EffectiveParameters.Merge(Current.Parameters);
                }
            }

            scopesStack.Push(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxScope"/> class.
        /// </summary>
        public InformationBoxScope()
        {
            scopesStack.Push(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public InformationBoxScopeParameters Parameters
        {
            get { return this.EffectiveParameters; }
        }

        /// <summary>
        /// Gets the current scope.
        /// </summary>
        /// <value>The current.</value>
        internal static InformationBoxScope Current
        {
            get
            {
                if (scopesStack.Count > 0)
                {
                    return scopesStack.Peek();
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the effective parameters.
        /// </summary>
        /// <value>The effective parameters.</value>
        internal InformationBoxScopeParameters EffectiveParameters { get; set; }

        #endregion Properties

        #region Dispose

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            scopesStack.Pop();

            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Releases unmanaged resources
            }

            // Releases managed resources
        }

        #endregion Dispose
    }
}