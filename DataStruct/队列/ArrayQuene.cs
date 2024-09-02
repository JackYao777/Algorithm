using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataStruct.队列
{
    public class ArrayQuene<T> : IQuene<T>
    {

        private T[] _item;

        private int _front;//队首

        private int _rear;//队尾

        private int _count;//数量

        public ArrayQuene(int capcty)
        {
            _item = new T[capcty];
            _count = 0;
            _front = _rear = -1;
        }

        public ArrayQuene() : this(10) { }

        public void Clear()
        {
            _front = _rear = -1;
            //_item = null;
            _count = 0;
        }

        public void Enqueue(T value)
        {
            if (IsFull()) Console.WriteLine("空间已经满了");
            else
            {
                if (_rear == _item.Length - 1)
                {
                    _item[0] = value;
                    _count++;
                    _rear = 0;
                }
                else
                {
                    _item[_rear + 1] = value;
                    _count++;
                    _rear++;
                }
            }

        }
        public T Dequeue()
        {
            if (_count <= 0) return default(T);
            else
            {
                var teamp = _item[_front + 1];
                _count--;
                _front++;
                return teamp;
            }
        }

        public T Peek()
        {
            if (_count <= 0) return default(T);
            else
            {
                return _item[_front + 1];
            }
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _item.Length;


        }
       
    }



    //public class Program
    //{
    //    public static void Main()
    //    {
    //        Queue<int> queue = new Queue<int>(5);
    //        queue.Enqueue(1);
    //        queue.Enqueue(2);
    //        queue.Enqueue(3);
    //        queue.Enqueue(4);
    //        queue.Enqueue(5);

    //        Console.WriteLine("Peeked item: " + queue.Peek());

    //        queue.Dequeue();
    //        queue.Dequeue();
    //        queue.Dequeue();
    //        queue.Dequeue();
    //        queue.Dequeue();

    //        Console.WriteLine("Peeked item: " + queue.Peek());
    //    }
    //}
}
