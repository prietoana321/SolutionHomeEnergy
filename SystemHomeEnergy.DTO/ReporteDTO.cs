using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    public class ReporteDTO
    {
        public string? NumeroDocumento { get; set; }

        public string? FormaPago { get; set; }
        public string? Total { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? PulgadaIn { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public string ? TotalReporte { get; set; }
    }
}
