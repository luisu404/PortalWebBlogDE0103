using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class ComentarioEntity
    {
        public int ID { get; set; }
        public string NombreCompleto { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Atendido { get; set; }
    }
}
