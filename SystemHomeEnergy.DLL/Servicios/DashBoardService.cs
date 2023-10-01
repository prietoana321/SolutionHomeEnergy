using AutoMapper;
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
    public class DashBoardService:IDashBoardService
    {
        private readonly IVentaRepository _contratoRepositorio;

        private readonly IGenericRepository<Servicio> _servicioRepositorio;

        private readonly IMapper _mapper;

        public DashBoardService(IVentaRepository contratoRepositorio, IGenericRepository<Servicio> servicioRepositorio, IMapper mapper)
        {
            _contratoRepositorio = contratoRepositorio;
            _servicioRepositorio = servicioRepositorio;
            _mapper = mapper;
        }
        //recibe la tabla de ventas, el siguiente
        private IQueryable<Contratos> retornarVentas
            (IQueryable<Contratos> tablaVenta, int restarCantidadDias)
        {
            //el ? despues de datetime significa que permitira nullos
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).
                Select(v => v.FechaRegistro).First();
            //nos lo ordenará por fecha de registro
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
            //vamos a obtener la ultima fecha encontrada y a esa fecha le vamos a restar los dias
            return tablaVenta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
        }
        //EL SIGUIENTE ES PARA MOSTRAR EN NUESTRO DASHBOARD EL NUMERO DE VENTAS, COMO UN DIGITO
        private async Task<int> TotalVentasUltimaSemana()
        {
            int total = 0;
            IQueryable<Contratos> _ventaQuery = await _contratoRepositorio.Consultar();
            //validamos que si existan ventas

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                total = tablaVenta.Count();
            }
            return total;
        }

        //EL SIGUIENTE METODO MOSTRARÁ EL TOTAL DE INGRESOS DE LA ULTIMA SEMANA
        private async Task<string> TotalIngresosUltimaSemana()
        { //todo metodo retorna el tipo de aquí arriba
            decimal resultado = 0;

            IQueryable<Contratos> _ventaQuery = await _contratoRepositorio.Consultar();
            //validamos que si existan ventas
            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                //vamos a obtener el total de ventas que han sido registradas estos 7 dias
                resultado = tablaVenta.Select(v => v.Total).Sum(v => v.Value);
            }
            return Convert.ToString(resultado, new CultureInfo("es-CO"));
        }
        private async Task<int> TotalCotizacion()
        {

            IQueryable<Servicio> _servicioQuery = await _servicioRepositorio.Consultar();
            int total = _servicioQuery.Count();
            return total;
        }
        private async Task<Dictionary<string, int>> CotizacionesUltimaSemana
            ()
        {
            //variable diccionario oara ingresar es un string
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            IQueryable<Contratos> _ventaQuery = await _contratoRepositorio.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);

                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date)
                    .OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }
            return resultado;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashboard = new DashBoardDTO();
            try
            {
                vmDashboard.TotalContratos = await TotalVentasUltimaSemana();
                vmDashboard.TotalIngresos = await TotalIngresosUltimaSemana();
                vmDashboard.TotalContratos = await TotalCotizacion();

                List<CotizacionSemanaDTO> listaVentaSemana = new List<CotizacionSemanaDTO>();

                foreach (KeyValuePair<string, int> item in await CotizacionesUltimaSemana())
                {
                    listaVentaSemana.Add(new CotizacionSemanaDTO()
                    {
                        FechaContrato = item.Key,
                        TotalSemana = item.Value
                    });
                }
                vmDashboard.CotizacionesUltimaSemana = listaVentaSemana;
            }
            catch
            {
                throw;
            }
            return vmDashboard;
        }
    }
}
