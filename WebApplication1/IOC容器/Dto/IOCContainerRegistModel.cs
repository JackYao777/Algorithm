namespace WebApplication1.IOC容器.Dto
{
    [Serializable]
    public class IOCContainerRegistModel
    {
        public Type TargetType { get; set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public LifetimeType Lifetime { get; set; }

        /// <summary>
        /// 仅限单例
        /// </summary>
        public object SingletonInstance { get; set; }
    }
}
