using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class UsuarioCotizacion
{
    public int IdUsuarioCotizacion { get; set; }

    public int? IdUsuario4 { get; set; }

    public int? IdCotizacion1 { get; set; }

    public virtual Contratos? IdCotizacion1Navigation { get; set; }

    public virtual Usuario? IdUsuario4Navigation { get; set; }
}
