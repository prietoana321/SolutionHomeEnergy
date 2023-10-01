using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.API.Utilidad;

namespace SystemHomeEnergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioServicio;

        public ServicioController(IServicioService servicioServicio)
        {
            _servicioServicio = servicioServicio;
        }

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ServicioDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioServicio.lista();
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

        public async Task<IActionResult> Guardar([FromBody] ServicioDTO servicio)
        {
            var rsp = new Response<ServicioDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioServicio.Crear(servicio);
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

        public async Task<IActionResult> Editar([FromBody] ServicioDTO servicio)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioServicio.Editar(servicio);
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

        public async Task<IActionResult> Eliminar(int Id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioServicio.Eliminar(Id);
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
