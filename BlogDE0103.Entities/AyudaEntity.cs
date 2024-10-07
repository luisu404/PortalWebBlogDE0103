using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class AyudaEntity
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Atendido { get; set; }
    }
}
