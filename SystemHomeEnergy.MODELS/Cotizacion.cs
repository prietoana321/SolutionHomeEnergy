using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Cotizacion
{
    public int IdCotizacion { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? FormaPago { get; set; }

    public int? Plazo { get; set; }

    public double? TotalInteres { get; set; }

    public double? Totalinteresxmes { get; set; }

    public double? Ahorra { get; set; }

    public double? Consumoelec { get; set; }

    public double? Consumosolar { get; set; }

    public decimal? Total { get; set; }

    public string? Socein { get; set; }

    public string? Tamañosistema { get; set; }

    public double? Inicial { get; set; }

    public string? Notas { get; set; }

    public string? Recursos { get; set; }

    public string? Url { get; set; }

    public int? IdEstado1 { get; set; }

    public bool? EsActivo { get; set; }

    public int? Plazoconsumo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Contrato?> Contrato { get; } = new List<Contrato>();

    public virtual Estado? IdEstado1Navigation { get; set; }

    public virtual ICollection<ServicioCotizacion?> ServicioCotizacions { get; } = new List<ServicioCotizacion>();

    public virtual ICollection<UsuarioCotizacion?> UsuarioCotizacions { get; } = new List<UsuarioCotizacion>();
  

}
