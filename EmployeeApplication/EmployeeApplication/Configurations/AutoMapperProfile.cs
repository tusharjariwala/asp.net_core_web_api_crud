using AutoMapper;
using EmployeeApplication.Core.Domain.RequestModel;
using EmployeeApplication.Core.Domain.ResponseModel;
using EmployeeApplication.Infrastructure.Domain.Entites;
using EmployeeApplication.Shared;

namespace EmployeeApplication.Configurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<PagedList<Employee>,PagedList<EmployeeResponseModel>>();
            CreateMap<Employee, EmployeeResponseModel>()
                .ForMember(c => c.CompanyName,otp=>otp.MapFrom(x=>x.Company.Name));
        }
    }
}
