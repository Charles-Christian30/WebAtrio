using Web_Atrio.Context;
using Web_Atrio.Models.Data;
using Web_Atrio.UnitOfWork;

namespace Web_Atrio.Repository
{
    public class EmploisRepository : IEmploisRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WebContext _context;
        public EmploisRepository(IUnitOfWork unitOfWork, WebContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<EmploisData> CreateEmplois(EmploisData emplois)
        {
            var response = _context.Emplois.Add(emplois).Entity;
            await this._unitOfWork.CompletAsync();
            return response;
        }

        public async Task<IList<EmploisData>> GetAllEmplois(DateTime? startDate, DateTime? endDate)
        {
            var results = _context.Emplois.ToList();
            var responses = new List<EmploisData>();
            if(startDate != null && endDate != null)
            {
                var resultQuery = results.Where(x => x.DateDebut >= startDate && x.DateDebut <= endDate).ToList();
                return resultQuery;
            }
            else if(startDate != null && endDate == null)
            {
                var resultQuery = results.Where(x => x.DateDebut >= startDate).ToList();
                return resultQuery;
            }
                return results;
        }
    }
}
