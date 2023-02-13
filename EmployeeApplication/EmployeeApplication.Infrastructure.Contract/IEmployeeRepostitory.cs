using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Contract
{
    public interface IEmployeeRepostitory
    {
        Task<int> AddEmployee(Employee employee);
        Task<PagedList<Employee>> GetEmployees(string searchTerm=null,int page=1,int pageSize=25);
        Task<Employee?> GetEmployee(long EmployeeId);
        Task<int> UpdateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployee();

    }
}
