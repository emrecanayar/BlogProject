using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Business.Abstract;
using ProgrammersBlog.Business.Concrete;
using ProgrammersBlog.DataAccess.Abstract;
using ProgrammersBlog.DataAccess.Concrete;
using ProgrammersBlog.DataAccess.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                //User Password Options
                options.Password.RequireDigit = true;               //Kullanıcı şifrelerinde rakam kısmının bulunması.
                options.Password.RequiredLength = 10;               //Kullanıcının şifresinin en az 10 karakter olması gerekmektedir.
                options.Password.RequiredUniqueChars = 1;           //Kullanıcının şifresinde Unique karakterlenden kaçtane olması gerektiğini belirler.(!,?)
                options.Password.RequireNonAlphanumeric = true;     //Kullanıcının şifresinde unique karakterlerin kullanılmasını sağlar.
                options.Password.RequireLowercase = true;           //Kullanıcının şifrelerinde küçük harf kullanılmasına izin verir.
                options.Password.RequireUppercase = true;           //Kullanıcının şifrelerinde büyük harf kullanılmasına izin verir.

                //User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$"; //Kullanıcı oluşturuken kullanılması gereken karakterler.
                options.User.RequireUniqueEmail = true; //Oluşturulan email veritabanında sadece bir kere bulunabilir.

            }).AddEntityFrameworkStores<ProgrammersBlogContext>();
            serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15);
            });
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddSingleton<IMailService, MailManager>();

            return serviceCollection;
        }
    }
}
