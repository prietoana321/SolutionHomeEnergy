using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface IServicioService
    {
        Task<List<ServicioDTO>> lista();
        Task<ServicioDTO> Crear(ServicioDTO modelo);
        Task<bool> Editar(ServicioDTO modelo);
        Task<bool> Eliminar(int Id);
    }
}
