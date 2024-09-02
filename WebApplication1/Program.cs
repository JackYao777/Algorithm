using Autofac.Extensions.DependencyInjection;
using DotNetCore.CAP.Messages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using WebApplication1.Emuns;
using WebApplication1.ID4鉴权服务;
using WebApplication1.IOC容器.Services;
using WebApplication1.JWT鉴权服务;
using WebApplication1.JWT鉴权服务.Context;
using WebApplication1.JWT鉴权服务.Midwares;
using WebApplication1.全局日志.Dtos;
using WebApplication1.全局日志.filters;
using WebApplication1.全局日志.Services;
using WebApplication1.动态代理.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IAuthenticationHandler
            //DefaultAuthenticationManager
            //AuthenticationManager
            //HttpContext
            //ConfigurationBuilder
            //IApplicationBuilder
            //HostBuilder
            #region 可以看到 configureDefaults的说明，添加各种配置
            //WebApplication.CreateBuilder(args).Host.UseContentRoot(Directory.GetCurrentDirectory()).ConfigureHostConfiguration(config =>
            //{
            //    config.AddEnvironmentVariables(prefix: "DOTNET_");
            //    if (args is { Length: > 0 })
            //    {
            //        config.AddCommandLine(args);
            //    }
            //}).ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    IHostEnvironment env = hostingContext.HostingEnvironment;
            //    bool reloadOnChange = false;

            //    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: reloadOnChange)
            //            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: reloadOnChange);

            //    if (env.IsDevelopment() && env.ApplicationName is { Length: > 0 })
            //    {
            //        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            //        if (appAssembly is not null)
            //        {
            //            config.AddUserSecrets(appAssembly, optional: true, reloadOnChange: reloadOnChange);
            //        }
            //    }

            //    config.AddEnvironmentVariables();

            //    if (args is { Length: > 0 })
            //    {
            //        config.AddCommandLine(args);
            //    }
            //}).ConfigureLogging((hostingContext, logging) => { }).UseDefaultServiceProvider((context, options) =>
            //{
            //    bool isDevelopment = context.HostingEnvironment.IsDevelopment();
            //    options.ValidateScopes = isDevelopment;
            //    options.ValidateOnBuild = isDevelopment;
            //});
            #endregion
            #region configurationBuilder配置构建者模式
            //https://tool.4xseo.com/a/9104.html
            //new HostBuilder().ConfigureAppConfiguration((context, configurationBuilder) =>
            //{
            //    configurationBuilder.AddCommandLine(args);   // 命令行配置源
            //    configurationBuilder.AddEnvironmentVariables();   // 环境配置源
            //    configurationBuilder.AddJsonFile("demo.json");   // json文件配置源
            //    configurationBuilder.AddInMemoryCollection();
            //});

            #endregion
            #region 添加Serilog全局日志
            SerilogConfig.InitConfig();
            #endregion

            var builder = WebApplication.CreateBuilder(args); //https://www.cnblogs.com/guoxiaotian/p/16950078.html 源代码调试

            #region  替换工厂
            //builder.Host.UseServiceProviderFactory(new AuaoServiceProviderFactory());
            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            #endregion

            // Add services to the container.
            #region  注入服务
            builder.Services.AddScoped<ExceptServiceTest>();
            builder.Services.AddScoped<DynamicService>();
            #endregion

            builder.Services.AddControllers(mvcoption =>
            {
                mvcoption.Filters.Add(typeof(AbpAsyncExceptionFilter));//注入异常过滤器

            });

            #region 绑定端口号
            builder.WebHost.ConfigureKestrel(option =>
            {
                string? listenPort = builder.Configuration.GetSection("ConnectionStrings")["ListenPort"]!.ToString();
                option.ListenAnyIP(8099);
            });
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(waggenoption =>
            {
                waggenoption.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v0.0.1",
                    Title = "CeShi",
                    Description = $"百宝箱接口文档说明",
                    Contact = new OpenApiContact()
                    {
                        Name = "zhiwei",
                        Email = "zhiwei@qq.com",
                        Url = null
                    }
                });

                var xmlFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml");
                foreach (var xmlFile in xmlFiles)
                {
                    waggenoption.IncludeXmlComments(xmlFile, true);
                }

                waggenoption.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Bearer ",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    //Type = SecuritySchemeType.ApiKey,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });


                var scheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                waggenoption.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    [scheme] = new string[0]
                });
                //添加对枚举的描述
                waggenoption.SchemaFilter<EnumSwaggerDocumentFilter>();
            });

            #region 注入JWT服务以及鉴权服务所需的配置,以及Indentity4配置服务
            //jwt
            //builder.AddAuthcations();

            //id4
            builder.AddID4Authcations();
            #endregion

            builder.Services.AddHttpClient();

            #region 设置跨域
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("any", opt => opt
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });
            #endregion

            #region
            builder.Services.AddCap(x =>
            {
                x.UseMySql(builder.Configuration.GetConnectionString("JwtDemoDatabase"));
                x.UseRabbitMQ("127.0.0.1:15672");
                x.FailedRetryCount = 10;//重试次数
                x.FailedRetryInterval = 30;//重试的间隔频率
                x.FailedThresholdCallback = faield => {
                    Log.Error($"MessageType{faield.MessageType}失败了，重试了{x.FailedRetryCount}次,消息名称:{faield.Message.GetName()}");
                    //这边要发通知让人工处理
                };
            });
            #endregion

            var app = builder.Build();//这里才是启动的核心,前面时将数据配置进去
            //new WebHostBuilder().Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("any");

            #region 添加Jwt过期无感刷新token中间件
            //app.UseMiddleware<JwtTokenMidware>();

            //RequestDelegate requestDelegate;

            //Func<Task> func = async () =>
            //{
            //    Console.WriteLine("this is OK Start");
            //};

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("This is Hello World 1 Start!");
            //    await next.Invoke();
            //    Console.WriteLine("This is Hello World 1 End!");
            //});
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("This is Hello World 2 Start!");
            //    await next.Invoke();
            //    Console.WriteLine("This is Hello World 2 End!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("This is Hello World 3 Start!");
            //    await next();
            //    Console.WriteLine("This is Hello World 3 End!");
            //});

            ////Func<HttpContext, Func<Task>, Task> middleware2;
            //IApplicationBuilder appbuilder = new ApplicationBuilder(app.Services);


            ////var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "奥巴马") }, CookieAuthenticationDefaults.AuthenticationScheme));
            ////SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
            ////appbuilder.Use(next =>
            ////{
            ////    return async ctx =>
            ////    {
            ////        System.Console.WriteLine("Enter middleware 1");
            ////        await next(ctx);
            ////        System.Console.WriteLine("Exit middleware 1");
            ////    };
            ////});

            ////appbuilder.Use(async (context, next) =>
            ////{
            ////    System.Console.WriteLine("Enter middleware 4");
            ////    await next.Invoke();
            ////    System.Console.WriteLine("Enter middleware 4");
            ////});


            //app.Use(async (context, next) =>
            //{
            //    System.Console.WriteLine("Enter middleware 4");
            //    await next.Invoke();
            //    System.Console.WriteLine("Enter middleware 4");
            //});
            #endregion

            app.UseHttpsRedirection();
            app.UseIdentityServer();

            app.UseAuthentication();

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
//http://www.taodudu.cc/news/show-914898.html?action=onClick .netcore 运行流程