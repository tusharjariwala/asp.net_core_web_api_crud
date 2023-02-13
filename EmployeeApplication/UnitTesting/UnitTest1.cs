using AutoMapper;
using EmployeeApplication.Configurations;
using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Core.Service;
using EmployeeApplication.Core.Service.Helper;
using EmployeeApplication.Infrastructure.Contract;
using Microsoft.Extensions.Configuration;
using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Infrastructure.Repository;
using Moq;
using System.ComponentModel.Design;
using System.Net;
using System.Xml.Linq;
using EmployeeApplication.Shared;
using Microsoft.AspNetCore.Http;
using EmployeeApplication.Core.Builder;
using EmployeeApplication.Core.Domain.Exceptions;
using EmployeeApplication.Infrastructure.Domain.Migrations;

namespace UnitTesting
{
    public class UnitTest1
    {
        private readonly Mock<IEmployeeRepostitory> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly Mock<IFileUploadHelper> _fileuploadhelper;
        private readonly EmployeeService employeeService;
        private readonly Mock<IConfiguration> _config;

        public UnitTest1()
        { 
            _employeeRepository = new Mock<IEmployeeRepostitory>();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _fileuploadhelper =new Mock<IFileUploadHelper>();
            _config = new Mock<IConfiguration>();
            employeeService = new EmployeeService(_employeeRepository.Object, _config.Object,_fileuploadhelper.Object, _mapper);
          

        }
        [Fact]
        public async Task AddTask_Employee()
        {
            EmployeeRequestModel requestModel = new EmployeeRequestModel()
            {
                Name = "Test Name",
                Email = "abc@gmail.com",
                Password = "abc",
                Address = "vesu",
                CompanyId = 1,
            };
            _fileuploadhelper.Setup(x => x.UploadEmployee(It.IsAny<FormFile>())).ReturnsAsync(It.IsAny<string>);
            _employeeRepository.Setup(x => x.AddEmployee(It.IsAny<Employee>())).ReturnsAsync(1);
            var result = employeeService.AddEmployeeAsync(requestModel);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateTask_Employee()
        {
            EmployeeRequestModel requestModel = new EmployeeRequestModel()
            {
               
                Name = "Test Name",
                Email = "abc@gmail.com",
                Password = "abc",
                Address = "vesu",
                CompanyId = 1,
            };
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(Mock.Of<Employee>);
            _fileuploadhelper.Setup(x => x.UploadEmployee(It.IsAny<FormFile>())).ReturnsAsync(It.IsAny<string>);
            _employeeRepository.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).ReturnsAsync(1);
            var result = employeeService.UpdateEmployeeAsync(requestModel, It.IsAny<long>());
            Assert.NotNull(result);

        }
        [Fact]
        public async Task InvalidDeleteTask_Employee()
        {
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(null as Employee);
            var result=await Assert.ThrowsAsync<NotFoundException>(async () => await employeeService.DeleteEmployeeAsync(It.IsAny<long>()));
            Assert.NotNull(result);
        }
         [Fact]
         public async Task InvalidIdTask_Employee()
        {
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(null as Employee);
            var result = await Assert.ThrowsAsync<NotFoundException>(async () => await employeeService.IdByEmployeeAsync(It.IsAny<long>()));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task InvalidUpdateTask_Employee()
        {

            EmployeeRequestModel requestModels = new EmployeeRequestModel()
            {

                Name = "TestName",
                Email = "abc@gmail.com",
                Password = "abc",
                Address = "vesu",
                CompanyId = 1,
            };
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(Mock.Of<Employee>());
            _fileuploadhelper.Setup(x=> x.UploadEmployee(It.IsAny<FormFile>())).ReturnsAsync(It.IsAny<string>());
            _employeeRepository.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).ReturnsAsync(0);
            var results = await Assert.ThrowsAsync<NotFoundException>(async () => await employeeService.UpdateEmployeeAsync(requestModels, It.IsAny<long>()));
            Assert.NotNull(results);

        }
        [Fact]
        public async Task ListTask_Employee()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    Name = "Test Name",
                    Email = "abc@gmail.com",
                    Password = "abc",
                    Address = "vesu",
                    CompanyId = 1,
                }
                
            };

            _employeeRepository.Setup(x => x.GetAllEmployee()).ReturnsAsync(employees);
            var result = await employeeService.GetAllEmployees();
            Assert.NotNull(result);
            
        }
        [Fact]
        public async Task IdByTask_Employee()
        {
            var requestModel = new Employee
            {
                Name = "Test Name",
                Email = "abc@gmail.com",
                Password = "abc",
                Address = "vesu",
                CompanyId = 1,
            };
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(requestModel);           
           var result= await employeeService.IdByEmployeeAsync(It.IsAny<long>());
            Assert.NotNull(result);
          
        }
        [Fact]
        public async Task GetEmployeeTask_Must_Pass()
        
        {
            PagedList<Employee> employeeList = new PagedList<Employee>
            {
                Items = StudentList(),
                CurrentPage = 1,
                TotalPage = 1,
                PageSize = 1,
                TotalCount = 1
            };
            _employeeRepository.Setup(x=>x.GetEmployees(It.IsAny<string>(),It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(employeeList);            
            var result = await employeeService.GetEmployeeAsync();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task DeleteTask_Employee()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "abc",
                Email = "pqr",
            };
            _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(employee);
            _employeeRepository.Setup(x => x.UpdateEmployee(employee)).ReturnsAsync(1);
            var result =  employeeService.DeleteEmployeeAsync(It.IsAny<long>());

            Assert.NotNull(result);
        }
        private List<Employee> StudentList()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="abc",
                    Email="pqr",
                   
                }
            };
            return employees;
        }

    }
}