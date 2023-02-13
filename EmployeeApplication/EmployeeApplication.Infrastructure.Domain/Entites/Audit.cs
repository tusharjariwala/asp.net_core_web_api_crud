using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Domain.Entites
{
    public class Audit
    {
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
