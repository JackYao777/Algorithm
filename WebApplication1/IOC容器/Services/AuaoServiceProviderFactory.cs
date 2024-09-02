using Autofac;

namespace WebApplication1.IOC容器.Services
{
    public class AuaoServiceProviderFactory : IServiceProviderFactory<JackContainerBuilder>
    {
        public IServiceProvider CreateServiceProvider(JackContainerBuilder containerBuilder)
        {
            return containerBuilder;
        }

         JackContainerBuilder IServiceProviderFactory<JackContainerBuilder>.CreateBuilder(IServiceCollection services)
        {
            return new JackContainerBuilder(new JackIOCContainer());
        }
    }
}
