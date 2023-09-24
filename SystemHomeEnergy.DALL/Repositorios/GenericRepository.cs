using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemHomeEnergy.DALL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.DALL.Repositorios
{
    public class GenericRepository<TModelo>:IGenericRepository<TModelo> where TModelo : class
    {
        private readonly BdhomeEnergyContext _dbcontext;

        public GenericRepository(BdhomeEnergyContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TModelo>Consultar(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _dbcontext.Set<TModelo>().Where(filtro).FirstOrDefaultAsync();
                return modelo;
            }
            catch { throw; }
        }

        public Task<TModelo> Crear(TModelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(TModelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TModelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
