namespace Hillel_hw_8
{
    /*
     * Проверку ключа на null я делаю в самом словаре, но у студии есть предупреждение "CS8602 - Dereference of a possibly null reference",
     * и чтобы его не отключать, пришлось городить доп проверки ключа и тут.
     * А с методом расчёта хэша ещё хуже получилось, хотя по факту условие не должно сработать никогда.
     */

    /// <summary>
    /// Моя имплементация хэш таблицы для хранения и обработки элементов (ключ/значение) словаря.
    /// </summary>
    /// <typeparam name="TKey">Ключ.</typeparam>
    /// <typeparam name="TValue">Значение.</typeparam>
    internal class MyHashTable<TKey, TValue>
    {
        private const int Size = 1000;
        private List<KeyValuePair<TKey, TValue>>[] bucket = new List<KeyValuePair<TKey, TValue>>[Size];
        private int count = 0;

        /// <summary>
        /// Количество элементов в таблице.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Добавляет новый элемент в таблицу.
        /// </summary>
        /// <param name="item">Структура, представляющая из себя пару ключ/значение.</param>
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

        /// <summary>
        /// Проверяет наличие элемента с ключом TKey в таблице.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>true если элемент с заданым ключём присутствует в словаре и false - если нет.</returns>
        public bool CheckIfKeyExists(TKey key)
        {
            var keyHash = GetKeyHash(key);
            return this.bucket[keyHash] != null && this.bucket[keyHash].Exists(x => x.Key != null && x.Key.Equals(key));
        }

        /// <summary>
        /// Проверяет наличие элемента в словаре.
        /// </summary>
        /// <param name="item">Структура, представляющая из себя пару ключ/значение.</param>
        /// <returns>true если элемент присутствует в словаре и false - если нет.</returns>
        public bool CheckIfItemExists(KeyValuePair<TKey, TValue> item)
        {
            if (!this.CheckIfKeyExists(item.Key))
            {
                return false;
            }
            else
            {
                var keyHash = GetKeyHash(item.Key);
                return this.bucket[keyHash].Exists(x => x.Key != null && x.Key.Equals(item.Key) && (x.Value == null ? x.Value == null : x.Value.Equals(item.Value)));
            }
        }

        /// <summary>
        /// Очищает таблицу (удаляет все элементы из неё).
        /// </summary>
        public void Clear()
        {
            Array.Clear(this.bucket);
            this.count = 0;
        }

        /// <summary>
        /// Возвращает значение элемента в таблице по заданому ключу.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Значение TValue.</returns>
        public TValue GetItemValue(TKey key)
        {
            var keyHash = GetKeyHash(key);
            return this.bucket[keyHash].First(x => x.Key != null && x.Key.Equals(key)).Value;
        }

        /// <summary>
        /// Обновляет значение элемента с аналогичным ключом.
        /// </summary>
        /// <param name="item">Структура, представляющая из себя пару ключ/значение.</param>
        public void UpdateItem(KeyValuePair<TKey, TValue> item)
        {
            var keyHash = GetKeyHash(item.Key);
            var index = this.bucket[keyHash].FindIndex(x => x.Key != null && x.Key.Equals(item.Key));
            this.bucket[keyHash][index] = item;
        }

        /// <summary>
        /// Удаляет из таблицы элемент с заданым ключем.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public void RemoveItem(TKey key)
        {
            var keyHash = GetKeyHash(key);
            var index = this.bucket[keyHash].FindIndex(x => x.Key != null && x.Key.Equals(key));
            this.bucket[keyHash].RemoveAt(index);
            this.count--;
        }

        /// <summary>
        /// Возвращает список всех ключей элементов в таблице.
        /// </summary>
        /// <returns>List&lt;TKey&gt;.</returns>
        public List<TKey> GetAllKeys()
        {
            return this.GetAllKeyValuePairs().Select(k => k.Key).ToList();
        }

        /// <summary>
        /// Возвращает список всех значений элементов в таблице.
        /// </summary>
        /// <returns>List&lt;TValue&gt;.</returns>
        public List<TValue> GetAllValues()
        {
            return this.GetAllKeyValuePairs().Select(k => k.Value).ToList();
        }

        /// <summary>
        /// Возвращает список всех элементов в таблице.
        /// </summary>
        /// <returns>List&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;.</returns>
        public List<KeyValuePair<TKey, TValue>> GetAllKeyValuePairs()
        {
            return this.bucket.Where(x => x != null).SelectMany(y => y).ToList();
        }

        /// <summary>
        /// Возвращает кастомный хэш ключа.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Хэш от TKey.</returns>
        private static int GetKeyHash(TKey key)
        {
            if (key == null)
            {
                return 0;
            }

            return Math.Abs(key.GetHashCode() % Size);
        }
    }
}