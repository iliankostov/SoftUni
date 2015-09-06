namespace ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    internal class BiDictionary<K1, K2, T>
    {
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();

        private Dictionary<K1, List<T>> valuesByFirstKey = new Dictionary<K1, List<T>>();

        private Dictionary<K2, List<T>> valuesBySecondKey = new Dictionary<K2, List<T>>();

        public void Add(K1 key1, K2 key2, T value)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            this.valuesByBothKeys.EnsureKeyExists(tuple);
            this.valuesByBothKeys[tuple].Add(value);

            this.valuesByFirstKey.EnsureKeyExists(key1);
            this.valuesByFirstKey[key1].Add(value);

            this.valuesBySecondKey.EnsureKeyExists(key2);
            this.valuesBySecondKey[key2].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                yield break;
            }

            var elements = this.valuesByBothKeys[tuple];
            if (elements == null)
            {
                yield break;
            }

            foreach (var element in elements)
            {
                yield return element;
            }
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            var elements = this.valuesByFirstKey[key1];
            if (elements == null)
            {
                yield break;
            }

            foreach (var element in elements)
            {
                yield return element;
            }
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            var elements = this.valuesBySecondKey[key2];
            if (elements == null)
            {
                yield break;
            }

            foreach (var element in elements)
            {
                yield return element;
            }
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return false;
            }

            var elements = this.valuesByBothKeys[tuple];
            foreach (var element in elements)
            {
                this.valuesByFirstKey[key1].Remove(element);
                this.valuesBySecondKey[key2].Remove(element);
            }

            this.valuesByBothKeys.Remove(tuple);

            return true;
        }
    }
}