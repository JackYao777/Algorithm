using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.观察者模式
{
    public class ObserverClient
    {
        public void sendThink()
        {
            IGreenTeaBitchSubject subject = new ShangGuanSubject();
            Dog2WangObserver dog2WangObserver = new Dog2WangObserver();
            subject.Add(dog2WangObserver);
            subject.Add(new YinDangObserver());

            Console.WriteLine("------午夜12点，肚子好饿，找个人来买东西吃------");
            subject.NotifyState("肚子好饿");
            Console.WriteLine("------又被渣男甩了，有点小难过，找个人来安慰一下------");
            subject.NotifyState("心情不好");
            Console.WriteLine("------二狗终于看透了上官这个绿茶婊，和牛翠花走到了一起------");
            subject.Remove(dog2WangObserver);
            Console.WriteLine("------上官又被渣男甩了，想找个人来安慰一下，却不见了那个好人的身影------");
            subject.NotifyState("心情不好");
        }
    }
}
