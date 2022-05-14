using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLL.Context
{
    public class FreelanserContext : IdentityDbContext
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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEmployee(modelBuilder.Entity<Employee>());
            ConfigureCustomer(modelBuilder.Entity<Customer>());
            ConfigureWork(modelBuilder.Entity<Work>());
            ConfigureUserInfo(modelBuilder.Entity<UserInfo>());

            base.OnModelCreating(modelBuilder);
        }

        protected void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.Employee).HasForeignKey<Employee>(x => x.UserId);
            builder.HasMany(x => x.Skills).WithMany(x => x.Employees);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Worker);
            builder.HasMany(x => x.ExecutedWorks).WithOne(x => x.Worker);
            //builder.Property(q => q.RegisterTime).HasColumnType("datetime2");

        }
        protected void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.Customer).HasForeignKey<Customer>(x => x.UserId);
            builder.HasMany(x => x.Work).WithOne(x => x.Customer);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Customer);

        }
        protected void ConfigureWork(EntityTypeBuilder<Work> builder)
        {
            builder.HasMany(x => x.Coments).WithOne(x => x.Work);
            builder.HasMany(x => x.Categories).WithMany(x => x.Works);

        }
        protected void ConfigureUserInfo(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.UserInfo);
        }

    }
}
