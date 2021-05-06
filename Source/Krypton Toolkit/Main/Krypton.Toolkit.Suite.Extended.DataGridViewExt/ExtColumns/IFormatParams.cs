#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

using System;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Data.Grid.View
{
    /// <summary>
    /// Parameter class for Conditional Formatting
    /// </summary>
    /// <seealso cref="ICloneable" />
    public interface IFormatParams : ICloneable
    {
        /// <summary>
        /// Persists the parameters.
        /// </summary>
        /// <param name="writer">The XML writer.</param>
        void Persist(XmlWriter writer);
    }
}