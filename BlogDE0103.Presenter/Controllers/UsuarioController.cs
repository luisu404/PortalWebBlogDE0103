using BlogDE0103.Business.UsesCases;
using BlogDE0103.Data;
using BlogDE0103.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BlogDE0103.Presenter.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _usuarioBusiness;

        public UsuarioController(UsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }


        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> RegistrarUsuarioRequest(UsuarioEntity request)
        {
            try
            {
                await _usuarioBusiness.Agregar(request);
                return Ok($"Rol registrado correctamente. Hora y Fecha: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
