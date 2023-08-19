using Microsoft.EntityFrameworkCore;
using Nexos_Libreria_API.DataAccess.Entity;

namespace Nexos_Libreria_API.DataAccess
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(
            DbContextOptions<LibreriaContext> options) : base(options) 
        { 
        }

        public DbSet<Libros> Libros { get; set; }
        public DbSet<Autores> Autores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros>().ToTable("Libros");
            modelBuilder.Entity<Autores>().ToTable("Autores");
            //base.OnModelCreating(modelBuilder);
        }
    }
}