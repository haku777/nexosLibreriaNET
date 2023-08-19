using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexos_Libreria_MVC.Common.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Genero { get; set; }
        public int Numero_de_paginas { get; set; }
    }
}
