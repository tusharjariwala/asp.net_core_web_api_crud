using AutoMapper;
using EmployeeApplication.Configurations;
using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Service.Helper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public  class UnitTestController
    {
        private readonly Mock<IEmployeeService> _employeeService;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly Mock<IFileUploadHelper> _fileUploadHelper;

        public UnitTestController()
        {
            _employeeService= new Mock<IEmployeeService>();
            _mapperConfiguration = new MapperConfiguration(e => e.AddProfile(new AutoMapperProfile()));
            _mapper=_mapperConfiguration.CreateMapper();

        }

    }
}
