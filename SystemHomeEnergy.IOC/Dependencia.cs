using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.MODELS;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.DALL.Repositorios;
using SystemHomeEnergy.UTILITY;
using SystemHomeEnergy.DLL.Servicios;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DLL.Estados;

namespace SystemHomeEnergy.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BdhomeEnergyContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            //en la siguiente linea utilizamos un modelo generico
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository,VentaRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<ICotizacionService, CotizacionService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IProspectoService, ProspectoService>();
            services.AddScoped<DbContext, BdhomeEnergyContext>();



        }
    }
}
