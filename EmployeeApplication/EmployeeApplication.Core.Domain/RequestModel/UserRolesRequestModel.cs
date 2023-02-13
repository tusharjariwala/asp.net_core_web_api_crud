using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Domain.RequestModel
{
    public class UserRolesRequestModel
    {
        public int EmployeeId { get; set; }
        public int RolesId { get; set; }

    }
}
