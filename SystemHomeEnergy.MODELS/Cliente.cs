using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Fachadaimg { get; set; }

    public string? Url { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public string? RazonSocial { get; set; }

    public int? Idauditor { get; set; }

    public string? Detalle { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<UsuarioCliente> UsuarioClientes { get; } = new List<UsuarioCliente>();
}
