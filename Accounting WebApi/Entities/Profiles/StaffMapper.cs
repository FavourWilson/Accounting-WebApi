using Accounting_WebApi.Entities.DataTransferObjects.Create;
using Accounting_WebApi.Entities.DataTransferObjects.Update;
using Accounting_WebApi.Entities.DataTransferObjects.View;
using Accounting_WebApi.Entities.Models;
using AutoMapper;

namespace Accounting_WebApi.Entities.Profiles
{
    public class StaffMapper : Profile
    {
        public StaffMapper()
        {
            CreateMap<Staffs, StaffViewRepo> ()
               .ForMember(dest => dest.fullName,
               opt => opt.MapFrom
               (src => $"{src.firstName} {src.LastName} {src.middleName}"));

            CreateMap<StaffCreateRepo, Staffs>();
            CreateMap<StaffUpdateRepo, Staffs>();
        }
    }
}
