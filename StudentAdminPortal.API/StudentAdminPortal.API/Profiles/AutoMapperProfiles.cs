using AutoMapper;
using StudentAdminPortal.API.DataModels;
using DataModels = StudentAdminPortal.API.DomainModels;


namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, DomainModels.Student>().ReverseMap();
            CreateMap<DataModels.Address, DomainModels.Address>().ReverseMap();
            CreateMap<DataModels.Gender, DomainModels.Gender>().ReverseMap();
        }
    }
}
