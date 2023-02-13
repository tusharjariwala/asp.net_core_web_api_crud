using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Domain.RequestModel
{
    public class EmployeeRequestModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public IFormFile CvFile { get; set; }
        public long CompanyId { get; set; }
    }
}
