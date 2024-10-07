using BlogDE0103.Data.DBContext;
using BlogDE0103.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogDE0103.Data.Repositories
{
    public class RolRepository
    {
        private readonly AppDbContext DbContext;

        public RolRepository(AppDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        //C
        public async Task<bool> Agregar(RolEntity entity)
        {
            bool respuesta = false;
            try
            {
                await DbContext.Roles.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }

        //R
        public async Task<List<RolEntity>> ObtenerTodo()
        {
            return await DbContext.Roles
                .Where(r => r.Eliminado == false)
                .ToListAsync();
        }
        public async Task<RolEntity> ObtenerPorID(int ID)
        {
            var entidad = await DbContext.Roles
                .Where(r => r.ID == ID && r.Eliminado == false)
                .FirstOrDefaultAsync();
            if (entidad == null) { return new RolEntity{}; }
            else { return entidad; }
        }
        public async Task<List<RolEntity>> ObtenerPorNombre(string Nombre)
        {
            var entidad = await DbContext.Roles
                .Where(r => r.Nombre == Nombre && r.Eliminado == false)
                .ToListAsync();
            if (entidad == null) { return new List<RolEntity> { }; }
            else { return entidad; }
        }




        public async Task<List<RolEntity>> ObtenerEliminados()
        {
            var entidad = await DbContext.Roles
                .Where(r=>r.Eliminado == true)
                .ToListAsync();
            if (entidad.Count==0) { return new List<RolEntity> { }; }
            else { return entidad; }
        }
        public async Task<RolEntity> ObtenerEliminadosPorID(int ID)
        {
            var entidad = await DbContext.Roles
                .Where(r => r.ID == ID && r.Eliminado == true)
                .FirstOrDefaultAsync();
            if (entidad == null) { return new RolEntity { }; }
            else { return entidad; }
        }
        //U
        public async Task<bool> Actualizar(RolEntity entity)
        {
            bool respuesta = false;
            try
            {
                DbContext.Set<RolEntity>().Update(entity);
                await DbContext.SaveChangesAsync();
                respuesta = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //D
        public async Task<bool> Eliminar(RolEntity entity)
        {
            bool respuesta = false;
            try
            {
                DbContext.Set<RolEntity>().Update(entity);
                //DbContext.Roles.Remove(entity);
                await DbContext.SaveChangesAsync();
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

    }
}
