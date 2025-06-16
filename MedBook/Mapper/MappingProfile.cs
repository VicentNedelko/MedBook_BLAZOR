using AutoMapper;
using Business.DTO;
using DAL.Data;

namespace MedBook.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BearingIndicator, BearingIndicatorDto>().ReverseMap();
            CreateMap<SampleIndicator, SampleIndicatorDto>().ReverseMap();
        }
    }
}
