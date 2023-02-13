using EmployeeApplication.Infrastructure.Contract;
using EmployeeApplication.Infrastructure.Domain;
using EmployeeApplication.Infrastructure.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Repository
{
    public class UserRolesRepostitory:IUserRolesRepostitory
    {
        private readonly EmployeeApplicationContext _context;
        public UserRolesRepostitory(EmployeeApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserRoles(UserRoles userRoles)
        {
            await _context.UserRoles.AddAsync(userRoles);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserRoles> LoginUserRoles(long id)
        {
            var userroles =await _context.UserRoles.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return userroles;
        }
    }
}
