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
using WebApplication1.ID4��Ȩ����;
using WebApplication1.IOC����.Services;
using WebApplication1.JWT��Ȩ����;
using WebApplication1.JWT��Ȩ����.Context;
using WebApplication1.JWT��Ȩ����.Midwares;
using WebApplication1.ȫ����־.Dtos;
using WebApplication1.ȫ����־.filters;
using WebApplication1.ȫ����־.Services;
using WebApplication1.��̬����.Services;

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
            #region ���Կ��� configureDefaults��˵������Ӹ�������
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
            #region configurationBuilder���ù�����ģʽ
            //https://tool.4xseo.com/a/9104.html
            //new HostBuilder().ConfigureAppConfiguration((context, configurationBuilder) =>
            //{
            //    configurationBuilder.AddCommandLine(args);   // ����������Դ
            //    configurationBuilder.AddEnvironmentVariables();   // ��������Դ
            //    configurationBuilder.AddJsonFile("demo.json");   // json�ļ�����Դ
            //    configurationBuilder.AddInMemoryCollection();
            //});

            #endregion
            #region ���Serilogȫ����־
            SerilogConfig.InitConfig();
            #endregion

            var builder = WebApplication.CreateBuilder(args); //https://www.cnblogs.com/guoxiaotian/p/16950078.html Դ�������

            #region  �滻����
            //builder.Host.UseServiceProviderFactory(new AuaoServiceProviderFactory());
            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            #endregion

            // Add services to the container.
            #region  ע�����
            builder.Services.AddScoped<ExceptServiceTest>();
            builder.Services.AddScoped<DynamicService>();
            #endregion

            builder.Services.AddControllers(mvcoption =>
            {
                mvcoption.Filters.Add(typeof(AbpAsyncExceptionFilter));//ע���쳣������

            });

            #region �󶨶˿ں�
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
                    Description = $"�ٱ���ӿ��ĵ�˵��",
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
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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
                //��Ӷ�ö�ٵ�����
                waggenoption.SchemaFilter<EnumSwaggerDocumentFilter>();
            });

            #region ע��JWT�����Լ���Ȩ�������������,�Լ�Indentity4���÷���
            //jwt
            //builder.AddAuthcations();

            //id4
            builder.AddID4Authcations();
            #endregion

            builder.Services.AddHttpClient();

            #region ���ÿ���
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
                x.FailedRetryCount = 10;//���Դ���
                x.FailedRetryInterval = 30;//���Եļ��Ƶ��
                x.FailedThresholdCallback = faield => {
                    Log.Error($"MessageType{faield.MessageType}ʧ���ˣ�������{x.FailedRetryCount}��,��Ϣ����:{faield.Message.GetName()}");
                    //���Ҫ��֪ͨ���˹�����
                };
            });
            #endregion

            var app = builder.Build();//������������ĺ���,ǰ��ʱ���������ý�ȥ
            //new WebHostBuilder().Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("any");

            #region ���Jwt�����޸�ˢ��token�м��
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


            ////var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "�°���") }, CookieAuthenticationDefaults.AuthenticationScheme));
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
//http://www.taodudu.cc/news/show-914898.html?action=onClick .netcore ��������