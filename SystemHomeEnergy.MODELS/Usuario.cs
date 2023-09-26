using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public int? IdRol { get; set; }
    public string? RolDescripcion { get; set; }

    public string? Clave { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<UsuarioCliente> UsuarioClientes { get; } = new List<UsuarioCliente>();

    public virtual ICollection<UsuarioCotizacion> UsuarioCotizacions { get; } = new List<UsuarioCotizacion>();

    public virtual ICollection<UsuarioProspecto> UsuarioProspectos { get; } = new List<UsuarioProspecto>();
}
