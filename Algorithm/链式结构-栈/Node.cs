using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.链式结构_栈
{
    public class Node<T>
    {
        private T item;

        private Node<T> next;

        public T Item { get => item; set => item = value; }
        public Node<T> Next { get => next; set => next = value; }

        public Node(T value)
        {
            item = value;
        }
        public Node()
        {

        }

        public override string ToString()
        {
            return item.ToString();
        }
    }

    public class NodeList<T>   //where T : notnull
    {
        public Node<T> Head;

        private int length;
        [ThreadStatic] private static Node<T> currntNode;
        public virtual Node<T> CurrentNode
        {
            get
            {
                if (Head.Next == null) currntNode = Head;
                return currntNode;
            }
            set
            {
                currntNode = value;
            }
        }

        public NodeList()
        {
            Head = new Node<T>();
            currntNode = new Node<T>();
            CurrentNode = Head;
        }

        public NodeList(Node<T> firstnode) : this()
        {
            Head.Next = firstnode;
        }

        public NodeList(T[] array) : this()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Node<T> node = new Node<T>(array[i]);
                CurrentNode.Next = node;
                if (i == 0) Head.Next = node;
                CurrentNode = CurrentNode.Next;
            }
        }

        public virtual int Length
        {
            get
            {
                Node<T> node = Head;
                length = 0;
                while (node != null)
                {
                    node = node.Next;
                    length++;
                }
                return length;
            }

            set => length = value;
        }

        /// <summary>
        /// 添加数据项 ,为了方便循环单向链表 继承后修改改方法，所以改方法设置成virtual 
        /// </summary>
        public virtual void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (CurrentNode == null) { CurrentNode = new Node<T>(); CurrentNode = newNode; Head = newNode; }
            else
            {
                CurrentNode.Next = newNode;
                CurrentNode = CurrentNode.Next;
            }
        }

        /// <summary>
        /// 在指定的索引位置之后插入元素 ,为了方便循环单向链表 继承后修改改方法，所以改方法设置成virtual 
        /// </summary>
        /// <param name="index">索引位置</param>
        /// <param name="item"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public virtual void Insert(int index, T item)
        {
            Node<T> node = new Node<T>(item);
            if (index < 0 || index > Length) throw new IndexOutOfRangeException();

            CurrentNode = Head;

            Node<T> nextnode = CurrentNode.Next;

            int i = 0;
            while (CurrentNode != null)
            {
                if (i == index)
                {
                    break;
                }
                CurrentNode = nextnode;
                nextnode = nextnode.Next;
                i++;
            }
            node.Next = CurrentNode.Next;
            CurrentNode.Next = node;
        }

        /// <summary>
        ///  在队列的末尾添加 数据元素
        /// </summary>
        /// <param name="item"></param>
        public virtual void Append(T item)
        {
            Node<T> node = new Node<T>(item);
            if (Head == null) { Head = node; return; }
            CurrentNode = Head;

            Node<T> nextnode = CurrentNode.Next;
            while (nextnode != null)
            {
                CurrentNode = nextnode;
            }
            CurrentNode.Next = node;

        }
        /// <summary>
        ///  删除出现item的数据元素  
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {

            if (Head == null) { throw new ArgumentOutOfRangeException(nameof(item)); }
            CurrentNode = Head;

            Node<T> nextnode = CurrentNode.Next;
            if (CurrentNode.Item.Equals(item)) { Head = nextnode; }

            while (nextnode != null)
            {
                if (nextnode.Item.Equals(item))
                {
                    CurrentNode.Next = nextnode.Next;
                    return;
                }
                CurrentNode = nextnode;
                nextnode = nextnode.Next;
            }

            Console.WriteLine("未找到删除的元素");


        }
        /// <summary>
        /// 删除指定索引的元素
        /// </summary>
        /// <param name="i"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int i)
        {
            if (Head == null || i < 0 || i > Length) { throw new IndexOutOfRangeException(); }
            if (i == 0) { Head = null; return; }
            CurrentNode = Head;

            Node<T> nextnode = CurrentNode.Next;
            int n = 0;

            while (nextnode != null)
            {
                if (i - 1 == n)
                {
                    CurrentNode.Next = nextnode.Next;
                    return;
                }
                CurrentNode = nextnode;
                nextnode = nextnode.Next;
                n++;
            }
            if (Length == i) { CurrentNode = null; return; }
            Console.WriteLine("未找到删除的元素");
        }

        public void Reverse()
        {
            if (Head.Next == null) return;
            CurrentNode = Head.Next;

            Node<T> nextnode = CurrentNode.Next;

            Node<T> prenode;
            int n = 0;
            while (nextnode != null)
            {

                prenode = CurrentNode;
                if (n == 0) prenode.Next = null;

                CurrentNode = nextnode;

                nextnode = nextnode.Next;
                CurrentNode.Next = prenode;

                n++;

            }

            Head.Next = CurrentNode;
        }
    }
}
