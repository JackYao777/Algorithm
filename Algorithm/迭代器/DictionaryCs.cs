using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.迭代器
{
    internal class DictionaryCs<TKey, TValue>
    {
        private int capacity;
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        public DictionaryCs()
        {
            capacity = 10; // 默认容量为10
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            var bucket = buckets[bucketIndex];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists in the dictionary.");
                }
            }

            bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] != null)
            {
                var bucket = buckets[bucketIndex];
                foreach (var pair in bucket)
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] != null)
            {
                var bucket = buckets[bucketIndex];
                foreach (var pair in bucket)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return hashCode % capacity;
        }

        // 其他方法和实现细节省略...
    }
}
