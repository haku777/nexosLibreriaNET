using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos_Libreria_API.Common.Dto
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre_completo { get; set; } = null!;
        public DateTime Fecha_nacimiento { get; set; }
        public string Ciudad_procedencia { get; set; } = null!;
        public string Correo_electronico { get; set; } = null!;
    }
}