using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.迭代器
{
    public class MyCollection : IEnumerable
    {
        private object[] items;

        public MyCollection()
        {
            items = new object[3];
            items[0] = "Apple";
            items[1] = "Banana";
            items[2] = "Orange";
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(items);
        }
    }

    public class MyEnumerator : IEnumerator
    {
        private object[] items;
        private int position = -1;

        public MyEnumerator(object[] collection)
        {
            items = collection;
        }

        public object Current
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

        public bool MoveNext()
        {
            position++;
            return (position < items.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        MyCollection collection = new MyCollection();

    //        foreach (var item in collection)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }
    //}

}
