using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos_Libreria_API.DataAccess.Entity
{
    public class Autores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre_completo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Ciudad_procedencia { get; set; }
        public string Correo_electronico { get; set; }

    }
}
