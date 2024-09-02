namespace WebApplication1.IOC容器.Services
{
    public class JackContainerBuilder : IServiceProvider
    {

        private JackIOCContainer _iOCContainer;

        public JackContainerBuilder(JackIOCContainer iOCContainer)
        {
            _iOCContainer = iOCContainer;
        }
        public object? GetService(Type serviceType)
        {
            return _iOCContainer.Resolve<Type>();
        }
    }
}
