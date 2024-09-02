using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.迭代器模式
{
    public interface Iterator
    {
        object Current { get; }

        bool MoveNext();

        void Reset();
    }
}
