using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class NoticiaEntity
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Contenido { get; set; }
        public int IDTipoNoticia { get; set; }
        public int IDPublicoObjetivo { get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public DateTime FechaNoticia { get; set; }
        public bool Estado { get; set; } = false;
        public bool Eliminado { get; set; } = false;

        // Relaciones con otras entidades
        public TipoNoticiaEntity TipoNoticia { get; set; }
        public PublicoObjetivoEntity PublicoObjetivo { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
