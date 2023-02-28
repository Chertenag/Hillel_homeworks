namespace Hillel_hw_8
{
    internal class MyHashTable<TKey, TValue>
    {
        private const int Size = 1000;
        private List<KeyValuePair<TKey, TValue>>[] bucket = new List<KeyValuePair<TKey, TValue>>[Size];
        private int count = 0;

        public int Count => this.count;

        public void AddNewItem(KeyValuePair<TKey, TValue> item)
        {
            var keyHash = GetKeyHash(item.Key);
            if (this.bucket[keyHash] == null)
            {
                this.bucket[keyHash] = new List<KeyValuePair<TKey, TValue>> { item };
            }
            else
            {
                this.bucket[keyHash].Add(item);
            }

            this.count++;
        }

        public bool CheckIfKeyExists(TKey key)
        {
            var keyHash = GetKeyHash(key);
            return this.bucket[keyHash] != null && this.bucket[keyHash].Exists(x => x.Key.Equals(key));
        }

        public bool CheckIfItemExists(KeyValuePair<TKey, TValue> item)
        {
            if (this.CheckIfKeyExists(item.Key))
            {
                return false;
            }
            else
            {
                var keyHash = GetKeyHash(item.Key);
                return this.bucket[keyHash].Exists(x => x.Key.Equals(item.Key) && x.Value.Equals(item.Value));
            }
        }

        public void Clear()
        {
            Array.Clear(this.bucket);
            this.count = 0;
        }

        public TValue GetItemValue(TKey key)
        {
            var keyHash = GetKeyHash(key);
            return this.bucket[keyHash].First(x => x.Key.Equals(key)).Value;
        }

        public void UpdateItem(KeyValuePair<TKey, TValue> item)
        {
            var keyHash = GetKeyHash(item.Key);
            var index = this.bucket[keyHash].FindIndex(x => x.Key.Equals(item.Key));
            this.bucket[keyHash][index] = item;
        }

        public void RemoveItem(TKey key)
        {
            var keyHash = GetKeyHash(key);
            var index = this.bucket[keyHash].FindIndex(x => x.Key.Equals(key));
            this.bucket[keyHash].RemoveAt(index);
        }

        public List<TKey> GetAllKeys()
        {
            return this.GetAllKeyValuePairs().Select(k => k.Key).ToList();
        }

        public List<TValue> GetAllValues()
        {
            return this.GetAllKeyValuePairs().Select(k => k.Value).ToList();
        }

        public List<KeyValuePair<TKey, TValue>> GetAllKeyValuePairs()
        {
            return this.bucket.Where(x => x != null).SelectMany(y => y).ToList();
        }

        private static int GetKeyHash(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Size);
        }
    }
}