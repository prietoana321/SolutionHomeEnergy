using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL;
using SystemHomeEnergy.DALL.Repositorios;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.DALL.Repositorios
{
    public class VentaRepository: GenericRepository<Cotizacion>, IVentaRepository
    {
        private readonly BdhomeEnergyContext _dbContext;

        public VentaRepository(BdhomeEnergyContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Cotizacion> Registrar(Cotizacion modelo)
        {
            throw new NotImplementedException();
        }
    }
}
