using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    internal class DashBoardDTO
    {
        public int? TotalContratos { get; set; }
        public string? TotalIngresos { get; set; }
        public List<CotizacionSemanaDTO>CotizacionUltimaSemana { get; set; }
    }
}
