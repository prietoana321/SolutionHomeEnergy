using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdServicio5 { get; set; }

    public int? Cantidad { get; set; }

    public string? Documento { get; set; }

    public string? Url { get; set; }

    public decimal? Precio { get; set; }

    public double? Tax { get; set; }

    public decimal? Total { get; set; }

    public virtual Cotizacion? IdCotizacionNavigation { get; set; }

    public virtual Servicio? IdServicio5Navigation { get; set; }
}
