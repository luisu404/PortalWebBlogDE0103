using BlogDE0103.Data.DBContext;
using BlogDE0103.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDE0103.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly AppDbContext DbContext;

        public UsuarioRepository(AppDbContext _DbContext)
        {
            DbContext = _DbContext;
        }


        public async Task<bool> Agregar(UsuarioEntity entity)
        {
            bool respuesta = false;
            try
            {
                await DbContext.Usuarios.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }

        public async Task<List<UsuarioEntity>> ObtenerTodo()
        {
            //return await DbContext.Set<Rol>().ToListAsync<Rol>();
            var data = await DbContext.Usuarios.Where(r => r.Eliminado == false && r.Estado == true).ToListAsync();
            return data;
        }
    }
}
