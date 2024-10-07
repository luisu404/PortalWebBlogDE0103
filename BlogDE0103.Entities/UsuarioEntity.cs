using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Entities
{
    public class UsuarioEntity
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IDRol { get; set; }
        public string Funcion { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = false;
        public bool Eliminado { get; set; } = false;

        // Relación con Rol
        public RolEntity Rol { get; set; }

    }
}
