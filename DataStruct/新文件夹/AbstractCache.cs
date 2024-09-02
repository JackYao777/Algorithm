using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataStruct.新文件夹
{
    public abstract class BaseClass
    {
        public static string GetBucketName;

        static BaseClass()
        {
            Initialization();
        }
        public static void Initialization()
        { 
        
        }
        public static void StaticMethod()
        {
            Console.WriteLine("Base Class - Static Method");
        }

        public static void Ceshi()
        {
            Console.WriteLine("Base Class - Static Method");
        }
    }

    public class DerivedClass : BaseClass
    {
        static DerivedClass()
        {
            Initialization();
        }

        // 创建新的静态方法，并调用原始的静态方法作为默认实现
        public new static void StaticMethod()
        {
            Console.WriteLine("Derived Class - Overridden Static Method");

            // 调用原始的静态方法
         
        }

        public new static void Initialization()
        {
            GetBucketName = "ceshi";
        }
    }
}
