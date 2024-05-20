using Web_Atrio.Models.Data;
using Web_Atrio.Models.Dto;

namespace Web_Atrio.Services
{
    public interface IEmploisService
    {
        Task<EmploisDto> CreateEmplois(EmploisDto emplois, PersonneData personne);

        Task<IList<EmploisDto>> GetAllEmplois(DateTime? startDate, DateTime? endDate);


    }
}
