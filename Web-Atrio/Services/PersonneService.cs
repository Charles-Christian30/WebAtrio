using AutoMapper;
using Web_Atrio.Models.Data;
using Web_Atrio.Models.Dto;
using Web_Atrio.Repository;

namespace Web_Atrio.Services
{
    public class PersonneService : IPersonneService
    {
        private readonly IMapper _mapper;
        private readonly IPersonneRepository _personneRepository;

        public PersonneService(IMapper mapper, IPersonneRepository personneRepository)
        {
            _mapper = mapper;
            _personneRepository = personneRepository;
        }
        public async Task<PersonneDtoRequest> CreatePersonne(PersonneDtoRequest personne)
        {
            var result = _mapper.Map<PersonneDtoRequest, PersonneData>(personne);
            var response = await _personneRepository.CreatePersonne(result);
            return _mapper.Map<PersonneData, PersonneDtoRequest>(response);
        }

        public async Task<IList<PersonneDtoResponse>> GetAllPersonnes(string companyName)
        {
            var result = await _personneRepository.GetAllPersonnes(companyName);
            
            var response = _mapper.Map<List<PersonneDtoResponse>>(result.ToList());
            
            return response;
        }

        public Task<PersonneData> GetById(int Id)
        {
            var result = _personneRepository.GetById(Id);
            return result; 
        }
    }
}
