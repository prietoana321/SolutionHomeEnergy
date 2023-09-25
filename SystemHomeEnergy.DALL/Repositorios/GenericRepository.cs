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

        public async Task<TModelo> Crear(TModelo modelo)
        {
            /// USAMOS LA BASE DE DATOS Y ESTABLECEMOS CON QUE MODELO VAMOS A ESTAR UTILIZANDO, PASAMOS EL MODELO QUE ESTEMOS RECIBIENDO
            try
            {
                _dbcontext.Set<TModelo>().Add(modelo);
                //guardar cambios de manera asincrona asi:
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch { throw; }
            //throw new NotImplementedException();
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

        Task<IQueryable<TModelo>> IGenericRepository<TModelo>.Consultar(Expression<Func<TModelo, bool>> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
