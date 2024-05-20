using Web_Atrio.Models.Data;

namespace Web_Atrio.Repository
{
    public interface IEmploisRepository
    {
        Task<EmploisData> CreateEmplois(EmploisData emplois);

        Task<IList<EmploisData>> GetAllEmplois(DateTime? startDate, DateTime? endDate);


    }
}
