using EmployeeApplication.Infrastructure.Contract;
using EmployeeApplication.Infrastructure.Domain;
using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Repository
{
    public class EmployeeRepostitory:IEmployeeRepostitory
    {
        private readonly EmployeeApplicationContext _context;
        public EmployeeRepostitory(EmployeeApplicationContext context) 
        {
            _context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync();
        }

        public Task<List<Employee>> GetAllEmployee()
        {
            var Employee = _context.Employees.Include(x => x.Company).Where(x => !x.IsDeleted).OrderByDescending(x => x.createdOn).ToListAsync();
            return Employee;
        }

        public Task<Employee?> GetEmployee(long EmployeeId)
        {
            var Employee = _context.Employees.FirstOrDefaultAsync(x=>x.Id == EmployeeId);
            return Employee;
        }

        public async Task<PagedList<Employee>> GetEmployees(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var employee = _context.Employees.Include(x => x.Company).Where(x => !x.IsDeleted).OrderByDescending(x => x.createdOn).AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    employee = employee.Where(x =>
                    EF.Functions.Like(x.Name, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Email, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Company.Name, $"%{searchTerm}%")

                    );

                }
                var count = await employee.LongCountAsync();
                var PagedList = employee.ToPagedList(page, pageSize, count);
                return PagedList;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
