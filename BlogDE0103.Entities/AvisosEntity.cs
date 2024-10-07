using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class AvisosEntity
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public int IDPublicoObjetivo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Eliminado { get; set; } = false;

        // Relación con Usuario
        public UsuarioEntity Usuario { get; set; }
        public PublicoObjetivoEntity PublicoObjetivo { get; set; }
    }
}
