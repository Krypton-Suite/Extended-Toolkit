#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    [DebuggerDisplay("'{_keyName}'= {Value}  -  Children = {_dictionary.Count}")]
    [DebuggerTypeProxy(typeof(SemanticValueDebugDisplay))]
    public sealed class SemanticValue : IDictionary<string, SemanticValue>, ICollection<KeyValuePair<string, SemanticValue>>, IEnumerable<KeyValuePair<string, SemanticValue>>, IEnumerable
    {
        internal class SemanticValueDebugDisplay
        {
            private object _name;

            private object _value;

            private float _confidence;

            private IDictionary<string, SemanticValue> _dictionary;

            public object Value => _value;

            public object Count => _dictionary.Count;

            public object KeyName => _name;

            public object Confidence => _confidence;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public SemanticValue[] AKeys
            {
                get
                {
                    SemanticValue[] array = new SemanticValue[_dictionary.Count];
                    int num = 0;
                    foreach (KeyValuePair<string, SemanticValue> item in _dictionary)
                    {
                        array[num++] = item.Value;
                    }
                    return array;
                }
            }

            public SemanticValueDebugDisplay(SemanticValue value)
            {
                _value = value.Value;
                _dictionary = value._dictionary;
                _name = value.KeyName;
                _confidence = value.Confidence;
            }
        }

        internal Dictionary<string, SemanticValue> _dictionary;

        internal bool _valueFieldSet;

        private string _keyName;

        private float _confidence;

        private object _value;

        public object Value
        {
            get
            {
                return _value;
            }
            internal set
            {
                _value = value;
            }
        }

        public float Confidence => _confidence;

        public SemanticValue this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                throw new InvalidOperationException(SR.Get(SRID.CollectionReadOnly));
            }
        }

        public int Count => _dictionary.Count;

        bool ICollection<KeyValuePair<string, SemanticValue>>.IsReadOnly => true;

        ICollection<string> IDictionary<string, SemanticValue>.Keys => _dictionary.Keys;

        ICollection<SemanticValue> IDictionary<string, SemanticValue>.Values => _dictionary.Values;

        internal string KeyName => _keyName;

        public SemanticValue(string keyName, object value, float confidence)
        {
            Helpers.ThrowIfNull(keyName, "keyName");
            _dictionary = new Dictionary<string, SemanticValue>();
            _confidence = confidence;
            _keyName = keyName;
            _value = value;
        }

        public SemanticValue(object value)
            : this(string.Empty, value, -1f)
        {
        }

        public override bool Equals(object obj)
        {
            SemanticValue semanticValue = obj as SemanticValue;
            if (semanticValue == null || semanticValue.Count != Count || (semanticValue.Value == null && Value != null) || (semanticValue.Value != null && !semanticValue.Value.Equals(Value)))
            {
                return false;
            }
            foreach (KeyValuePair<string, SemanticValue> item in _dictionary)
            {
                if (!semanticValue.ContainsKey(item.Key) || !semanticValue[item.Key].Equals(this[item.Key]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return Count;
        }

        public bool Contains(KeyValuePair<string, SemanticValue> item)
        {
            if (_dictionary.ContainsKey(item.Key))
            {
                return _dictionary.ContainsValue(item.Value);
            }
            return false;
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        void ICollection<KeyValuePair<string, SemanticValue>>.Add(KeyValuePair<string, SemanticValue> key)
        {
            throw new NotSupportedException(SR.Get(SRID.CollectionReadOnly));
        }

        void IDictionary<string, SemanticValue>.Add(string key, SemanticValue value)
        {
            throw new NotSupportedException(SR.Get(SRID.CollectionReadOnly));
        }

        void ICollection<KeyValuePair<string, SemanticValue>>.Clear()
        {
            throw new NotSupportedException(SR.Get(SRID.CollectionReadOnly));
        }

        bool ICollection<KeyValuePair<string, SemanticValue>>.Remove(KeyValuePair<string, SemanticValue> key)
        {
            throw new NotSupportedException(SR.Get(SRID.CollectionReadOnly));
        }

        bool IDictionary<string, SemanticValue>.Remove(string key)
        {
            throw new NotSupportedException(SR.Get(SRID.CollectionReadOnly));
        }

        void ICollection<KeyValuePair<string, SemanticValue>>.CopyTo(KeyValuePair<string, SemanticValue>[] array, int index)
        {
            ((ICollection<KeyValuePair<string, SemanticValue>>)_dictionary).CopyTo(array, index);
        }

        IEnumerator<KeyValuePair<string, SemanticValue>> IEnumerable<KeyValuePair<string, SemanticValue>>.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, SemanticValue>>)this).GetEnumerator();
        }

        bool IDictionary<string, SemanticValue>.TryGetValue(string key, out SemanticValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }
    }
}
