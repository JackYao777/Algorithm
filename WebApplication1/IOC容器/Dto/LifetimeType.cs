namespace WebApplication1.IOC容器.Dto
{
    public enum LifetimeType
    {
        Transient, //瞬时
        Singleton,
        Scope, //作用域
        PerThread //线程单例
        //外部可释放单例
    }
}
