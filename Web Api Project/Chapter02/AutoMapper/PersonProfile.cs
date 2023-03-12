using AutoMapper;
using Chapter02.DTO;
using Chapter02.Models;

namespace Chapter02.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ForMember(dst => dst.CompleteAddress, opt=> opt.MapFrom(src=> CalculateAddress(src.Address1, src.Address2, src.City, src.ZipCode)));
        }

        private object CalculateAddress(string? srcAddress1, string? srcAddress2, string? srcCity, string? srcZipCode)
        {
            return $"{srcAddress1} {srcAddress2} {srcCity} {srcZipCode}"; 
        }
    }
}
