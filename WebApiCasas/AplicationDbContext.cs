using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<Casa> Casas {get; set;}
        public DbSet<Familia> Familias { get; set;}
       
    }
}
