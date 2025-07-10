using AutoMapper;

namespace Shared;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();
    }
}
