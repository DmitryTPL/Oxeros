using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class DrawableDictionary
{
}

[Serializable]
public class UnitySerializedDictionary<TKey, TValue> : DrawableDictionary, IDictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    #region Fields

    [NonSerialized]
    private Dictionary<TKey, TValue> _dict;
    [NonSerialized]
    private IEqualityComparer<TKey> _comparer;

    #endregion

    #region CONSTRUCTOR

    public UnitySerializedDictionary()
    {
    }

    public UnitySerializedDictionary(IEqualityComparer<TKey> comparer)
    {
        _comparer = comparer;
    }

    #endregion

    #region Properties

    public IEqualityComparer<TKey> Comparer => _comparer;

    #endregion

    #region IDictionary Interface

    public int Count => _dict?.Count ?? 0;

    public void Add(TKey key, TValue value)
    {
        _dict ??= new Dictionary<TKey, TValue>(_comparer);
        _dict.Add(key, value);
    }

    public bool ContainsKey(TKey key)
    {
        return _dict != null && _dict.ContainsKey(key);
    }

    public ICollection<TKey> Keys
    {
        get
        {
            _dict ??= new Dictionary<TKey, TValue>(_comparer);
            return _dict.Keys;
        }
    }

    public bool Remove(TKey key)
    {
        return _dict != null && _dict.Remove(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (_dict == null)
        {
            value = default;
            return false;
        }

        return _dict.TryGetValue(key, out value);
    }

    public ICollection<TValue> Values
    {
        get
        {
            _dict ??= new Dictionary<TKey, TValue>(_comparer);
            return _dict.Values;
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            if (_dict == null) throw new KeyNotFoundException();
            return _dict[key];
        }
        set
        {
            _dict ??= new Dictionary<TKey, TValue>(_comparer);
            _dict[key] = value;
        }
    }

    public void Clear()
    {
        _dict?.Clear();
    }

    void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
    {
        _dict ??= new Dictionary<TKey, TValue>(_comparer);
        (_dict as ICollection<KeyValuePair<TKey, TValue>>).Add(item);
    }

    bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
    {
        return _dict != null && (_dict as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
    }

    void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        (_dict as ICollection<KeyValuePair<TKey, TValue>>)?.CopyTo(array, arrayIndex);
    }

    bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
    {
        return _dict != null && (_dict as ICollection<KeyValuePair<TKey, TValue>>).Remove(item);
    }

    bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

    public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
    {
        return _dict?.GetEnumerator() ?? default(Dictionary<TKey, TValue>.Enumerator);
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _dict?.GetEnumerator() ?? Enumerable.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();
    }

    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
    {
        return _dict?.GetEnumerator() ?? Enumerable.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();
    }

    #endregion

    #region ISerializationCallbackReceiver

    [SerializeField]
    private TKey[] _keys;
    [SerializeField]
    private TValue[] _values;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        if (_keys != null && _values != null)
        {
            if (_dict == null) _dict = new Dictionary<TKey, TValue>(_keys.Length, _comparer);
            else _dict.Clear();

            for (var i = 0; i < _keys.Length; i++)
            {
                if (i < _values.Length)
                    _dict[_keys[i]] = _values[i];
                else
                    _dict[_keys[i]] = default;
            }
        }

        _keys = null;
        _values = null;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        if (_dict == null || _dict.Count == 0)
        {
            _keys = null;
            _values = null;
        }
        else
        {
            var cnt = _dict.Count;
            _keys = new TKey[cnt];
            _values = new TValue[cnt];
            var i = 0;
            using var e = _dict.GetEnumerator();

            while (e.MoveNext())
            {
                _keys[i] = e.Current.Key;
                _values[i] = e.Current.Value;
                i++;
            }
        }
    }

    #endregion
}