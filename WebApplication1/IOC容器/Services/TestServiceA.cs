﻿using WebApplication1.IOC容器.IServices;

namespace WebApplication1.IOC容器.Services
{
    public class TestServiceA : ITestServiceA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }

        public void Show()
        {
            Console.WriteLine($"This is {this.GetType().Name} Show");
        }
    }
}
