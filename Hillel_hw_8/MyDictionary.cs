namespace Hillel_hw_8
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Реализация словаря на основе "Хеш таблиц".
    /// </summary>
    /// <typeparam name="TKey">Ключ.</typeparam>
    /// <typeparam name="TValue">Значение.</typeparam>
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private MyHashTable<TKey, TValue> hashtable = new MyHashTable<TKey, TValue>();

        /// <summary>
        /// Возвращает список всех ключей словаря.
        /// </summary>
        public ICollection<TKey> Keys => this.hashtable.GetAllKeys();

        /// <summary>
        /// Возвращает список всех значений словаря.
        /// </summary>
        public ICollection<TValue> Values => this.hashtable.GetAllValues();

        /// <summary>
        /// Возвращает количество элементов в словаре.
        /// </summary>
        public int Count => this.hashtable.Count;

        /// <summary>
        /// Так как я не пошел по пути использования уже существующего класса Hashtable, а слепил свой,
        /// то пусть в моей имплементации словарь будет всегда доступный для записи.
        /// Хотя по сути этот параметр у меня ни на что не влияет, а подглядывть в реализацию Dictionary не интересно.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Возвращает или задаёт значение по ключу.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Значение, которое соответсвует ключу в словаре.</returns>
        public TValue this[TKey key]
        {
            get
            {
                if (!this.hashtable.CheckIfKeyExists(key))
                {
                    throw new ArgumentException($"TKey - {key} don`t exist in dictionary.");
                }
                else
                {
                    return this.hashtable.GetItemValue(key);
                }
            }

            set
            {
                if (!this.hashtable.CheckIfKeyExists(key))
                {
                    throw new ArgumentException($"TKey - {key} don`t exist in dictionary.");
                }
                else
                {
                    this.hashtable.UpdateItem(new KeyValuePair<TKey, TValue>(key, value));
                }
            }
        }

        /// <summary>
        /// Добавляет в словарь новую запись.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        public void Add(TKey key, TValue value)
        {
            this.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Добавляет в словарь новую запись.
        /// </summary>
        /// <param name="item">Структура, представляющая из себя пару ключ/значение.</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("item.TKey");
            }

            if (this.hashtable.CheckIfKeyExists(item.Key))
            {
                throw new ArgumentException($"TKey - {item.Key} already exist in dictionary.");
            }
            else
            {
                this.hashtable.AddNewItem(item);
            }
        }

        /// <summary>
        /// Очищает словарь (удаляет все элементы из него).
        /// </summary>
        public void Clear()
        {
            this.hashtable.Clear();
        }

        /// <summary>
        /// Проверяет наличие элемента в словаре.
        /// </summary>
        /// <param name="item">Структура, представляющая из себя пару ключ/значение.</param>
        /// <returns>true если элемент присутствует в словаре и false - если нет.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.hashtable.CheckIfItemExists(item);
        }

        /// <summary>
        /// Проверяет наличие элемента с ключом TKey в словаре.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>true если элемент с заданым ключём присутствует в словаре и false - если нет.</returns>
        public bool ContainsKey(TKey key)
        {
            return this.hashtable.CheckIfKeyExists(key);
        }

        /// <summary>
        /// Копирует элементы словаря в массив, начиная с заданого индекса массива.
        /// </summary>
        /// <param name="array">Массив, в который бутут скопированы элементы словаря.</param>
        /// <param name="arrayIndex">Индекс выходного массива с которого будет начато копирование.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"KeyValuePair<TKey, TValue>[] {array} is null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"Index {arrayIndex} is less then 0.");
            }

            if (array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentException("The number of elements in the dictionary exceeds the length of the array allocated for copying.");
            }

            Array.Copy(this.hashtable.GetAllKeyValuePairs().ToArray(), 0, array, arrayIndex, this.Count);
        }

        /// <summary>
        /// На самом деле я не очень пока понимаю зачем нужен Enumerator и сейчас нет особо времени, чтобы разобраться с этим :`(.
        /// </summary>
        /// <returns>Enumerator для List&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.hashtable.GetAllKeyValuePairs().GetEnumerator();
        }

        /// <summary>
        /// Удаляет элемент с ключём TKey, если такой существует в словаре.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>true если элемент удалён, false - если такого элемента нет в словаре.</returns>
        public bool Remove(TKey key)
        {
            if (!this.hashtable.CheckIfKeyExists(key))
            {
                return false;
            }
            else
            {
                this.hashtable.RemoveItem(key);
                return true;
            }
        }

        /// <summary>
        /// Удаляет из словаря заданый элемент.
        /// </summary>
        /// <param name="item">Элемент, который необходимо удалить.</param>
        /// <returns>true если элемент удалён, false - если такого элемента нет в словаре.</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!this.hashtable.CheckIfItemExists(item))
            {
                return false;
            }
            else
            {
                this.hashtable.RemoveItem(item.Key);
                return true;
            }
        }

        /// <summary>
        /// Попытка достать значаение из таблицы по ключу.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        /// <returns>true если найден элемент в таблице с заданым ключём и false - если нет.</returns>
        /// <exception cref="ArgumentNullException">Происходит в случае, если значение TKey = null.</exception>
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("item.TKey");
            }

            if (!this.hashtable.CheckIfKeyExists(key))
            {
                value = default;
                return false;
            }
            else
            {
                value = this.hashtable.GetItemValue(key);
                return true;
            }
        }

        /// <summary>
        /// Опять этот Enumerator...
        /// </summary>
        /// <returns>Enumerator для List&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.hashtable.GetAllKeyValuePairs().GetEnumerator();
        }
    }
}