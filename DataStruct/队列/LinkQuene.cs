using DataStruct.栈;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.队列
{
    public class LinkQuene<T> : IQuene<T>
    {
        private Node<T> _front { get; set; }
        private Node<T> _rear { get; set; }
         
        public int Count { get; set; }

        public LinkQuene()
        {
            _front = null;
            _rear = null;
            Count = 0;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (Count == 0)
            {
                _front = newNode; _rear = newNode;
                Count = 1;
            }
            else
            {
                _rear.Next = newNode;
                _rear = newNode;
                Count++;
            }
        }

        public T Dequeue()
        {
            if (Count == 0) Console.WriteLine("队列为null");
            else if (Count == 1)
            {
                T team = _front.Item;
                _front = _rear = null;
                Count = 0;
                return team;
            }
            else
            {
                T teamp = _front.Item;
                _front = _front.Next;
                Count--;
                return teamp;
            }
            return default(T);
        }

        public T Peek()
        {
            if (_front != null)
            {
                return _front.Item;
            }
            return default(T);
        }

        public void Clear()
        {
            _front = null;
            Count = 0;
            _front = null;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }
    }
}
