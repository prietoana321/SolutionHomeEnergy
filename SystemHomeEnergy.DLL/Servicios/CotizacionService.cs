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
        private readonly IGenericRepository<UsuarioCotizacion> _usuarioCotizacionRepositorio;
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IGenericRepository<ServicioCotizacion> _servicioCotizacionRepositorio;
        private readonly IGenericRepository<Servicio> _servicioRepositorio;
        private readonly IMapper _mapper;

        public CotizacionService(IVentaRepository contratoRepositorio, IGenericRepository<Contratos> contratosRepositorio, IGenericRepository<UsuarioCotizacion> usuarioCotizacionRepositorio, IGenericRepository<Usuario> usuarioRepositorio, IGenericRepository<ServicioCotizacion> servicioCotizacionRepositorio, IGenericRepository<Servicio> servicioRepositorio, IMapper mapper)
        {
            _contratoRepositorio = contratoRepositorio;
            _contratosRepositorio = contratosRepositorio;
            _usuarioCotizacionRepositorio = usuarioCotizacionRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _servicioCotizacionRepositorio = servicioCotizacionRepositorio;
            _servicioRepositorio = servicioRepositorio;
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
        /*
        public async Task<List<CotizacionDTO>> Lista(int IdUsuario)

        {
            IQueryable<Usuario> tbUsuario = await _usuarioRepositorio.Consultar(u => u.IdUsuario == IdUsuario);
            IQueryable<UsuarioCotizacion> tbUsuarioCotizacion = await _usuarioCotizacionRepositorio.Consultar();
            IQueryable<Contratos> tbContratos = await _contratosRepositorio.Consultar();

            try
            {
                IQueryable<Menu> tbResultado = (from u in tbContratos
                                                join mr in tbUsuarioCotizacion on u.Contrato equals mr.IdCotizacion1
                                                join m in tbUsuario on mr.IdUsuario equals m.IdUsuario
                                                select m).AsQueryable();

                var listaUsuarios = tbResultado.ToList();
                return _mapper.Map<List<CotizacionDTO>>(listaUsuarios);
               
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CotizacionDTO>> ListaServicio(int IdServicio)
        {
            IQueryable<Servicio> tbServicio = await _servicioRepositorio.Consultar(u => u.IdServicio == IdServicio);
            IQueryable<ServicioCotizacion> tbServicioCotizacion = await _servicioCotizacionRepositorio.Consultar();
            IQueryable<Contratos> tbCotizacion = await _contratosRepositorio.Consultar();

            try
            {
                IQueryable<Menu> tbResultado = (from u in tbServicio
                                                join mr in tbServicioCotizacion on u.IdServicio equals mr.IdServicio1
                                                join m in tbCotizacion on mr.IdCotizacion equals m.IdCotizacion
                                                select m).AsQueryable();
                var listaServicios = tbResultado.ToList();

                return _mapper.Map<List<CotizacionDTO>>(listaServicios);
            }
            catch
            {
                throw;
            }
        }
        */
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
