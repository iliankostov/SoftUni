namespace DictionariesHashTablesSets
{
    public class KeyValue<TKey, TValue>
    {
        public KeyValue(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override bool Equals(object other)
        {
            var element = (KeyValue<TKey, TValue>)other;
            var equals = object.Equals(this.Key, element.Key) && object.Equals(this.Value, element.Value);
            return equals;
        }

        public override int GetHashCode()
        {
            int keyHashCode = this.Key.GetHashCode();
            int valueHashCode = this.Value.GetHashCode();

            return ((keyHashCode << 5) + keyHashCode) ^ valueHashCode;
        }
    }
}