using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WeChatPublicPlatform
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureServices 里面添加AddMvc，在Configure里面配置MVC
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //我们不需要直接操作HTTP数据上下文。
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            app.UseMvcWithDefaultRoute();

            //如果项目需要用到静态文件。css，js，img等。那么就在Configure里面添加
            app.UseStaticFiles();


            //在没有页面的时候返回错误信息 （Status Code: 404; Not Found   ） 而不是找不到 ***** 的网页
            app.UseStatusCodePages();
        }
    }
}
