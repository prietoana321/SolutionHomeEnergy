﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DTO
{
    internal class UsurioDTO
    {
        public int IdUsuario { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Correo { get; set; }

        public int? IdRol { get; set; }
        public string? RolDescripcion { get; set; }

        public string? Clave { get; set; }

        public bool? EsActivo { get; set; }
    }
}
