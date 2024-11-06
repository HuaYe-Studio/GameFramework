using System;
using UnityEngine;
using System.Collections.Generic;

namespace Utility.Base.ExtendDataStructure
{
    public abstract class DataStructure
    {
        [Serializable]
        public class SerializeList<T>
        {
            [SerializeField] public List<T> list = new();

            public List<T> ToList()
            {
                return list;
            }
        }

        [Serializable]
        public class SerializeDictionary<TKey, TValue> : ISerializationCallbackReceiver
        {
            public List<TKey> keys = new List<TKey>();
            public List<TValue> values = new List<TValue>();
            public Dictionary<TKey, TValue> Dictionary;

            public SerializeDictionary(Dictionary<TKey, TValue> dictionary)
            {
                Dictionary = dictionary;
            }

            public void OnBeforeSerialize()
            {
                keys.Clear();
                values.Clear();
                foreach (var kvp in Dictionary)
                {
                    keys.Add(kvp.Key);
                    values.Add(kvp.Value);
                }
            }

            public void OnAfterDeserialize()
            {
                Dictionary = new Dictionary<TKey, TValue>();
                for (var i = 0; i != Math.Min(keys.Count, values.Count); i++)
                {
                    Dictionary.Add(keys[i], values[i]);
                }
            }
        }
    }
}