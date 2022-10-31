﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public abstract class PaletteSerializer : IPaletteSerializer
    {
        #region Constants

        private static readonly List<IPaletteSerializer> _serializerCache;

        #endregion

        #region Static Constructors

        /// <summary>
        /// Initializes static members of the <see cref="PaletteSerializer"/> class.
        /// </summary>
        static PaletteSerializer()
        {
            _serializerCache = new List<IPaletteSerializer>();
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets all loaded serializers.
        /// </summary>
        /// <value>The loaded serializers.</value>
        public static IEnumerable<IPaletteSerializer> AllSerializers => _serializerCache.AsReadOnly();

        /// <summary>
        /// Returns a filter suitable for use with the <see cref="System.Windows.Forms.OpenFileDialog"/>.
        /// </summary>
        /// <value>A filter suitable for use with the <see cref="System.Windows.Forms.OpenFileDialog"/>.</value>
        /// <remarks>This filter does not include any serializers that cannot read source data.</remarks>
        public static string DefaultOpenFilter
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultOpenFilter))
                {
                    CreateFilters();
                }

                return _defaultOpenFilter;
            }
        }

        /// <summary>
        /// Returns a filter suitable for use with the <see cref="System.Windows.Forms.SaveFileDialog"/>.
        /// </summary>
        /// <value>A filter suitable for use with the <see cref="System.Windows.Forms.SaveFileDialog"/>.</value>
        /// <remarks>This filter does not include any serializers that cannot write destination data.</remarks>
        public static string DefaultSaveFilter
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultSaveFileter))
                {
                    CreateFilters();
                }

                return _defaultSaveFileter;
            }
        }

        #endregion

        #region Static Methods

        public static IPaletteSerializer GetSerializer(string fileName)
        {
            IPaletteSerializer result;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("Cannot find file '{0}'.", fileName), fileName);
            }

            if (_serializerCache.Count == 0)
            {
                LoadSerializers();
            }

            result = null;

            foreach (IPaletteSerializer checkSerializer in AllSerializers)
            {
                using (FileStream file = File.OpenRead(fileName))
                {
                    if (checkSerializer.CanReadFrom(file))
                    {
                        result = checkSerializer;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Creates the Open and Save As filters.
        /// </summary>
        private static void CreateFilters()
        {
            StringBuilder openFilter;
            StringBuilder saveFilter;
            List<string> openExtensions;

            openExtensions = new List<string>();
            openFilter = new StringBuilder();
            saveFilter = new StringBuilder();

            if (_serializerCache.Count == 0)
            {
                LoadSerializers();
            }

            foreach (IPaletteSerializer serializer in _serializerCache.Where(serializer => !(string.IsNullOrEmpty(serializer.DefaultExtension) || openExtensions.Contains(serializer.DefaultExtension))))
            {
                StringBuilder extensionMask;
                string filter;

                extensionMask = new StringBuilder();

                foreach (string extension in serializer.DefaultExtension.Split(new[]
                                                                               {
                                                                         ';'
                                                                       }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string mask;

                    mask = "*." + extension;

                    if (!openExtensions.Contains(mask))
                    {
                        openExtensions.Add(mask);
                    }

                    if (extensionMask.Length != 0)
                    {
                        extensionMask.Append(";");
                    }
                    extensionMask.Append(mask);
                }

                filter = string.Format("{0} Files ({1})|{1}", serializer.Name, extensionMask);

                if (serializer.CanRead)
                {
                    if (openFilter.Length != 0)
                    {
                        openFilter.Append("|");
                    }
                    openFilter.Append(filter);
                }

                if (serializer.CanWrite)
                {
                    if (saveFilter.Length != 0)
                    {
                        saveFilter.Append("|");
                    }
                    saveFilter.Append(filter);
                }
            }

            if (openExtensions.Count != 0)
            {
                openFilter.Insert(0, string.Format("All Supported Palettes ({0})|{0}|", string.Join(";", openExtensions.ToArray())));
            }
            if (openFilter.Length != 0)
            {
                openFilter.Append("|");
            }
            openFilter.Append("All Files (*.*)|*.*");

            _defaultOpenFilter = openFilter.ToString();
            _defaultSaveFileter = saveFilter.ToString();
        }

        /// <summary>
        /// Gets the loadable types from an assembly.
        /// </summary>
        /// <param name="assembly">The assembly to load types from.</param>
        /// <returns>Available types</returns>
        private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(x => x != null);
            }
        }

        /// <summary>
        /// Loads the serializers.
        /// </summary>
        private static void LoadSerializers()
        {
            _serializerCache.Clear();
            _defaultOpenFilter = null;
            _defaultSaveFileter = null;

            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => GetLoadableTypes(assembly).Where(type => !type.IsAbstract && type.IsPublic && typeof(IPaletteSerializer).IsAssignableFrom(type))))
            {
                try
                {
                    _serializerCache.Add((IPaletteSerializer)Activator.CreateInstance(type));
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch
                // ReSharper restore EmptyGeneralCatchClause
                {
                    // ignore errors
                }
            }

            // sort the cache by name, that way the open/save filters won't need independant sorting
            // and can easily map FileDialog.FilterIndex to an item in this collection
            _serializerCache.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to read palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be read using this serializer; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public virtual bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to write palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be written using this serializer; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public virtual bool CanWrite => true;

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        [Browsable(false)]
        public abstract string DefaultExtension { get; }

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        [Browsable(false)]
        public abstract string Name { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether this instance can read palette from data the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns><c>true</c> if this instance can read palette data from the specified stream; otherwise, <c>false</c>.</returns>
        public abstract bool CanReadFrom(Stream stream);

        /// <summary>
        /// Deserializes the <see cref="ColourCollection" /> contained by the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
        /// <returns>The <see cref="ColourCollection" /> being deserialized.</returns>
        public abstract ColourCollection Deserialize(Stream stream);

        /// <summary>
        /// Deserializes the <see cref="ColourCollection" /> contained by the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="fileName">The name of the file that the palette will be read from.</param>
        /// <returns>The <see cref="ColourCollection" /> being deserialized.</returns>
        public ColourCollection Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("Cannot find file '{0}'", fileName), fileName);
            }

            using (Stream stream = File.OpenRead(fileName))
            {
                return this.Deserialize(stream);
            }
        }

        /// <summary>
        /// Serializes the specified <see cref="ColourCollection" /> and writes the palette to a file using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
        /// <param name="palette">The <see cref="ColourCollection" /> to serialize.</param>
        public abstract void Serialize(Stream stream, ColourCollection palette);

        /// <summary>
        /// Serializes the specified <see cref="ColourCollection" /> and writes the palette to a file using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileName">The name of the file where the palette will be written to.</param>
        /// <param name="palette">The <see cref="ColourCollection" /> to serialize.</param>
        public void Serialize(string fileName, ColourCollection palette)
        {
            using (Stream stream = File.Create(fileName))
            {
                this.Serialize(stream, palette);
            }
        }

        /// <summary>
        /// Reads a 16bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>The unsigned 16bit integer cast to an <c>Int32</c>.</returns>
        protected int ReadInt16(Stream stream)
        {
            return (stream.ReadByte() << 8) | (stream.ReadByte() << 0);
        }

        /// <summary>
        /// Reads a 32bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>The unsigned 32bit integer cast to an <c>Int32</c>.</returns>
        protected int ReadInt32(Stream stream)
        {
            // big endian conversion: http://stackoverflow.com/a/14401341/148962

            return ((byte)stream.ReadByte() << 24) | ((byte)stream.ReadByte() << 16) | ((byte)stream.ReadByte() << 8) | (byte)stream.ReadByte();
        }

        /// <summary>
        /// Reads a unicode string of the specified length.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <param name="length">The number of characters in the string.</param>
        /// <returns>The string read from the stream.</returns>
        protected string ReadString(Stream stream, int length)
        {
            byte[] buffer;

            buffer = new byte[length * 2];

            stream.Read(buffer, 0, buffer.Length);

            return Encoding.BigEndianUnicode.GetString(buffer);
        }

        /// <summary>
        /// Writes a 16bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        protected void WriteInt16(Stream stream, short value)
        {
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 0));
        }

        /// <summary>
        /// Writes a 32bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        protected void WriteInt32(Stream stream, int value)
        {
            stream.WriteByte((byte)((value & 0xFF000000) >> 24));
            stream.WriteByte((byte)((value & 0x00FF0000) >> 16));
            stream.WriteByte((byte)((value & 0x0000FF00) >> 8));
            stream.WriteByte((byte)((value & 0x000000FF) >> 0));
        }

        protected void WriteString(Stream stream, string value)
        {
            stream.Write(Encoding.BigEndianUnicode.GetBytes(value), 0, value.Length * 2);
        }

        #endregion

        #region IPaletteSerializer Interface

        /// <summary>
        /// Determines whether this instance can read palette data from the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns><c>true</c> if this instance can read palette data from the specified stream; otherwise, <c>false</c>.</returns>
        bool IPaletteSerializer.CanReadFrom(Stream stream)
        {
            return this.CanReadFrom(stream);
        }

        /// <summary>
        /// Deserializes the <see cref="ColourCollection" /> contained by the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
        /// <returns>The <see cref="ColourCollection" /> being deserialized.</returns>
        ColourCollection IPaletteSerializer.Deserialize(Stream stream)
        {
            return this.Deserialize(stream);
        }

        /// <summary>
        /// Serializes the specified <see cref="ColourCollection" /> and writes the palette to a file using the specified Stream.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
        /// <param name="palette">The <see cref="ColourCollection" /> to serialize.</param>
        void IPaletteSerializer.Serialize(Stream stream, ColourCollection palette)
        {
            this.Serialize(stream, palette);
        }

        /// <summary>
        /// Gets the maximum number of colors supported by this format.
        /// </summary>
        /// <value>
        /// The maximum value number of colors supported by this format.
        /// </value>
        public virtual int Maximum => int.MaxValue;

        /// <summary>
        /// Gets the minimum numbers of colors supported by this format.
        /// </summary>
        /// <value>
        /// The minimum number of colors supported by this format.
        /// </value>
        public virtual int Minimum => 1;

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to read palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be read using this serializer; otherwise, <c>false</c>.</value>
        bool IPaletteSerializer.CanRead => this.CanRead;

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to write palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be written using this serializer; otherwise, <c>false</c>.</value>
        bool IPaletteSerializer.CanWrite => this.CanWrite;

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        string IPaletteSerializer.DefaultExtension => this.DefaultExtension;

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        string IPaletteSerializer.Name => this.Name;

        #endregion

        #region Other

        private static string _defaultOpenFilter;

        private static string _defaultSaveFileter;

        #endregion
    }
}