using Serilog;

namespace WebApplication1.全局日志.Dtos
{
    public static class SerilogConfig
    {
        public static void InitConfig()
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("serilogsettings.json", optional: false, reloadOnChange: true);
            var configurationRoot = configurationBuilder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configurationRoot)
                .CreateLogger();

            Log.Information("看看是日志配置成功");
        }
    }
}
