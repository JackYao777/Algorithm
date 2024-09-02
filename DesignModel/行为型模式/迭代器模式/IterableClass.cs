using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.迭代器模式
{
    //public class IterableClass : Iterator<IterableClass>
    //{
    //    List<IterableClass> list = new List<IterableClass>();
    //    public Iterator<IterableClass> iterator()
    //    {
    //        throw new NotImplementedException();
    //    }


    //    private class Itr : Iterator<IterableClass>
    //    {

    //        int index = 0;


    //        public bool HasNext()
    //        {
    //            //if (index < list.Count())
    //            //{
    //            //    return true;
    //            //}
    //            return false;
    //        }


    //        public IterableClass Next()
    //        {
    //            //    //IterableClass student = list.GetEnumerator(index);
    //            //index++;
    //            //return student;
    //            return new IterableClass();
    //        }
    //    }
    //}


    public class MyCollection : Iterable
    {
        private int[] data;

        public MyCollection(int[] arr)
        {
            data = arr;
        }

        public Iterator GetEnumerator()
        {
            return new MyEnumerator(data);
        }
    }

    public class MyEnumerator : Iterator
    {
        private int[] data;
        private int position = -1;

        public MyEnumerator(int[] arr)
        {
            data = arr;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= data.Length)
                {
                    throw new InvalidOperationException();
                }
                return data[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < data.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }

    public class TestDemo
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 3, 4, 5 };
        //    MyCollection collection = new MyCollection(arr);

        //    foreach (int i in collection)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
    }

}
