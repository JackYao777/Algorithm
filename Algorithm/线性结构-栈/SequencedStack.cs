using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.线性结构_栈
{
    public class SequencedStack<T>
    {
        public T[] _item;
        private const int Empty = -1;
        public int Top { get; set; } = Empty;

        public bool IsEmpty { get => Top == Empty; }

        public bool Full { get => Top == _item.Length - 1; }

        public int Count { get => Top + 1; }

        public SequencedStack() : this(16)
        {

        }
        public SequencedStack(int n)
        {
            _item = new T[2];

        }
        public void Push(T k)
        {
            if (Full)
            {
                DoubleCapacity();
            }
            _item[++Top] = k;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException();
            return _item[Top--];
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException();
            return _item[Top];

        }
        private void DoubleCapacity()
        {
            T[] newItem = new T[_item.Length * 2];
            _item.CopyTo(newItem, 0);
            _item = newItem;
        }
    }
}
