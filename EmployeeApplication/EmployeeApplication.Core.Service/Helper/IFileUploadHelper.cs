using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Service.Helper
{
    public interface IFileUploadHelper
    {
        Task<string> UploadEmployee(IFormFile file);
    }
}
