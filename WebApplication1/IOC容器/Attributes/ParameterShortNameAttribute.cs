namespace WebApplication1.IOC容器.Attributes
{
    /// <summary>
    /// 简称（别名）
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class ParameterShortNameAttribute : Attribute
    {
        public string ShortName { get; private set; }
        public ParameterShortNameAttribute(string shortName)
        {
            this.ShortName = shortName;
        }
    }
}
