﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> lista(int IdMenu);
    }
}
