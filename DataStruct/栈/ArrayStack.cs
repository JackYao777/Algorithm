using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.栈
{
    public interface IArrayStack<T>
    {
        /// <summary>
        /// 向栈顶压入数据
        /// </summary>
        /// <param name="value">值</param>
        void Push(T value);
        /// <summary>
        /// 弹出栈顶数据
        /// </summary>
        T Pop();
        /// <summary>
        /// 查看栈顶数据，但不弹出
        /// </summary>
        /// <returns></returns>
        T Peek();
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        /// <summary>
        /// 清空栈
        /// </summary>
        void Clear();

        int GetLenth();

        int Count { get; }

    }

    /// <summary>
    /// 数组栈   （先进后出）1:先初始化空间
    /// </summary>
    /// <summary>
    /// 栈---数组实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayStack<T> : IArrayStack<T>
    {
        private T[] _data;

        //private int _count;

        private int _top;

        public T[] Data { get { return _data; } set { _data = value; } }

        //public int Count { get { return _top + 1; } }

        public int Top { get { return _top; } }

        public int Count
        {
            get { return _top + 1; }
        }

        public ArrayStack(int capcity)
        {
            _data = new T[capcity];
            _top = -1;
        }

        public ArrayStack() : this(10) { }

        public void Clear()
        {
            _data = null;
            _top = -1;
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public void Push(T value)
        {
            if (Count == _data.Length) { Console.WriteLine("栈已经满了"); }
            else
            {
                _data[_top + 1] = value;
                _top++;
            }
        }

        public T Pop()
        {
            if (Count > 0)
            {
                T teamp = _data[_top];
                _top--;
                return teamp;
            }
            return default(T);
        }
        public T Peek()
        {
            if (Count > 0)
            {
                return _data[_top];
            }
            return default(T);
        }

        public int GetLenth()
        {
            return Count;
        }
    }

    //    public class Program
    //    {
    //        public static void Main()
    //        {
    //            Stack stack = new Stack(5);
    //            stack.Push(1);
    //            stack.Push(2);
    //            stack.Push(3);
    //            stack.Push(4);
    //            stack.Push(5);

    //            Console.WriteLine("Peeked item: " + stack.Peek());

    //            stack.Pop();
    //            stack.Pop();
    //            stack.Pop();
    //            stack.Pop();
    //            stack.Pop();

    //            Console.WriteLine("Peeked item: " + stack.Peek());
    //        }
    //    }
    //}
}
