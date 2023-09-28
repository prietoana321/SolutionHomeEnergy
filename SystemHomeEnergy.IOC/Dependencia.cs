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


        }
    }
}
