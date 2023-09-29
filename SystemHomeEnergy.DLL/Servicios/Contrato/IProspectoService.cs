using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface IProspectoService
    {
        Task<List<Prospecto>> lista();
        Task<ProspectoDTO> Crear(ProspectoDTO modelo);
        Task<bool> Editar(ProspectoDTO modelo);
        Task<bool> Eliminar(int Id);
    }
}
