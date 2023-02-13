using EmployeeApplication.Infrastructure.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Contract
{
    public interface IUserRolesRepostitory
    {
        Task<int> AddUserRoles(UserRoles userRoles);
        Task <UserRoles> LoginUserRoles(long id);
      
    }
}
