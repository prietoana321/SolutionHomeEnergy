using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    public class ContratoDTO
    {
        public int IdContrato { get; set; }

        public int? IdCotizacion { get; set; }

        public int? IdServicio5 { get; set; }

        public int? Cantidad { get; set; }
        public string? DescripcionServicio { get; set; }

        public string? PrecioTexto { get; set; }
        public string? TotalTexto { get; set; }
        public string? Documento { get; set; }

        public string? Url { get; set; }

        public decimal? Precio { get; set; }

        public double? Tax { get; set; }

        public decimal? Total { get; set; }



    }
}
