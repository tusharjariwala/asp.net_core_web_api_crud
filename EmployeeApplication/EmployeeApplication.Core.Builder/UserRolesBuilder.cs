using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Builder
{
    public class UserRolesBuilder
    {
        public static UserRoles Build(UserRolesRequestModel model)
        {
            return new UserRoles(model.EmployeeId, model.RolesId);
        }
    }
}
