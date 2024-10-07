using BlogDE0103.Data.Repositories;
using BlogDE0103.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Business.UsesCases
{
    public class UsuarioBusiness
    {

        private readonly UsuarioRepository _usuarioData;

        public UsuarioBusiness(UsuarioRepository usuarioData)
        {
            _usuarioData = usuarioData;

        }

        public async Task<bool> Agregar(UsuarioEntity request)
        {
            var respuesta = await _usuarioData.Agregar(request);
            return respuesta;
        }



    }
}
