using WebApplication1.IOC容器.Attributes;
using WebApplication1.IOC容器.IServices;

namespace WebApplication1.IOC容器.Services
{
    public class TestServiceD : ITestServiceD
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        [PropertyInjection]
        public ITestServiceA TestServiceA { get; set; }

        /// <summary>
        /// 带有别名的属性注入
        /// </summary>
        [ParameterShortName("ServiceB")]
        [PropertyInjection]
        public ITestServiceB TestServiceB { get; set; }

        public TestServiceD()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }

        #region 构造函数注入

        private readonly ITestServiceA _testServiceA;
        private readonly ITestServiceB _testServiceB;
        [ConstructorInjection] //优先选择带有构造函数注入特性的
        public TestServiceD(ITestServiceA testServiceA, [ParameterConstant] string sValue, ITestServiceB testServiceB, [ParameterConstant] int iValue)
        {
            Console.WriteLine($"{this.GetType().Name}--{sValue}--{iValue}被构造。。。");
            _testServiceA = testServiceA;
            _testServiceB = testServiceB;
        }

        #endregion 构造函数注入

        #region 方法注入

        private ITestServiceC _testServiceC;
        [MethodInjection]
        public void Init(ITestServiceC testServiceC)
        {
            _testServiceC = testServiceC;
        }

        #endregion 方法注入

        public void Show()
        {
            Console.WriteLine($"This is {this.GetType().Name} Show");
        }
    }
}
