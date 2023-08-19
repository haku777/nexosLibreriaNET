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
        public string Titulo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Genero { get; set; } = null!;
        public int Numero_de_paginas { get; set; }
        public AutorDto Id_autores { get; set; } = null!;

    }
}
