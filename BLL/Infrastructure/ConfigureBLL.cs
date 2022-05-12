using DLL.Context;
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
        }
    }
}
