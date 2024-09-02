using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.观察者模式
{
    public class ShangGuanSubject : IGreenTeaBitchSubject
    {
        private List<ITianDogObserver> tianDogObservers = new List<ITianDogObserver>();
        public void Add(ITianDogObserver tianDogObserver)
        {
            tianDogObservers.Add(tianDogObserver);
        }

        public void NotifyState(string state)
        {
            foreach (var observer in tianDogObservers)
            {
                observer.Update(state);
            }
        }

        public void Remove(ITianDogObserver tianDogObserver)
        {
            tianDogObservers.Remove(tianDogObserver);
        }
    }
}
