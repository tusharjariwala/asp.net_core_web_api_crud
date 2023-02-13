using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApplication.Infrastructure.Domain;

namespace EmployeeApplication.Configurations
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"];
            services.AddDbContext<EmployeeApplicationContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("EmployeeApplication.Infrastructure.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);

                });
            }, ServiceLifetime.Singleton);
        }
    }
}
