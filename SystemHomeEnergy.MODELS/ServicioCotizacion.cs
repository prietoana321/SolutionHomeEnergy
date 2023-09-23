using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class ServicioCotizacion
{
    public int IdServicioCotizacion { get; set; }

    public int? IdServicio1 { get; set; }

    public int? IdCotizacion2 { get; set; }

    public virtual Cotizacion? IdCotizacion2Navigation { get; set; }

    public virtual Servicio? IdServicio1Navigation { get; set; }
}
