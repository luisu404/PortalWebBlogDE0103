using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class ActividadEntity
    {
        public int ID { get; set; }
        public int IDTipoActividad { get; set; }
        //public string Nivel { get; set; }
        public string ResponsableActividad { get; set; }
        public string MaterialesRequeridos { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IDPublicoObjetivo { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaHoraActividad { get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool AlmuerzoRefrigerio { get; set; } = false;
        public decimal Presupuesto { get; set; }
        public bool Eliminado { get; set; } = false;

        // Relaciones con otras entidades
        public TipoActividadEntity TipoActividad { get; set; }
        public PublicoObjetivoEntity PublicoObjetivo { get; set; }
        public UsuarioEntity Usuario { get; set; }

    }
}
