using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemHomeEnergy.MODELS;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL;




namespace SystemHomeEnergy.DALL.Repositorios.Contrato
{
    public interface IVentaRepository:IGenericRepository<Contratos>
    {
        Task<Contratos> Registrar(Contratos modelo);
    
    }
}
