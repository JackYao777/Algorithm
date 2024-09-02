using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.观察者模式
{
    public interface IGreenTeaBitchSubject
    {
        void Add(ITianDogObserver tianDogObserver);
        void Remove(ITianDogObserver tianDogObserver);

        void NotifyState(string state);
    }
}
