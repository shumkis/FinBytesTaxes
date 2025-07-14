using AutoMapper;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;

namespace FinBytesTaxesAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCityTaxRuleDto, CityTaxRule>();
        }
    }
}
