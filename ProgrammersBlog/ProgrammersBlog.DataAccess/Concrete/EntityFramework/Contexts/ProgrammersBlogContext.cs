using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.DataAccess.Concrete.EntityFramework.Mappings;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProgrammersBlogContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Log> Logs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: @"Data Source = DESKTOP-OT4UAS2; Initial Catalog = ProgrammersBlog; Integrated Security = SSPI");
        //}

        public ProgrammersBlogContext(DbContextOptions<ProgrammersBlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleClaimMapping());
            modelBuilder.ApplyConfiguration(new UserClaimMapping());
            modelBuilder.ApplyConfiguration(new UserLoginMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserTokenMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());

        }
    }
}
