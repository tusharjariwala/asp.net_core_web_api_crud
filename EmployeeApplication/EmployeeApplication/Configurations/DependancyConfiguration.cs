using EmployeeApplication.Configurations;
using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Service;
using EmployeeApplication.Core.Service.Helper;
using EmployeeApplication.Infrastructure.Contract;
using EmployeeApplication.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeApplication.Configurations
{
    public static  class DependancyConfiguration
    {
        public static void AddDependancy(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepostitory, EmployeeRepostitory>();
            services.AddTransient<IUserRolesService, UserRolesService>();
            services.AddTransient<IUserRolesRepostitory, UserRolesRepostitory>();
            services.AddTransient<IFileUploadHelper,FileUploadHelper>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            
        }
    }

}
