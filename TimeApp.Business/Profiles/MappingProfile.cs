using AutoMapper;
using HR.LeaveManagement.Domain;
using TimeApp.Business.DTOs.LeaveType;

namespace TimeApp.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
