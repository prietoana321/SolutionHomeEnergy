﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    public class CotizacionDTO
    {
        public int IdCotizacion { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? FormaPago { get; set; }

        public int? Plazo { get; set; }
        public string? TotalTexto { get; set; }

        public double? TotalInteres { get; set; }

        public double? Totalinteresxmes { get; set; }

        public double? Ahorra { get; set; }

        public double? Consumoelec { get; set; }

        public double? Consumosolar { get; set; }
        public string? PrecioTexto { get; set; }
        
        public string? Total { get; set; }

        public string? Socein { get; set; }

        public string? Tamañosistema { get; set; }

        public double? Inicial { get; set; }

        public string? Notas { get; set; }

        public string? Recursos { get; set; }
        public string? FechaRegistro { get; set; }
        public string? Url { get; set; }

        public int? IdEstado1 { get; set; }

        public string DescripcionEstado { get; set; }

        public bool? EsActivo { get; set; }

        public int? Plazoconsumo { get; set; }

        public int IdUsuario1 { get; set; }
        public int IdUsuario2 { get; set; }
        public int IdUsuario3 { get; set; }

    }
}
