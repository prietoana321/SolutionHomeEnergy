using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface IEstadoService
    {
        Task<List<EstadoDTO>> Lista();
        Task<EstadoDTO> Crear(EstadoDTO modelo);
        Task<bool> Editar(EstadoDTO modelo);
        Task<bool> Eliminar(int Id);
    }
}
