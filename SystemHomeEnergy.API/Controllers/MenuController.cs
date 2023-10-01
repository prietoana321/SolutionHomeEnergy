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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuServicio;

        public MenuController(IMenuService menuServicio)
        {
            _menuServicio = menuServicio;
        }
        public async Task<IActionResult>Lista()
        {
            var rsp = new Response<List<MenuDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _menuServicio.Lista();
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
