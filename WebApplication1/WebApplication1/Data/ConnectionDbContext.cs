using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    // Crea el contexto de la BD
    public class ConnectionDbContext : DbContext
    {
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options) { 
            
        }

        public DbSet<CancionModel> Cancion_G7 { get; set; }
        public DbSet<CantanteModel> Cantante_G7 { get; set; }
        public DbSet<TareaModel> Tarea_G7 { get; set; }
        public DbSet<ListaModel> Lista_G7 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CancionModel>().ToTable("Cancion_G7");
            modelBuilder.Entity<CantanteModel>().ToTable("Cantante_G7");
            modelBuilder.Entity<TareaModel>().ToTable("Tarea_G7");
            modelBuilder.Entity<ListaModel>().ToTable("Lista_G7");
        }
        

    }
}
