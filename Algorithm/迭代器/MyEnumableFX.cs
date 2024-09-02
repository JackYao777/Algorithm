using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.迭代器
{
    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] items;

        public MyCollection()
        {
            items = new T[3];
            items[0] = (T)Convert.ChangeType("Apple", typeof(T));
            items[1] = (T)Convert.ChangeType("Banana", typeof(T));
            items[2] = (T)Convert.ChangeType("Orange", typeof(T));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerators<T>(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerators<T> : IEnumerator<T>
    {
        private T[] items;
        private int position = -1;

        public MyEnumerators(T[] collection)
        {
            items = collection;
        }

        public T Current
        {
            get
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++;
            return (position < items.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            // 可选的资源清理代码
        }
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        MyCollection<string> collection = new MyCollection<string>();

    //        foreach (var item in collection)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }
    //}
}
