using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; } = new List<Cotizacion>();
}
