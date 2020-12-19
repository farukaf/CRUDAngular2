using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones));

            CreateMap<PersonDto, Person>()
               .ReverseMap()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones));

            CreateMap<PersonPhone, PersonPhoneDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.PersonID))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumberType));

            CreateMap<PersonPhoneDto, PersonPhone>()
               .ReverseMap()
               .ForMember(dest => dest.PersonID, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumberType));

            CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
               .ReverseMap()
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Person, PersonRequest>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones));
        }
    }
}
