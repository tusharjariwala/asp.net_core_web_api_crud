using EmployeeApplication.Core.Builder;
using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Domain.Exceptions;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Contract;
using EmployeeApplication.Infrastructure.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Service
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesRepostitory _userRepo; 
        public UserRolesService(IUserRolesRepostitory userRoles)
        {
            _userRepo = userRoles;
        }

        public async Task AddUser(UserRolesRequestModel UserReq)
        {
            try
            {
                var userro = UserRolesBuilder.Build(UserReq);
                var userroles = await _userRepo.AddUserRoles(userro);
                if (userroles == 0)
                {
                    throw new BadRequestException("User Roles in not created");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task LoginUser(long id)
        {
            throw new NotImplementedException();
        }
    }
}
