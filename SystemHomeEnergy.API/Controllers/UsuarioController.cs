using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.API.Utilidad;

namespace SystemHomeEnergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServicio;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<UsuarioDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServicio.Lista();
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpPost]
        [Route("IniciarSesion")]

        public async Task<IActionResult> IniciarSesion([FromBody] loginDTO login)
        {
            var rsp = new Response<SesionDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServicio.ValidarCredenciales(login.Correo, login.Clave);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<UsuarioDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServicio.Crear(usuario);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpPost]
        [Route("Editar")]

        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServicio.Editar(usuario);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpPost]
        [Route("Eliminar /{Id: int}")]

        public async Task<IActionResult>Eliminar(int Id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServicio.Eliminar(Id);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
    }
}

