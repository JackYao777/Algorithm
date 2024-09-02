namespace WebApplication1.全局日志.Services
{

    //包引用nuget:
    //Serilog.AspNetCore,
    //Serilog.Sinks.Async,
    //Serilog.Sinks.Console,
    //Serilog.Sinks.File
    public class ExceptServiceTest
    {
        public void Test()
        {
            string num = "sdf";
            int convertNum = Convert.ToInt32(num);
        }
    }
}
