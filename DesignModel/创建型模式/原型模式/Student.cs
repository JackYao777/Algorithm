using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.原型模式
{
    //https://baijiahao.baidu.com/s?id=1752544006516151301
    public class Student : ICloneable
    {
        public string Name { get; set; }

        public int Age { get; set; }


        public Dog Dog { get; set; }
        public object Clone()
        {
            return MemberwiseClone();//浅拷贝,序列化才是深拷贝
        }
    }

    public class Dog
    {
        public int Fat { get; set; }
        public string Name { get; set; }
    }

    //浅拷贝,属性里面的对象不会进行深拷贝,
    //[Fact]
    //public async Task TestYuanXingMoshi()
    //{
    //    Student student = new Student()
    //    {
    //        Age = 19,
    //        Name = "JackLove",
    //        Dog = new Dog()
    //        {
    //            Fat = 1,
    //            Name = "小黄"
    //        }
    //    };

    //    var newStudent = student.Clone();

    //    student.Age = 20;
    //    student.Dog.Fat = 2;
    //}
}
