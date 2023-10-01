using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.MODELS;
using SystemHomeEnergy.API.Utilidad;


namespace SystemHomeEnergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;

        public RolController(IRolService rolServicio)
        {
            _rolServicio = rolServicio;
        }

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RolDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _rolServicio.Lista();
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
