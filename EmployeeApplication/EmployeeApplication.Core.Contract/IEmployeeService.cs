using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Core.Domain.ResponseModel;
using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Contract
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(EmployeeRequestModel Employee);
        Task DeleteEmployeeAsync(long EmployeeId);
        Task<List<EmployeeResponseModel>> GetAllEmployees();
        Task<PagedList<EmployeeResponseModel>> GetEmployeeAsync(string searchTerm = null, int page = 1, int pageSize = 25);
        Task UpdateEmployeeAsync(EmployeeRequestModel Employee, long EmployeeId);
        Task<Employee> IdByEmployeeAsync(long EmployeeId);

    }
}
