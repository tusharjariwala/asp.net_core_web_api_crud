//using AutoMapper;
//using EmployeeApplication.Configurations;
//using EmployeeApplication.Core.Service.Helper;
//using EmployeeApplication.Core.Service;
//using Microsoft.AspNetCore.Http;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace UnitTesting
//{
//    public  class Class1
//    {
//        namespace TestProject;

//    public class UnitTestController
//    {
//        private readonly Mock<IStudentRepository> _studentRepoMock;
//        private readonly Mock<IStudentService> _studentServiceMock;
//        private readonly Mock<IMapper> _mapperMock;
//        private readonly AutoMapperProfile _mapperProfile;
//        private readonly MapperConfiguration _mapperConfig;
//        private readonly Mock<IFileUploadHelper> _fileUploadHelperMock;
//        private readonly Mock<IStudentBuilder> _studentBuilderMock;
//        private readonly Mock<IFormFile> _formFileMock;

//        public UnitTestController()
//        {
//            _studentRepoMock = new Mock<IStudentRepository>();
//            _mapperMock = new Mock<IMapper>();
//            _studentServiceMock = new Mock<IStudentService>();
//            _mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
//            _mapperProfile = new AutoMapperProfile();
//            _fileUploadHelperMock = new Mock<IFileUploadHelper>();
//            _studentBuilderMock = new Mock<IStudentBuilder>();
//            _formFileMock = new Mock<IFormFile>();

//        }
//        [Fact]
//        public async Task AddStudentAsync_AddStudent()
//        {
//            _studentRepoMock.Setup(x => x.AddStudent(It.IsAny<Student>())).ReturnsAsync(1);
//            _fileUploadHelperMock.Setup(x => x.UploadToCloudinary(It.IsAny<IFormFile>())).ReturnsAsync("string");
//            _studentBuilderMock.Setup(x => x.Build(It.IsAny<StudentRequestModel>(), It.IsAny<string>()));

//            var studentService = new studentService(_studentRepoMock.Object, _mapperMock.Object, _fileUploadHelperMock.Object, _studentBuilderMock.Object);
//            var result = studentService.AddStudentAsync(Studentdata());
//            Assert.NotNull(result);
//        }
//        [Fact]
//        public async Task UpdateStudentAsync_updateStudent()
//        {
//            _studentRepoMock.Setup(x => x.UpdateStudentData(It.IsAny<Student>(), 1)).ReturnsAsync(1);
//            _fileUploadHelperMock.Setup(x => x.UploadToCloudinary(It.IsAny<IFormFile>())).ReturnsAsync("string");
//            _studentBuilderMock.Setup(x => x.Build(It.IsAny<StudentRequestModel>(), It.IsAny<string>()));

//            var studentService = new studentService(_studentRepoMock.Object, _mapperMock.Object, _fileUploadHelperMock.Object, _studentBuilderMock.Object);
//            var result = studentService.UpdateStudentAsync(Studentdata(), 1);
//            Assert.NotNull(result);
//        }

//        //[Fact]
//        //public async Task DeleteStudentAsync_deleteStudent()
//        //{

//        //}

//        //[Fact]
//        //public async Task GetStudentAsync_GetStudent()
//        //{
//        //    _studentRepoMock.Setup(x => x.GetStudent(It.IsAny<Student>())).ReturnsAsync(1);

//        //    var studentService = new studentService(_studentRepoMock.Object, _mapperMock.Object);
//        //    var result = studentService.GetStudentAsync(GetStudentData());
//        //    Assert.NotNull(result);
//        //    Assert.IsType<OkObjectResult>(result as OkObjectResult);

//        //}



//        private StudentRequestModel Studentdata()
//        {
//            StudentRequestModel studentdata = new StudentRequestModel()
//            {
//                StudentName = "abc",
//                Age = 21,
//                DepartmentId = 1
//            };

//            return studentdata;
//        }

//        private List<StudentResponseModel> GetStudentData(int StudentId)
//        {
//            List<StudentResponseModel> studentData = new List<StudentResponseModel>
//    {
//        new StudentResponseModel
//        {
//            Id= 1,
//            StudentName= "abc",
//            Age = "21",
//            DepartmentName = "IT"
//        }
//    };

//            return studentData;
//        }
//    }

//    [Fact]
//    public async Task DeleteTask_Employee()
//    {
//        _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(Mock.Of<Employee>);
//        var employeeService = new EmployeeService(_employeeRepository.Object, _mapper);

//        var result = employeeService.DeleteEmployeeAsync(It.IsAny<long>());

//        Assert.NotNull(result);
//    }
//    [Fact]
//    public async Task IdByTask_Employee()
//    {
//        var requestModel = new Employee
//        {
//            Name = "Test Name",
//            Email = "abc@gmail.com",
//            Password = "abc",
//            Address = "vesu",
//            CompanyId = 1,
//        };
//        _employeeRepository.Setup(x => x.GetEmployee(It.IsAny<long>())).ReturnsAsync(requestModel);


//        var employeeService = new EmployeeService(_employeeRepository.Object, _mapper);

//        var result = await employeeService.IdByEmployeeAsync(It.IsAny<int>());

//        Assert.NotNull(result);
//    }

//}
//}
