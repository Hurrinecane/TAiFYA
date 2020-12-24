using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TAiFYA;

namespace HashTable
{
    public class IdentityTablesRow
    {
        public int number;
        public string lexeme;
        public string type;
    }

    /// <summary>
    /// Элемент данных хеш таблицы.
    /// </summary>
    public class Item
    {
        public string Key { get; private set; }


        public IdentityTablesRow Value { get; private set; }

        public Item(string key, string lexeme)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrEmpty(lexeme))
            {
                throw new ArgumentNullException(nameof(lexeme));
            }
            Key = key;
            Value = new IdentityTablesRow
            {
                lexeme = lexeme,
                type = SetType(lexeme)
            };
        }

        private string SetType(string lexeme)
        {
            //const string RegWords = @"\b[a-zA-Z]+[a-zA-Z0-9]*\b";
            const string RegLogicalOperations = @"\b(true|false|and|or|xor|not)\b";
            const string RegDataType = @"\b(int|double|float|bool|string|decimal)\b";
            const string RegInt = @"\b\d+\b";
            const string RegDouble = @"\b\d+\.?\d*\b";

            if (Regex.IsMatch(lexeme, RegDataType))
            {
                return "Data Type";
            }
            else if (Regex.IsMatch(lexeme, RegLogicalOperations))
            {
                return "Logical Operation";
            }
            if (Regex.IsMatch(lexeme, RegDouble))
            {
                return "Double";
            }
            if (Regex.IsMatch(lexeme, RegInt))
            {
                return "Int";
            }
            else 
            {
                return "Variable";
            }
        }

        public override string ToString()
        {
            return Key;
        }
    }

    /// <summary>
    /// Хеш-таблица.
    /// </summary>
    /// <remarks>
    /// Используется метод цепочек (открытое хеширование).
    /// </remarks>
    public class Hashtable
    {
        private int numberOfRows = 0;

        /// <summary>
        /// Максимальная длина ключевого поля.
        /// </summary>
        private readonly byte _maxSize = 255;

        /// <summary>
        /// Коллекция хранимых данных.
        /// </summary>
        /// <remarks>
        /// Представляет собой словарь, ключ которого представляет собой хеш ключа хранимых данных,
        /// а значение это список элементов с одинаковым хешем ключа.
        /// </remarks>
        private readonly Dictionary<int, List<Item>> _items = null;

        /// <summary>
        /// Коллекция хранимых данных в хеш-таблице в виде пар Хеш-Значения.
        /// </summary>
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();

        /// <summary>
        /// Создать новый экземпляр класса HashTable.
        /// </summary>
        public Hashtable()
        {
            // Инициализируем коллекцию максимальным количество элементов.
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }


        /// <summary>
        /// Добавить данные в хеш таблицу.
        /// </summary>
        /// <param name="key"> Ключ хранимых данных. </param>
        /// <param name="value"> Хранимые данные. </param>
        public void Insert(string key, string value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            // Создаем новый экземпляр данных.

            var item = new Item(key, value);

            // Получаем хеш ключа
            var hash = GetHash(item.Key);

            // Получаем коллекцию элементов с таким же хешем ключа.
            // Если коллекция не пустая, значит заначения с таким хешем уже существуют,
            // следовательно добавляем элемент в существующую коллекцию.
            // Иначе коллекция пустая, значит значений с таким хешем ключа ранее не было,
            // следовательно создаем новую пустую коллекцию и добавляем данные.
            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                // Получаем элемент хеш таблицы.
                hashTableItem = _items[hash];

                // Проверяем наличие внутри коллекции значения с полученным ключом.
                // Если такой элемент найден, то сообщаем об ошибке.
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    return;
                }

                // Добавляем элемент данных в коллекцию элементов хеш таблицы.
                item.Value.number = ++numberOfRows;
                _items[hash].Add(item);
            }
            else
            {
                // Создаем новую коллекцию.
                item.Value.number = ++numberOfRows;
                hashTableItem = new List<Item> { item };

                // Добавляем данные в таблицу.
                _items.Add(hash, hashTableItem);
            }
        }

        /// <summary>
        /// Удалить данные из хеш таблицы по ключу.
        /// </summary>
        /// <param name="key"> Ключ. </param>
        public void Delete(string key)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }

            // Получаем хеш ключа.
            var hash = GetHash(key);

            // Если значения с таким хешем нет в таблице, 
            // то завершаем выполнение метода.
            if (!_items.ContainsKey(hash))
            {
                return;
            }

            // Получаем коллекцию элементов по хешу ключа.
            var hashTableItem = _items[hash];

            // Получаем элемент коллекции по ключу.
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);

            // Если элемент коллекции найден, 
            // то удаляем его из коллекции.
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        /// <summary>
        /// Поиск значения по ключу.
        /// </summary>
        /// <param name="key"> Ключ. </param>
        /// <returns> Найденные по ключу хранимые данные. </returns>
        public bool ContainsKey(string key)
        {
            // Получаем хеш ключа.
            var hash = GetHash(key);

            // Если таблица не содержит такого хеша,
            // то завершаем выполнения метода вернув null.
            if (!_items.ContainsKey(hash))
            {
                return false;
            }
            else return true;
        }

        public IdentityTablesRow Search(string key)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }

            // Получаем хеш ключа.
            var hash = GetHash(key);

            // Если таблица не содержит такого хеша,
            // то завершаем выполнения метода вернув null.
            if (!_items.ContainsKey(hash))
            {
                return null;
            }

            // Если хеш найден, то ищем значение в коллекции по ключу.
            var hashTableItem = _items[hash];
            if (hashTableItem != null)
            {
                // Получаем элемент коллекции по ключу.
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                // Если элемент коллекции найден, 
                // то возвращаем хранимые данные.
                if (item != null)
                {
                    return item.Value;
                }
            }

            // Возвращаем null если ничего найдено.
            return null;
        }

        /// <summary>
        /// Хеш функция.
        /// </summary>
        /// <remarks>
        /// Возвращает длину строки.
        /// </remarks>
        /// <param name="value"> Хешируемая строка. </param>
        /// <returns> Хеш строки. </returns>
        private int GetHash(string value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value));
            }

            // Получаем длину строки.
            var hash = value.Length;
            return hash;
        }
    }
}