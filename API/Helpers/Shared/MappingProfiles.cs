using API.DTO.AccountDTO;
using AutoMapper;
using Core.Entities.AccountEntities;

namespace API.Helpers.Shared
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}