using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeApplicationContext _context;

        public EmployeeController(IEmployeeService employeeService, EmployeeApplicationContext context) 
        {
            _employeeService = employeeService;
            _context = context;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeRequestModel employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return Created("Employee", null);
        }
        [HttpGet("GetEmployees")]

        public async Task<IActionResult>  GetEmployees(string? searchTerm=null,int page=1,int pageSize = 25)
        {
            var employee= await _employeeService.GetEmployeeAsync(searchTerm,page,pageSize);
            return Ok(employee);
        }
        [HttpDelete("EmployeeDelete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
        [HttpGet("EmployeeID/{id}")]
        public async Task<IActionResult> IdbyEmployee(int id)
        {
            var employee=await _employeeService.IdByEmployeeAsync(id);
            return Ok(employee);
        }
        [HttpGet("AllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _employeeService.GetAllEmployees(); 
            return Ok(employee);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeRequestModel employeemodel, long EmployeeId)
        {
            await _employeeService.UpdateEmployeeAsync(employeemodel, EmployeeId);
            return NoContent();
        }
    }
}
