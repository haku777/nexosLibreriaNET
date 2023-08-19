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
        [Required(ErrorMessage = "")]
        public string Nombre_completo { get; set; } = null!;
        [Column("Fecha_de_nacimiento")]
        [Required(ErrorMessage = "")]
        public DateTime Fecha_nacimiento { get; set; }
        [Column("Ciudad_de_procedencia")]
        [Required(ErrorMessage = "")]
        public string? Ciudad_procedencia { get; set; }
        [Required(ErrorMessage = "")]
        public string? Correo_electronico { get; set; }

    }
}
