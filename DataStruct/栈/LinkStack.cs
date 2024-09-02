using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStruct.栈
{
    public class Node<T>
    {
        private T _item;

        private Node<T> _next;

        public T Item { get { return _item; } set { _item = value; } }

        public Node<T> Next { get { return _next; } set { _next = value; } }


        public Node()
        {
            _item = default(T);
            _next = null;
        }
        public Node(T value)
        {
            _item = value;
            _next = null;
        }
        public Node(T value, Node<T> next)
        {
            _item = value;
            _next = next;
        }

        public Node(Node<T> next)
        {
            _item = default(T);
            _next = next;
        }

        public override string ToString()
        {
            return Item.ToString();
        }
    }


    public class LinkStack<T> : IArrayStack<T>
    {
        private Node<T> _head;

        private int _count = 0;

        public LinkStack(Node<T> node)
        {
            _head = node;
            while (_head != null)
            {
                node = node.Next;
                _count++;
            }
        }

        public LinkStack()
        {
            _head = new Node<T>();
            _count = 1;
        }

        public int Count { get { return _count; } }

        public void Clear()
        {
            _count = 0;
            _head = null;
        }

        public int GetLenth()
        {
            return _count;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Push(T value)
        {
            //if (_head == null)
            //{
            //    Node<T> teamp = new Node<T>(value);
            //    _head = teamp;
            //    _count++;
            //}
            //else
            //{
            Node<T> teamp = new Node<T>(value);
            teamp.Next = _head;
            _head = teamp;
            _count++;
            //}
        }


        public T Pop()
        {
            if (_head == null) return default(T);
            else
            {
                T teamp = _head.Item;
                _head = _head.Next;
                return teamp;
            }
        }

        public T Peek()
        {
            if (_head == null) return default(T);
            else
            {
                return _head.Item;
            }
        }
    }
}
