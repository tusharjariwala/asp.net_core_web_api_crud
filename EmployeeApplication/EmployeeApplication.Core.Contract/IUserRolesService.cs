using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Contract
{
    public interface IUserRolesService
    {
        Task AddUser(UserRolesRequestModel UserReq);
        Task LoginUser(long id);
    }
}
