using Microsoft.IdentityModel.Abstractions;
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

        public async Task<Cotizacion> Registrar(Cotizacion modelo)
        {
            //CREAMOS UNA VARIABLE
            Cotizacion cotizacionGenerada = new();
            //si dentro de la logica ocurre un error la linea siguiente tiene que reestablecer todo al principio
            using (var transaction = _dbContext.Database.BeginTransaction())
                
                try
                {
                    foreach (MODELS.Contrato dv in modelo.Contrato)
                    {
                        Servicio servicio_encontrado = _dbContext.Servicios.Where(p => p.IdServicio == dv.IdCotizacion).First();
                        _dbContext.Servicios.Update(servicio_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();
                    NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;
                    _dbContext.NumeroDocumentos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();
                    //0001
                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);
                    modelo.NumeroDocumento = numeroVenta;

                    await _dbContext.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    cotizacionGenerada = modelo;
                    //la transaccion puede finalizar sin nigun problema
                    transaction.Commit();
                }
                catch
                {
                    //devolvera todo como estaba antes
                    transaction.Rollback();
                    //devuelve el error
                    throw;
                }
                return cotizacionGenerada;
            }
            //  throw new NotImplementedException();
        }
    }
}
