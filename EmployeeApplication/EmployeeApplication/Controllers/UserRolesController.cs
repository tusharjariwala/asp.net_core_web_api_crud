using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Infrastructure.Domain;
using EmployeeApplication.Infrastructure.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userService;
        private readonly EmployeeApplicationContext _dbContext;
        public UserRolesController(IUserRolesService userService, EmployeeApplicationContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }
        [HttpPost("AddUserRole")]
        public async Task<IActionResult> AddUserRoles([FromForm] UserRolesRequestModel userroless)
        {
            await _userService.AddUser(userroless);
            return Created("UserRoles", null);
        }
    }
}
