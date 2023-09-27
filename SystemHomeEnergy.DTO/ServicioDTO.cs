using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    public class ServicioDTO
    {
        public int IdServicio { get; set; }

        public string? Nombre { get; set; }

        public int? IdCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public decimal? Precio { get; set; }

        public bool? EsActivo { get; set; }

        public int? PulgadaIn { get; set; }
    }
}
