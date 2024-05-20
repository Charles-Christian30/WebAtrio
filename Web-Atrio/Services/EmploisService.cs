using AutoMapper;
using System.Globalization;
using Web_Atrio.Models.Data;
using Web_Atrio.Models.Dto;
using Web_Atrio.Repository;

namespace Web_Atrio.Services
{
    public class EmploisService : IEmploisService
    {
        private readonly IMapper _mapper;
        private readonly IEmploisRepository _emploisRepository;
        private readonly IPersonneService _personneService;


        public EmploisService(IMapper mapper, IEmploisRepository emploisRepository, IPersonneService personneService)
        {
            _mapper = mapper;
            _emploisRepository = emploisRepository;
            _personneService = personneService;
        }
        public async Task<EmploisDto> CreateEmplois(EmploisDto emplois, PersonneData personne)
        {
            var result = _mapper.Map<EmploisDto, EmploisData>(emplois);
            result.Personne = personne;
            var response = await _emploisRepository.CreateEmplois(result);
            return  _mapper.Map<EmploisData, EmploisDto>(response);
        }

        public async Task<IList<EmploisDto>> GetAllEmplois(DateTime? startDate, DateTime? endDate)
        {
            var responses = await _emploisRepository.GetAllEmplois(startDate, endDate);
            var results =  _mapper.Map<List<EmploisDto>>(responses);
            return results;
        }
    }
}
