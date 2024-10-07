using BlogDE0103.Business.DTOs.RolDTO;
using BlogDE0103.Business.UsesCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogDE0103.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : Controller
    {
        private readonly RolBusiness _business;

        public RolController(RolBusiness business)
        {
            _business = business;
        }

        //C
        [HttpPost]
        [Route("Agregar")]
        public async Task<dynamic> Agregar(AgregarRolDTO request)
        {
            bool respuesta = false;
            try
            {
                respuesta = await _business.Agregar(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }

        //R
        [HttpGet]
        [Route("ObtenerTodo")]
        public async Task<dynamic> ObtenerTodo()
        {
            var roles = await _business.ObtenerTodo();
            return Ok(roles);
        }

        [HttpGet]
        [Route("ObtenerPorID/{ID}")]
        public async Task<dynamic> ObtenerPorID(int ID)
        {
            var roles = await _business.ObtenerPorID(ID);
            return Ok(roles);
        }

        [HttpGet]
        [Route("ObtenerPorNombre/{Nombre}")]
        public async Task<dynamic> ObtenerPorNombre(string Nombre)
        {
            var roles = await _business.ObtenerPorNombre(Nombre);
            return Ok(roles);
        }



        [HttpGet]
        [Route("ObtenerEliminados")]
        public async Task<dynamic> ObtenerEliminados()
        {
            var roles = await _business.ObtenerEliminados();
            return Ok(roles);
        }

        //U
        [HttpPut]
        [Route("Actualizar")]
        public async Task<dynamic> Actualizar(ActualizarRolDTO request)
        {
            bool respuesta = false;
            try
            {
                respuesta = await _business.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }

        [HttpPut]
        [Route("Recuperar/{ID}")]
        public async Task<dynamic> RecuperarEliminado(int ID)
        {
            bool respuesta = false;
            try
            {
                respuesta = await _business.RecuperarEliminado(ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }

        //D
        [HttpDelete]
        [Route("Eliminar/{ID}")]
        public async Task<dynamic> Eliminar(int ID)
        {
            bool respuesta = false;
            try
            {
                respuesta = await _business.Eliminar(ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error: {ex.Message}");
            }
            return respuesta;
        }
    }
}
