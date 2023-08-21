using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos_Libreria_API.Common.Dto.Autors
{
    public class AutorsDto
    {
        public int Id { get; set; }
        public string Nombre_completo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Ciudad_procedencia { get; set; }
        public string Correo_electronico { get; set; }
    }
}
