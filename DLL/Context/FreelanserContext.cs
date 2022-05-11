using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        protected void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(x => x.User);
            builder.HasMany(x => x.Skills).WithMany(x=>x.Employees);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Worker);
            builder.HasMany(x => x.ExecutedWorks).WithOne(x => x.Worker);
            //builder.Property(q => q.RegisterTime).HasColumnType("datetime2");

        }
        protected void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x => x.Work).WithOne(x => x.Customer);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Customer);

        }
        protected void ConfigureCustomer(EntityTypeBuilder<Work> builder)
        {
            builder.HasMany(x => x.Coments).WithOne(x => x.Work);
            builder.HasMany<Category>().WithMany(x => x.Works);

        }
        public void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.SubCategory).WithOne(x => x.ParentCategory);
            
        }
        protected void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.UserInfo).WithOne(x=>x.User);
            


        }
    }
}
