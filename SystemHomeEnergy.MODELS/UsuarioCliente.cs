using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class UsuarioCliente
{
    public int IdUsuarioCliente { get; set; }

    public int? IdUsuario3 { get; set; }

    public int? IdClientes1 { get; set; }

    public virtual Cliente? IdClientes1Navigation { get; set; }

    public virtual Usuario? IdUsuario3Navigation { get; set; }
}
