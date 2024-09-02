using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.观察者模式
{
    public interface ITianDogObserver
    {
        void Update(string message);
    }
}
