using Microsoft.EntityFrameworkCore;
using Web_Atrio.Models.Data;

namespace Web_Atrio.Context
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }
        public DbSet<PersonneData> Personnes { get; set; }
        public DbSet<EmploisData> Emplois { get; set; }
    }
}
