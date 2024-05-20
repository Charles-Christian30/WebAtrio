using Web_Atrio.Models.Data;
using Web_Atrio.Models.Dto;

namespace Web_Atrio.Services
{
    public interface IPersonneService
    {
        Task<PersonneDtoRequest> CreatePersonne(PersonneDtoRequest personne);

        Task<IList<PersonneDtoResponse>> GetAllPersonnes(string companyName);

        Task<PersonneData> GetById(int Id);


    }
}
