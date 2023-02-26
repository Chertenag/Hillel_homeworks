using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Hillel_hw_8
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private MyHashTable<TKey, TValue> hashtable = new();

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
        /// то пусть в моей имплементации словаря будет словарь всегда доступный для записи.
        /// Хотя по сути он, у меня, ни на что не влияет, а подглядывть в реализацию Dictionary не интересно.
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

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
                throw new ArgumentNullException("The TKey value cannot be null.");
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
        /// Проверяет ниличие элемента с ключом TKey в словаре.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>true если элемент с заданым ключём присутствует в словаре и false - если нет.</returns>
        public bool ContainsKey(TKey key)
        {
            return this.hashtable.CheckIfKeyExists(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// На самом деле я не очень пока понимаю зачем нужен Enumerator и сейчас нет особо времени, чтобы разобраться с этим ;(
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
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException($"The TKey value cannot be null.");
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}