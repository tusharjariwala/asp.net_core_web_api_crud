using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Builder
{
    public class EmployeeBuilder
    {
        public EmployeeBuilder() { }
        public static Employee Build(EmployeeRequestModel model,string cvkey)
        {
            return new Employee(model.Name, model.BirthDate, model.Email,model.Password,model.Address, cvkey,model.CompanyId);
        }
    }
}
