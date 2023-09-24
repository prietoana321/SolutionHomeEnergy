using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemHomeEnergy.MODELS;
using System.Threading.Tasks;




namespace SystemHomeEnergy.DALL.Repositorios.Contrato
{
    public interface IVentaRepository:IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    
    }
}
