using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Business.AutoMapper.Profiles;
using ProgrammersBlog.Business.Extensions;
using ProgrammersBlog.Core.Utilities.Extensions;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.MVC.AutoMapper.Profiles;
using ProgrammersBlog.MVC.Filters;
using ProgrammersBlog.MVC.Helpers.Abstract;
using ProgrammersBlog.MVC.Helpers.Concrete;

namespace ProgrammersBlog.MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AboutUsPageInfo>(Configuration.GetSection("AboutUsPageInfo"));
            services.Configure<WebSiteInfo>(Configuration.GetSection("WebSiteInfo"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.Configure<ArticleRightSideBarWidgetOptions>(
                Configuration.GetSection("ArticleRightSideBarWidgetOptions"));
            services.ConfigureWritable<AboutUsPageInfo>(Configuration.GetSection("AboutUsPageInfo"));
            services.ConfigureWritable<WebSiteInfo>(Configuration.GetSection("WebSiteInfo"));
            services.ConfigureWritable<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.ConfigureWritable<ArticleRightSideBarWidgetOptions>(
                Configuration.GetSection("ArticleRightSideBarWidgetOptions"));
            services.AddControllersWithViews(options =>
            {

                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan boþ geçilmemelidir.");
                options.Filters.Add<MvcExceptionFilter>();

            }).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); //Json Serializer ayarý. Ajax için bu ayar yapýlýyor.


            }).AddNToastNotifyToastr(); //Sen bir MVC projesisin.  AddRazorRuntimeCompilation() ve Uygulamada front-end tarafýnda deðiþiklik yapýldýðýnda projeyi tekrar tekrar çalýþtýrmamýza gerek kalmayacak.   
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile), typeof(CommentProfile), typeof(ViewModelsProfile)); //AutoMapper ile yapýlan iþlemlerini Startup dosyasýna tanýmladýk.
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB")); //Extends ettiðimiz servisler.
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options => //Cookie iþlemleri
            {
                options.LoginPath = new PathString("/Admin/Auth/Login"); //Giriþ yapmadan bir sayfaya gitmek istersem sistem beni otomatik buraya yönlendirecek.
                options.LogoutPath = new PathString("/Admin/Auth/Logout");

                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest //Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); //Sitemizde bulunmayan viewlar için 404 Not Found sayfasý için.
            }
            app.UseSession();
            app.UseStaticFiles(); //Javascript,css ve resimler gibi dosyalarý kullanmak gibi.
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseNToastNotify();

            app.UseEndpoints(endpoints => //Core 3.1 ile beraber artýk yönlendiremeler bu þekilde yapýlýyor.
            {
                endpoints.MapAreaControllerRoute(

                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}" //Admin areas sayfa yönlendirmesi.
                    );

                endpoints.MapDefaultControllerRoute(); //Home Controller Index Sayfasý


            });
        }
    }
}
