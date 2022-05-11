using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Context
{
    public class FreelanserContext:DbContext
    {
        public FreelanserContext(DbContextOptions<FreelanserContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        protected void ConfigureUserInfo(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.UserInfo);
            builder.HasMany(x => x.Skills);
            //builder.HasMany(x => x.Reviews).WithOne(x => x.UserInf);

        }
        protected void ConfigureWork(EntityTypeBuilder<Work> builder)
        {
            builder.HasMany(x => x.Coments).WithOne(x => x.Work);

        }
    }
}
