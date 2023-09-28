using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface ICotizacionService
    {
        Task<CotizacionDTO> Registrar(CotizacionDTO modelo);
        Task<List<CotizacionDTO>> Historial(string buscarPor, string numerocotizacion, string fechaInicio, string fechaFin);
        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin);
    }
}
