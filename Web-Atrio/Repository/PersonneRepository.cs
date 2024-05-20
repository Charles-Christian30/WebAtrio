using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Atrio.Context;
using Web_Atrio.Models.Data;
using Web_Atrio.UnitOfWork;

namespace Web_Atrio.Repository
{
    public class PersonneRepository : IPersonneRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WebContext _context;
        public PersonneRepository(IUnitOfWork unitOfWork, WebContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<PersonneData> CreatePersonne(PersonneData personne)
        {
            var response =  _context.Personnes.Add(personne).Entity;
            await this._unitOfWork.CompletAsync();
            return response;
        }

        public async Task<IList<PersonneData>> GetAllPersonnes(string companyName)
        {
            var results = _context.Personnes.OrderBy(x => x.Nom).Include(x => x.EmploisData).ToList();
            if(companyName != null)
            {
                var responses = new List<PersonneData>();
                foreach(var item in results.Where(x => x.EmploisData.Count > 0 && x.EmploisData != null))
                {
                   foreach(var company in item.EmploisData)
                   {
                        if(company.Company.ToLower() == companyName.ToLower())
                        {
                            responses.Add(item);
                        }
                    }
                }
                return responses;
            }

            return results;
        }

        public async Task<PersonneData> GetById(int Id)
        {
            var personne = await _context.Personnes.FirstOrDefaultAsync(x => x.PersonneId == Id);

            if (personne == null)
            {
                return null;
            }
            return personne;
        }
    }
}
