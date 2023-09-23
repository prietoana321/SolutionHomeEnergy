using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class UsuarioProspecto
{
    public int IdUsuarioProspecto { get; set; }

    public int? IdUsuario2 { get; set; }

    public int? IdProspecto2 { get; set; }

    public virtual Prospecto? IdProspecto2Navigation { get; set; }

    public virtual Usuario? IdUsuario2Navigation { get; set; }
}
