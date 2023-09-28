using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public int? PulgadaIn { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Contrato> Contrato { get; } = new List<Contrato>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<ServicioCotizacion> ServicioCotizacions { get; } = new List<ServicioCotizacion>();
}
