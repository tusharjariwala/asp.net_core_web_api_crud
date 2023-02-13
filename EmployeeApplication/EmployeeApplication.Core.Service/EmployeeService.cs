using AutoMapper;
using EmployeeApplication.Core.Builder;
using EmployeeApplication.Core.Contract;
using EmployeeApplication.Core.Domain.Exceptions;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Core.Domain.ResponseModel;
using EmployeeApplication.Core.Service.Helper;
using EmployeeApplication.Infrastructure.Contract;
using EmployeeApplication.Infrastructure.Domain;
using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepostitory _employeeRepostitory;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IFileUploadHelper _fileuploadHelper;
        private readonly EmployeeApplicationContext _employeeContext;
        public EmployeeService(IEmployeeRepostitory employeeRepostitory, IConfiguration config, IFileUploadHelper fileuploadHelper,IMapper mapper)
        {
            _employeeRepostitory = employeeRepostitory;
            _config = config;
            _fileuploadHelper = fileuploadHelper;
            _mapper = mapper;
        }

        public async Task AddEmployeeAsync(EmployeeRequestModel EmployeeModel)
        {
            try
            {
                var fileKey = await _fileuploadHelper.UploadEmployee(EmployeeModel.CvFile);
                var emp = EmployeeBuilder.Build(EmployeeModel, fileKey);
                var count = await _employeeRepostitory.AddEmployee(emp);
                if (count == 0)
                {
                    throw new BadRequestException("Employee is not Created");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(long EmployeeId)
        {
            try
            {
                var Employee=await _employeeRepostitory.GetEmployee(EmployeeId);
                if (Employee==null)
                {
                    throw new NotFoundException($"Employee With{EmployeeId} Is Not Found");

                }
                Employee.Delete();
                var count=await _employeeRepostitory.UpdateEmployee(Employee);
                if(count==0)
                {
                    throw new BadRequestException("Not Update Successfull");
                }
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployees()
        {
            try
            {
                var emp =await _employeeRepostitory.GetAllEmployee();
                var result= _mapper.Map<List<EmployeeResponseModel>>(emp); 
                return result; 

            }catch(Exception e)
            {
                throw;
            }
        }

        public async Task<Employee> IdByEmployeeAsync(long EmployeeId)
        {
            try
            {
                var employee = await _employeeRepostitory.GetEmployee(EmployeeId);
                if(employee==null)
                {
                    throw new NotFoundException($"Employee with{EmployeeId} is not Found");
                }
                return employee;

            }catch(Exception ex) 
            {
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(EmployeeRequestModel Employee, long EmployeeId)
        {
            try
            {
                var EmployeeEntity = await _employeeRepostitory.GetEmployee(EmployeeId);
                var fileKey = await _fileuploadHelper.UploadEmployee(Employee.CvFile);
                EmployeeEntity.Name = Employee.Name;
                EmployeeEntity.BirthDate = Employee.BirthDate;
                EmployeeEntity.Email = Employee.Email;
                EmployeeEntity.Address = Employee.Address;
                EmployeeEntity.CvFile = fileKey;
                EmployeeEntity.CompanyId = Employee.CompanyId;

                var employee = await _employeeRepostitory.UpdateEmployee(EmployeeEntity);
                if (employee ==0)
                {
                    throw new NotFoundException($"employee id{EmployeeId} not found");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedList<EmployeeResponseModel>> GetEmployeeAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var employee= await _employeeRepostitory.GetEmployees(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<EmployeeResponseModel>>(employee);
                return result;

            }
            catch(Exception ex) 
            {
                throw;
            }
        }
    }
}
