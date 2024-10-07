using BlogDE0103.Business.DTOs.RolDTO;
using BlogDE0103.Data.Repositories;
using BlogDE0103.Entities;

namespace BlogDE0103.Business.UsesCases
{
    public class RolBusiness
    {
        RolEntity entity = new();
        List<RolEntity> entityLista = new();
        List<ListarRolesDTO> listaDTO = new();
        ListarRolesDTO rolDTO = new();
        private readonly RolRepository _repository;

        public RolBusiness(RolRepository repository)
        {
            _repository = repository;
        }
        

        //Create - Crear
        public async Task<bool> Agregar(AgregarRolDTO request)
        {
            //Validar aqui los campos antes de pasar a la siguiente linea
  
            entity.Nombre = request.Nombre;
            entity.Descripcion = request.Descripcion;

            var respuesta = await _repository.Agregar(entity);
            return respuesta;
        }

        //Read - Leer
        public async Task<List<ListarRolesDTO>> ObtenerTodo()
        {
            entityLista = await _repository.ObtenerTodo();
            foreach (var item in entityLista)
            {
                var listarRol = new ListarRolesDTO
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                };
                listaDTO.Add(listarRol);
            }
            return listaDTO; 
        }

        public async Task<ListarRolesDTO> ObtenerPorID(int ID)
        {
            entity = await _repository.ObtenerPorID(ID);

            entity.ID = rolDTO.ID;
            entity.Nombre = rolDTO.Nombre;
            entity.Descripcion = rolDTO.Descripcion;

            return rolDTO;
        }
        public async Task<List<ListarRolesDTO>> ObtenerPorNombre(string Nombre)
        {
            entityLista = await _repository.ObtenerPorNombre(Nombre);
            foreach (var item in entityLista)
            {
                var listarRol = new ListarRolesDTO
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                };
                listaDTO.Add(listarRol);
            }
            return listaDTO;
        }
        public async Task<List<ListarRolesDTO>> ObtenerEliminados()
        {
            entityLista = await _repository.ObtenerEliminados();
            foreach (var item in entityLista)
            {
                var listarRol = new ListarRolesDTO
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                };
                listaDTO.Add(listarRol);
            }
            return listaDTO;

        }

        //Update - Actualizar
        public async Task<bool> Actualizar(ActualizarRolDTO request)
        {
            bool respuesta = false;
            try
            {
                //Validar aqui los campos antes de pasar a la siguiente linea
                entity.ID = request.ID;
                entity.Nombre=request.Nombre;
                entity.Descripcion=request.Descripcion;

                respuesta = await _repository.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public async Task<bool> RecuperarEliminado(int ID)
        {
            bool respuesta = false;
            try
            {
                entity = await _repository.ObtenerEliminadosPorID(ID);
                if (entity.ID == 0)
                {
                    throw new Exception("El registro no se encontro");
                }
                else
                {
                //Validar aqui los campos antes de pasar a la siguiente linea
                
                entity.Eliminado = false;
                
                respuesta = await _repository.Actualizar(entity);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        //Delete - Eliminar
        public async Task<bool> Eliminar(int ID)
        {
            bool respuesta = false;
            try
            {
                entity = await _repository.ObtenerPorID(ID);

                entity.Eliminado = true;
                respuesta = await _repository.Eliminar(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
    }
}
