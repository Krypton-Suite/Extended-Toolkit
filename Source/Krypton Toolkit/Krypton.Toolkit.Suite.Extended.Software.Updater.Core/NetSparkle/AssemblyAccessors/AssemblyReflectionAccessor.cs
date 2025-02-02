#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// An assembly accessor that uses reflection to learn information
    /// on an assembly with a given name.
    /// </summary>
    public class AssemblyReflectionAccessor : IAssemblyAccessor
    {
        private Assembly _assembly;
        private List<Attribute> _assemblyAttributes = [];

        /// <summary>
        /// Create the assembly accessor with a given assembly name. All pertinent attributes
        /// that are needed are read during object construction.
        /// </summary>
        /// <param name="assemblyName">the assembly name. 
        /// If null is passed, <seealso cref="Assembly.GetEntryAssembly"/> is used to get info on the asembly.</param>
        /// <exception cref="FileNotFoundException">Thrown when the path to the assembly with the given name doesn't exist</exception>
        /// <exception cref="ArgumentNullException">Thrown when the assembly can't be loaded</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the assembly doesn't have any readable attributes</exception>
        public AssemblyReflectionAccessor(string assemblyName)
        {
            if (assemblyName == null)
            {
                _assembly = Assembly.GetEntryAssembly();
            }
            else
            {
                string absolutePath = Path.GetFullPath(assemblyName);
                if (!File.Exists(absolutePath))
                {
                    throw new FileNotFoundException();
                }
#if NETFRAMEWORK
                _assembly = Assembly.ReflectionOnlyLoadFrom(absolutePath); // this does not work on .NET Core 2.0+/.NET 5+ and has never worked
#else
                // try loading the assembly in ways compliant with .NET Core/.NET 5+
                _assembly = Assembly.LoadFrom(absolutePath);
                if (_assembly == null)
                {
                    _assembly = Assembly.LoadFile(absolutePath);
                }
#endif
                if (_assembly == null)
                {
                    throw new ArgumentNullException("Unable to load assembly " + absolutePath);
                }
            }

            // read the attributes            
            foreach (CustomAttributeData data in _assembly.GetCustomAttributesData())
            {
                Attribute? a = CreateAttribute(data);
                if (a != null)
                {
                    _assemblyAttributes.Add(a);
                }
            }

            if (_assemblyAttributes == null || _assemblyAttributes.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Unable to load assembly attributes from " + _assembly.FullName);
            }
        }

        /// <summary>
        /// This methods creates an attribute instance from the attribute data 
        /// information
        /// </summary>
        private Attribute? CreateAttribute(CustomAttributeData data)
        {
            try
            {
                var arguments = from arg in data.ConstructorArguments
                                select arg.Value;

                var attribute = data.Constructor.Invoke(arguments.ToArray())
                  as Attribute;

                foreach (var namedArgument in data.NamedArguments)
                {
                    var propertyInfo = namedArgument.MemberInfo as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(attribute, namedArgument.TypedValue.Value, null);
                    }
                    else
                    {
                        var fieldInfo = namedArgument.MemberInfo as FieldInfo;
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(attribute, namedArgument.TypedValue.Value);
                        }
                    }
                }

                return attribute;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Attribute? FindAttribute(Type AttributeType)
        {
            foreach (Attribute attr in _assemblyAttributes)
            {
                if (attr.GetType().Equals(AttributeType))
                {
                    return attr;
                }
            }

            return null;
        }

        #region Assembly Attribute Accessors

        /// <inheritdoc/>
        public string AssemblyTitle
        {
            get
            {
                AssemblyTitleAttribute? a = FindAttribute(typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
                return a?.Title ?? "";
            }
        }

        /// <inheritdoc/>
        public string AssemblyVersion => _assembly.GetName().Version.ToString();

        /// <inheritdoc/>
        public string AssemblyDescription
        {
            get
            {
                AssemblyDescriptionAttribute? a = FindAttribute(typeof(AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
                return a?.Description ?? "";
            }
        }

        /// <inheritdoc/>
        public string AssemblyProduct
        {
            get
            {
                AssemblyProductAttribute? a = FindAttribute(typeof(AssemblyProductAttribute)) as AssemblyProductAttribute;
                return a?.Product ?? "";
            }
        }

        /// <inheritdoc/>
        public string AssemblyCopyright
        {
            get
            {
                AssemblyCopyrightAttribute? a = FindAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
                return a?.Copyright ?? "";
            }
        }

        /// <inheritdoc/>
        public string AssemblyCompany
        {
            get
            {
                AssemblyCompanyAttribute? a = FindAttribute(typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;
                return a?.Company ?? "";
            }
        }
        #endregion
    }
}