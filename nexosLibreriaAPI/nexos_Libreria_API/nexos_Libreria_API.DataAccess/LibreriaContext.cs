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

            modelBuilder.Entity<Autores>()
                .HasData(
                    new Autores() { 
                        Id = 1,
                        Nombre_completo = "haku",
                        Fecha_nacimiento = DateTime.Now,
                        Ciudad_procedencia = "Japan",
                        Correo_electronico = "jimmy1076667239@gmail.com"
                    }, 
                    new Autores()
                    {
                        Id = 2,
                        Nombre_completo = "Violet",
                        Fecha_nacimiento = DateTime.Now,
                        Ciudad_procedencia = "Japan",
                        Correo_electronico = "v@v.com"
                    }
                );

            modelBuilder.Entity<Libros>()
                .HasData(
                    new Libros() {
                        Id = 1,
                        Titulo = "ApiBook",
                        Id_Autor = 1,
                        Genero = "Terror",
                        Fecha = DateTime.Now,
                        Numero_de_paginas = 7,
                    }
                );

        }
    }
}