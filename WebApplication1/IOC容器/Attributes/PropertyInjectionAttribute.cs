namespace WebApplication1.IOC容器.Attributes
{
    /// <summary>
    /// 属性注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectionAttribute : Attribute
    {
    }
}
