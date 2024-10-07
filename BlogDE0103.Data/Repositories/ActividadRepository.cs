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
    public class ActividadRepository
    {
        private readonly AppDbContext DbContext;

        public ActividadRepository(AppDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public async Task<bool> Agregar(ActividadEntity entity)
        {
            bool respuesta = false;
            try
            {
                await DbContext.Actividades.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }


        public async Task<List<ActividadEntity>> ObtenerTodo()
        {
            var data = await DbContext.Actividades.Where(r => r.Eliminado == false).ToListAsync<ActividadEntity>();
            return data;
        }


    }
}
