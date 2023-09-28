using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.DLL.Servicios
{
    public class CotizacionService : ICotizacionService
    {
        private readonly IVentaRepository _contratoRepositorio;
        private readonly IGenericRepository<Contratos> _contratosRepositorio;
        private readonly IMapper _mapper;


        public CotizacionService(IVentaRepository contratoRepositorio, IGenericRepository<Contratos> contratosRepositorio, IMapper mapper)
        {
            this._contratosRepositorio = contratosRepositorio;
            this._contratosRepositorio = contratosRepositorio;
            _mapper = mapper;
        }

        public async Task<List<CotizacionDTO>> Historial(string buscarPor, string numerocotizacion, string fechaInicio, string fechaFin)
        {
            IQueryable<Contratos> query = await _contratoRepositorio.Consultar();
            var listaResultado = new List<Contratos>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                    DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                    listaResultado = await query.Where(v =>
                   v.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                   v.FechaRegistro.Value.Date <= fech_Fin.Date).Include(dv => dv.Contrato)
                   .ThenInclude(p => p.IdServicio5Navigation).ToListAsync();
                }
                else
                {
                    listaResultado = await query.Where(v =>
                   v.NumeroDocumento == numerocotizacion).Include(dv => dv.Contrato)
                   .ThenInclude(p => p.IdServicio5Navigation).ToListAsync();
                }
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<CotizacionDTO>>(listaResultado);
        }

        public async Task<CotizacionDTO> Registrar(CotizacionDTO modelo)
        {
            try
            {
                var ventaGenerada = await _contratoRepositorio.Registrar(_mapper.Map<Contratos>(modelo));
                if (ventaGenerada.IdCotizacion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                return _mapper.Map<CotizacionDTO>(ventaGenerada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            IQueryable<Contratos> query = await _contratosRepositorio.Consultar();
            var listaResultado = new List<Contratos>();
            /*IQueryable<Contrato> query = await _contratoRepositorio.Consultar();
            //ESE RETORNA UNA LISTA DEL TIPO DETALLE VENTA
            var listaResultado = new List<Contratos>();*/
            try
            {
                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                listaResultado = await query.Include(p => p.ServicioCotizacions).Include(v => v.IdEstado1Navigation)
                    .Where(dv => dv.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                    dv.FechaRegistro.Value.Date <= fech_Fin.Date).ToListAsync();

                /*EL METODO ANTERIOR ESTA EN ANALISIS
                 
                 IQueryable<DetalleVenta> query = await _detalleVentaRepositorio.Consultar();
            //ESE RETORNA UNA LISTA DEL TIPO DETALLE VENTA
            var listaResultado = new List<DetalleVenta>();
            try
            {
                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                listaResultado = await query.Include(p => p.IdProductoNavigation).Include(v => v.IdVentaNavigation)
                    .Where(dv => dv.IdVentaNavigation.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                    dv.IdVentaNavigation.FechaRegistro.Value.Date <= fech_Fin.Date).ToListAsync();
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<ReporteDTO>>(listaResultado);
                */
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<ReporteDTO>>(listaResultado);

        }
    }
}
