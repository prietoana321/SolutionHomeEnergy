using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.API.Utilidad;
using SystemHomeEnergy.MODELS;
using System.Threading.Tasks;

namespace SystemHomeEnergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacionService _cotizacionServicio;

        public CotizacionController(ICotizacionService cotizacionServicio)
        {
            _cotizacionServicio = cotizacionServicio;
        }
        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CotizacionDTO cotizacion)
        {
            var rsp = new Response<CotizacionDTO>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _cotizacionServicio.Registrar(cotizacion);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]

        public async Task<IActionResult> Historial(string buscarpor,string? numerocotizacion, string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<CotizacionDTO>>();
            numerocotizacion = numerocotizacion is null? "" : numerocotizacion;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            buscarpor = buscarpor is null ? "" : buscarpor;
            try
            {
                rsp.Status = true;
                rsp.Value = await _cotizacionServicio.Historial(buscarpor, numerocotizacion, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            //TODAS LOS SOLICITUDES SERÁN RESPUESTAS EXITOSAS
            return Ok(rsp);
        }
        [HttpGet]
        [Route("Reporte")]

        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<ReporteDTO>>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _cotizacionServicio.Reporte(fechaInicio, fechaFin);
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
