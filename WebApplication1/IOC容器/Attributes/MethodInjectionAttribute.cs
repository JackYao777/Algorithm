namespace WebApplication1.IOC容器.Attributes
{
    /// <summary>
    /// 构造函数注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodInjectionAttribute : Attribute
    {
    }
}
