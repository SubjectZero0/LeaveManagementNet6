using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;

namespace LeaveManagement.Web.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationsViewModel>().ReverseMap();
            CreateMap<Employee, EmployeesViewModel>().ReverseMap();
        }
    }
}