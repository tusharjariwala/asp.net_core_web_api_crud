using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Domain.Entites
{
    public class UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public  Employee Employee { get; set; }
        public int RolesId { get; set; }
        public  Roles Roles { get; set; }

        public UserRoles() { }
        public UserRoles(int employeeId, int rolesId)
        {

            EmployeeId = employeeId;
            RolesId = rolesId;
           
            
        }
    }
}
