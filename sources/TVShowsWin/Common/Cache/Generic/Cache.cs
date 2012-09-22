// -----------------------------------------------------------------------
// <copyright file="Cache.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.Cache.Generic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// A Cache implementation
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public sealed class Cache<TValue, TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// The values by key
        /// </summary>
        private readonly Dictionary<TKey, TValue> valuesByKey;

        /// <summary>
        /// The Key Selector
        /// </summary>
        private readonly Func<TValue, TKey> keySelector;

        /// <summary>
        /// The Cache Id
        /// </summary>
        private readonly Guid cacheId;

        /// <summary>
        /// The last modification
        /// </summary>
        private DateTime timestamp;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cache{TValue,TKey}" /> class.
        /// </summary>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="cacheId">The cache id.</param>
        public Cache(Func<TValue, TKey> keySelector, Guid cacheId)
        {
            this.keySelector = keySelector;
            this.cacheId = cacheId;
            IFormatter formatter = new BinaryFormatter();

            using (IsolatedStorageFileStream valuesStream = new IsolatedStorageFileStream(cacheId.ToString(), FileMode.OpenOrCreate))
            {
                if (valuesStream.Length > 0)
                {
                    Dictionary<TKey, TValue> valuesByKey = formatter.Deserialize(valuesStream) as Dictionary<TKey, TValue>;
                    if (valuesByKey != null)
                    {
                        this.valuesByKey = valuesByKey;
                    }
                }
            }

            using (IsolatedStorageFileStream timestampStream = new IsolatedStorageFileStream(cacheId.ToString() + "t", FileMode.OpenOrCreate))
            {
                if (timestampStream.Length > 0)
                {
                    DateTime? timestamp = formatter.Deserialize(timestampStream) as DateTime?;
                    if (timestamp.HasValue)
                    {
                        this.timestamp = timestamp.Value;
                    }
                    else
                    {
                        this.timestamp = DateTime.MinValue;
                    }
                }
            }

            if (this.valuesByKey == null)
            {
                this.valuesByKey = new Dictionary<TKey, TValue>();
            }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IList<TValue> Items
        {
            get
            {
                return this.valuesByKey.Values.ToList();
            }
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp
        {
            get
            {
                return this.timestamp;
            }
        }

        /// <summary>
        /// Gets the <see cref="`0" /> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="`0" />.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The item</returns>
        public TValue this[TKey index]
        {
            get
            {
                return this.Get(index);
            }
        }

        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddOrUpdate(TValue item)
        {
            TKey key = this.keySelector(item);

            if (this.valuesByKey.ContainsKey(key))
            {
                this.valuesByKey[key] = item;
            }
            else
            {
                this.valuesByKey.Add(key, item);
            }

            this.timestamp = DateTime.Now;
        }

        /// <summary>
        /// Updates the timestamp.
        /// </summary>
        public void UpdateTimestamp()
        {
            this.timestamp = DateTime.Now;
        }

        /// <summary>
        /// Determines whether cache contains an item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if cache contains an item with the specified key; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(TKey key)
        {
            return this.valuesByKey.ContainsKey(key);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The Item</returns>
        public TValue Get(TKey key)
        {
            if (this.valuesByKey.ContainsKey(key))
            {
                return this.valuesByKey[key];
            }

            throw new Exception("Item not found");
        }

        /// <summary>
        /// Invalidates this instance.
        /// </summary>
        public void Invalidate()
        {
            this.valuesByKey.Clear();
            this.timestamp = DateTime.MinValue;
            this.Save();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            IsolatedStorageFileStream valuesStream = new IsolatedStorageFileStream(this.cacheId.ToString(), FileMode.OpenOrCreate);
            formatter.Serialize(valuesStream, this.valuesByKey);
            valuesStream.Close();

            IsolatedStorageFileStream timestampStream = new IsolatedStorageFileStream(this.cacheId.ToString() + "t", FileMode.OpenOrCreate);
            formatter.Serialize(timestampStream, this.timestamp);
            timestampStream.Close();
        }
    }
}