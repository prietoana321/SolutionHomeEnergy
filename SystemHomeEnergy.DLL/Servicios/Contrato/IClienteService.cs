using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DTO;

namespace SystemHomeEnergy.DLL.Servicios.Contrato
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> Lista();

        Task<ClienteDTO> Crear(ClienteDTO modelo);
        Task<bool> Editar(ClienteDTO modelo);
        Task<bool> Eliminar(int Id);
    }
}
