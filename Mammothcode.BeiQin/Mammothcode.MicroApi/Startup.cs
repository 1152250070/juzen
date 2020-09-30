using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Common;
using Mammothcode.Library.Data;
using Mammothcode.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
namespace Mammothcode.MicroApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ServiceFactory.ConfigDbContext(options =>
            {
                options.UseProxy = true;
                options.DatasourceName = "mysql";
                options.DatasourceType = Dapper.Linq.DatasourceType.MYSQL;
                options.ConnectionFacotry = () => new MySql.Data.MySqlClient.MySqlConnection(Configuration.GetConnectionString("mysql"));
            });
            RedisClient.Initialization(() => Configuration.GetConnectionString("redis"));

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors((options) =>
            {
                options.AddPolicy("any", (builder) =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter()
                    {
                        DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                    });
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var key = context.ModelState.Keys.First();
                        var value = context.ModelState.GetValueOrDefault(key);
                        var message = value?.Errors.FirstOrDefault()?.ErrorMessage;
                        var result = new BadRequestObjectResult(new
                        {
                            Result = false,
                            Message = message
                        });
                        result.ContentTypes.Add(System.Net.Mime.MediaTypeNames.Application.Json);
                        result.ContentTypes.Add(System.Net.Mime.MediaTypeNames.Application.Xml);
                        return result;
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "贝亲H5端API接口", Version = "开发版" });
                var xmlFile1 = $"Mammothcode.MicroApi.xml";
                var xmlPath1 = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile1);
                c.IncludeXmlComments(xmlPath1);
                var xmlFile2 = $"Mammothcode.Model.xml";
                var xmlPath2 = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile2);
                c.IncludeXmlComments(xmlPath2);
                var xmlFile3 = $"Mammothcode.MicroService.xml";
                var xmlPath3 = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile3);
                c.IncludeXmlComments(xmlPath3);

            });
            //设置swagger的id使用全名称
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(s => s.FullName);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            int StatusCode =500;
            app.UseStatusCodePages(async context =>
            {
                StatusCode = context.HttpContext.Response.StatusCode;
                //context.HttpContext.Response.ContentType = "text/plain;charset=utf-8";
                //var errorMessage = $"对不起，请求遇到错误，状态码{StatusCode}";
                //await context.HttpContext.Response.WriteAsync(errorMessage);
            });
            app.UseExceptionHandler(a =>
            {
                a.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;
                    var logger = NLog.LogManager.GetLogger("exception");
                    logger.Error(exceptionHandlerPathFeature.Error);
                    var message = exception is ServiceException ? exception.Message : "服务器错误";
                    var statusCode = 200;
                    if (exception is LoginException)
                    {
                        statusCode = 55410;//登入失败状态码
                    }
                    else
                    {
                        statusCode = StatusCode;//服务器错误状态码
                    }
                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
                    var stack = env.IsDevelopment() ? exception.StackTrace : "服务器错误";
                    var result = new { Result = false, Message = message, StackTrace = stack };
                    await context.Response.WriteAsync(result.ToJson());
                });
            });
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseCors("any");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
