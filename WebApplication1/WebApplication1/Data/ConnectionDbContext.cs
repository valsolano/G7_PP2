using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    // Crea el contexto de la BD
    public class ConnectionDbContext : DbContext
    {
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options) { 
            
        }
        
    }
}
