using System.ComponentModel.DataAnnotations;

namespace nexos_Libreria_MVC.Models
{
    public class Autors
    {
        public int Id { get; set; }
        public string Nombre_completo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Ciudad_procedencia { get; set; }
        public string Correo_electronico { get; set; }
    }
}
