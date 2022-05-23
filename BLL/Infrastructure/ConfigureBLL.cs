using BLL.Services;
using DLL.Context;
using DLL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ConfigureBLL
    {
        static public void Configure(IServiceCollection serviceCollection ,string ContectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<FreelanserContext>(options =>
    options.UseSqlServer(ContectionString, b => b.MigrationsAssembly("Freelanser")));
            builder.AddEntityFrameworkStores<FreelanserContext>();


            serviceCollection.AddTransient<CategoryRepository>();
            serviceCollection.AddTransient<CommentRepository>();
            serviceCollection.AddTransient<CustomerRepository>();
            serviceCollection.AddTransient<EmployeeRepository>();
            serviceCollection.AddTransient<FileRepository>();
            serviceCollection.AddTransient<ReviewRepository>();
            serviceCollection.AddTransient<SkillRepository>();
            serviceCollection.AddTransient<UserInfoRepository>();
            serviceCollection.AddTransient<UserRepository>();
            serviceCollection.AddTransient<WorkRepository>();




            serviceCollection.AddTransient<CategoryService>();
            serviceCollection.AddTransient<SkillService>();
            serviceCollection.AddTransient<UserService>();
            serviceCollection.AddTransient<WorkService>();




        }
    }
}
