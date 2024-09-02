using Algorithm.DesignModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DesignModel
{
    //饿汉式
    public class SingleModel
    {
        private static SingleModel _singleModel = new SingleModel();

        public static SingleModel CreateSingleModel()
        {
            return _singleModel;
        }

        public void showMessage()
        {
            Console.WriteLine("Hello World!"); ;
        }
    }

    //懒汉式
    public class Singleton
    {
        private static readonly object locker = new object();
        private static Singleton instance;

        /// <summary>
        /// 构造方法为private，可以僻免外界通过利用new创建此类实例的可能
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// 此方法为获得本类实例的唯一全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton CreateSingleModel()
        {
            lock (locker)
            {
                if (instance is null)
                {
                    instance = new Singleton();
                    return instance;
                }
            }
            return instance;
        }

        public static Singleton GetInstance()
        {
            // 判断1
            if (instance == null)
            {
                lock (locker)
                {
                    // 判断2
                    if (instance == null)
                    {
                        instance = new Singleton();
                        return instance;
                    }
                }
            }
            return instance;
        }
    }
}
