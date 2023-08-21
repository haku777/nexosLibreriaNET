using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos_Libreria_API.Common.Dto
{
    public class BookDto
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
