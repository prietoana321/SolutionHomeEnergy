using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.UTILITY
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol


            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu


            #region Usuario
            CreateMap<Usuario, UsuarioDTO>().ForMember(destino => destino.RolDescripcion, opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre))
            .ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));

            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre));

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore()
                )
                .ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == true));
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

            #region Servicio
            CreateMap<Servicio, ServicioDTO>()
                .ForMember(destino => destino.DescripcionCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Nombre)
                )
                .ForMember(destino => destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));

            CreateMap<ServicioDTO, Servicio>()
                .ForMember(destino => destino.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino => destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true));
            #endregion Servicio

            #region Cotizacion
            CreateMap<Cotizacion, CotizacionDTO>()
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<CotizacionDTO, Cotizacion>()
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CO")))
                );

                CreateMap<Usuario, CotizacionDTO>()

                .ForMember(destino => 
                destino.IdUsuario1, opt => opt.MapFrom(origen => origen.UsuarioCotizacions))

                .ForMember(destino =>
                destino.IdUsuario2, opt => opt.MapFrom(origen => origen.UsuarioCotizacions))

                .ForMember(destino =>
                destino.IdUsuario3, opt => opt.MapFrom(origen => origen.UsuarioCotizacions));

            #endregion
            #region Contrato
            CreateMap<Contrato, ContratoDTO>()
                .ForMember(destino => destino.DescripcionServicio,
                opt => opt.MapFrom(origen => origen.IdServicio5Navigation.Nombre)
                )
                .ForMember(destino =>
                destino.PrecioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CO"))
                ))
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CO")))
                );
            CreateMap<ContratoDTO, Contrato>()

                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.PrecioTexto, new CultureInfo("es-CO"))
                ))
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToString(origen.TotalTexto, new CultureInfo("es-CO")))
                );

            #endregion
            #region
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            /*CreateMap<ClienteDTO, Cliente>()

                 .ForMember(destino => destino.UsuarioClientes, opt => opt.MapFrom(origen => origen.Idauditor)
                )
                 .ForMember(destino => destino.Idauditor,
            opt => opt.MapFrom(origen => origen.Detalle)
            )
                .ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == true));*/
            //.ForMember(destino => destino.Detalle,
            /// opt => opt.MapFrom(origen => origen.IdCliente) //.ForMember(destino => destino.DescripcionProducto,
            ////opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
            ////)no tiene foranea sino tabla intermedia y para tablas intermedias no se tiene modelo pa este caso no sabemos setear

            #endregion
            #region Prospecto

            CreateMap<Prospecto, ProspectoDTO>().ReverseMap();
            /*     .ForMember(destino => destino.NombreCompleto,
                opt => opt.MapFrom(origen => origen.Idauditor))

            

            .ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));

            CreateMap<ProspectoDTO,Prospecto>()

                 .ForMember(destino => destino.Idauditor, opt => opt.MapFrom(origen => origen.NombreCompleto)
                )
                .ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == true));
            */
            #endregion

            #region Estado

            CreateMap<Estado, EstadoDTO>().ReverseMap();
            #endregion
            /*#region Abierto-Estado
            CreateMap<Estado, AbiertoDTO>()
                .ForMember(destino => destino.Notas,
                opt => opt.MapFrom(origen => origen.IdEstado));


            CreateMap<AbiertoDTO,Estado>()
                .ForMember(destino => destino.IdEstado,
                opt => opt.MapFrom(origen => origen.Notas)
                );

            #endregion

            #region Cerrada-Estado
            CreateMap<Estado, CerradaDTO>()
                .ForMember(destino => destino.Notas,
                opt => opt.MapFrom(origen => origen.IdEstado));


            CreateMap<CerradaDTO,Estado>()
                .ForMember(destino => destino.IdEstado,
                opt => opt.MapFrom(origen => origen.Notas)
                );

            #endregion Estado-Cerrada*/


            /*#region Canal

            CreateMap<Estado, RazonDTO>()
                .ForMember(destino => destino.IdCotizacion,
                opt => opt.MapFrom(origen => origen.IdEstado)
                );

            #endregion Canal

            CreateMap<CanalDTO, Estado>()
               .ForMember(destino => destino.IdEstado,
               opt => opt.MapFrom(origen => origen.IdCanal)
               );
            */
         

        }
    }
}
