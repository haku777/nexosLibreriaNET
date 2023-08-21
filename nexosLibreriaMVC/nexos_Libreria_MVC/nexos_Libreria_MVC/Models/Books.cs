using System.ComponentModel.DataAnnotations;

namespace nexos_Libreria_MVC.Models
{
    public class Books
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Genero { get; set; }
        public int Numero_de_paginas { get; set; }
        public int Id_Autor { get; set; }
    }
}
