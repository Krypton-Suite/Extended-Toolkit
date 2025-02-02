#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    [DebuggerTypeProxy(typeof(SrgsItemDebugDisplay))]
    public class SrgsItem : SrgsElement, IItem, IElement
    {
        internal class SrgsItemDebugDisplay
        {
            private float _weight = 1f;

            private float _repeatProbability = 0.5f;

            private int _minRepeat = -1;

            private int _maxRepeat = -1;

            private SrgsElementList _elements;

            public object Weigth => _weight;

            public object MinRepeat => _minRepeat;

            public object MaxRepeat => _maxRepeat;

            public object RepeatProbability => _repeatProbability;

            public object Count => _elements.Count;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public SrgsElement[] AKeys
            {
                get
                {
                    SrgsElement[] array = new SrgsElement[_elements.Count];
                    for (int i = 0; i < _elements.Count; i++)
                    {
                        array[i] = _elements[i];
                    }
                    return array;
                }
            }

            public SrgsItemDebugDisplay(SrgsItem item)
            {
                _weight = item._weight;
                _repeatProbability = item._repeatProbability;
                _minRepeat = item._minRepeat;
                _maxRepeat = item._maxRepeat;
                _elements = item._elements;
            }
        }

        private float _weight = 1f;

        private float _repeatProbability = 0.5f;

        private int _minRepeat = -1;

        private int _maxRepeat = -1;

        private SrgsElementList _elements;

        private const int NotSet = -1;

        public Collection<SrgsElement> Elements => _elements;

        public float RepeatProbability
        {
            get => _repeatProbability;
            set
            {
                if (value is < 0f or > 1f)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.InvalidRepeatProbability, value));
                }
                _repeatProbability = value;
            }
        }

        public int MinRepeat
        {
            get
            {
                if (_minRepeat != -1)
                {
                    return _minRepeat;
                }
                return 1;
            }
        }

        public int MaxRepeat
        {
            get
            {
                if (_maxRepeat != -1)
                {
                    return _maxRepeat;
                }
                return 1;
            }
        }

        public float Weight
        {
            get => _weight;
            set
            {
                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.InvalidWeight, value));
                }
                _weight = value;
            }
        }

        internal override SrgsElement[] Children
        {
            get
            {
                SrgsElement[] array = new SrgsElement[_elements.Count];
                int num = 0;
                foreach (SrgsElement element in _elements)
                {
                    array[num++] = element;
                }
                return array;
            }
        }

        public SrgsItem()
        {
            _elements = [];
        }

        public SrgsItem(string text)
            : this()
        {
            Helpers.ThrowIfEmptyOrNull(text, "text");
            _elements.Add(new SrgsText(text));
        }

        public SrgsItem(params SrgsElement[] elements)
            : this()
        {
            Helpers.ThrowIfNull(elements, "elements");
            int num = 0;
            while (true)
            {
                if (num < elements.Length)
                {
                    if (elements[num] == null)
                    {
                        break;
                    }
                    _elements.Add(elements[num]);
                    num++;
                    continue;
                }
                return;
            }
            throw new ArgumentNullException("elements", SR.Get(SRID.ParamsEntryNullIllegal));
        }

        public SrgsItem(int repeatCount)
            : this()
        {
            SetRepeat(repeatCount);
        }

        public SrgsItem(int min, int max)
            : this()
        {
            SetRepeat(min, max);
        }

        public SrgsItem(int min, int max, string text)
            : this(text)
        {
            SetRepeat(min, max);
        }

        public SrgsItem(int min, int max, params SrgsElement[] elements)
            : this(elements)
        {
            SetRepeat(min, max);
        }

        public void SetRepeat(int count)
        {
            if (count is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            _minRepeat = _maxRepeat = count;
        }

        public void SetRepeat(int minRepeat, int maxRepeat)
        {
            if (minRepeat is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException("minRepeat", SR.Get(SRID.InvalidMinRepeat, minRepeat));
            }
            if (maxRepeat != int.MaxValue && maxRepeat is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException("maxRepeat", SR.Get(SRID.InvalidMinRepeat, maxRepeat));
            }
            if (minRepeat > maxRepeat)
            {
                throw new ArgumentException(SR.Get(SRID.MinGreaterThanMax));
            }
            _minRepeat = minRepeat;
            _maxRepeat = maxRepeat;
        }

        public void Add(SrgsElement element)
        {
            Helpers.ThrowIfNull(element, "element");
            Elements.Add(element);
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("item");
            if (!_weight.Equals(1f))
            {
                writer.WriteAttributeString("weight", _weight.ToString("0.########", CultureInfo.InvariantCulture));
            }
            if (!_repeatProbability.Equals(0.5f))
            {
                writer.WriteAttributeString("repeat-prob", _repeatProbability.ToString("0.########", CultureInfo.InvariantCulture));
            }
            if (_minRepeat == _maxRepeat)
            {
                if (_minRepeat != -1)
                {
                    writer.WriteAttributeString("repeat", string.Format(CultureInfo.InvariantCulture, "{0}", [
                        _minRepeat
                    ]));
                }
            }
            else if (_maxRepeat is int.MaxValue or -1)
            {
                writer.WriteAttributeString("repeat", string.Format(CultureInfo.InvariantCulture, "{0}-", [
                    _minRepeat
                ]));
            }
            else
            {
                int num = _minRepeat == -1 ? 1 : _minRepeat;
                writer.WriteAttributeString("repeat", string.Format(CultureInfo.InvariantCulture, "{0}-{1}", [
                    num,
                    _maxRepeat
                ]));
            }
            Type right = null;
            foreach (SrgsElement element in _elements)
            {
                Type type = element.GetType();
                if (type == typeof(SrgsText) && type == right)
                {
                    writer.WriteString(" ");
                }
                right = type;
                element.WriteSrgs(writer);
            }
            writer.WriteEndElement();
        }

        internal override string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_elements.Count > 7)
            {
                stringBuilder.Append("SrgsItem Count = ");
                stringBuilder.Append(_elements.Count.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                if (_minRepeat != _maxRepeat || _maxRepeat != -1)
                {
                    stringBuilder.Append("[");
                    if (_minRepeat == _maxRepeat)
                    {
                        stringBuilder.Append(_minRepeat.ToString(CultureInfo.InvariantCulture));
                    }
                    else if (_maxRepeat is int.MaxValue or -1)
                    {
                        stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0},-", [
                            _minRepeat
                        ]));
                    }
                    else
                    {
                        int num = _minRepeat == -1 ? 1 : _minRepeat;
                        stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0},{1}", [
                            num,
                            _maxRepeat
                        ]));
                    }
                    stringBuilder.Append("] ");
                }
                bool flag = true;
                foreach (SrgsElement element in _elements)
                {
                    if (!flag)
                    {
                        stringBuilder.Append(" ");
                    }
                    stringBuilder.Append("{");
                    stringBuilder.Append(element.DebuggerDisplayString());
                    stringBuilder.Append("}");
                    flag = false;
                }
            }
            return stringBuilder.ToString();
        }
    }
}
