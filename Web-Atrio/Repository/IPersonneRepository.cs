using Web_Atrio.Models.Data;

namespace Web_Atrio.Repository
{
    public interface IPersonneRepository
    {
        Task<PersonneData> CreatePersonne(PersonneData personne);

        Task<IList<PersonneData>> GetAllPersonnes(string companyName);

        Task<PersonneData> GetById(int Id);
    }
}
