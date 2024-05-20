using AutoMapper;
using Web_Atrio.Models.Data;
using Web_Atrio.Models.Dto;

namespace Web_Atrio.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() 
        {
            //CreateMap<PersonneData, PersonneDtoResponse>().ReverseMap();

            CreateMap<PersonneDtoRequest, PersonneData>().ReverseMap();

            CreateMap<PersonneDtoResponse, PersonneData>().ForMember(dest => dest.EmploisData, 
                    opt => opt.MapFrom(src => src.EmploisData.Select(x =>
                    
                        new EmploisData()
                        {
                            Company = x.Company,
                            Post = x.Post,
                            DateDebut = x.DateDebut,
                            DateFin = x.DateFin
                        }
                    ))).ReverseMap();


            CreateMap<EmploisData, EmploisDto>().ReverseMap();



        }
    }
}
