using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.队列
{
    public interface IQuene<T>
    {
        void Enqueue(T value);

        T Dequeue();

        T Peek();

        void Clear();

        bool IsEmpty();

        bool IsFull();

    }
}
