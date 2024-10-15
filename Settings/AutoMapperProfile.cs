using AutoMapper;
using ClinicNetCore.Models;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleResponse, ApplicationRole>();
            CreateMap<ApplicationRole, RoleResponse>();
        }
    }

}