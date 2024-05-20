
using Web_Atrio.Context;

namespace Web_Atrio.UnitOfWork
{
    public class UnitOfWorkImplementation : IUnitOfWork
    {
        private readonly WebContext _context;
        public UnitOfWorkImplementation(WebContext context)
        {
            _context = context;
        }
        public async Task CompletAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
