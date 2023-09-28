using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.DLL.Servicios.Contrato;
using SystemHomeEnergy.DTO;
using SystemHomeEnergy.MODELS;

namespace SystemHomeEnergy.DLL.Servicios
{
    public class ServicioService: IServicioService
    {
        private readonly IGenericRepository<Servicio> _servicioRepositorio;
        private readonly IMapper _mapper;

        public ServicioService(IGenericRepository<Servicio> servicioRepositorio, IMapper mapper)
        {
            _servicioRepositorio = servicioRepositorio;
            this._mapper = mapper;
        }

        public async Task<List<ServicioDTO>> lista()
        {
            try
            {
                var queryServicio = await _servicioRepositorio.Consultar();
                var listaServicios = queryServicio.Include(cat => cat.IdCategoriaNavigation).ToList();
                return _mapper.Map<List<ServicioDTO>>(listaServicios).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ServicioDTO> Crear(ServicioDTO modelo)
        {
            try
            {
                var productoCreado = await _servicioRepositorio.Crear(_mapper.Map<Servicio>(modelo));
                if (productoCreado.IdServicio == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el producto");
                }
                return _mapper.Map<ServicioDTO>(productoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ServicioDTO modelo)
        {
            try
            {
                var ServicioModelo = _mapper.Map<Servicio>(modelo);
                var ServicioEncontrado = await _servicioRepositorio.Obtener(v => v.IdServicio == ServicioModelo.IdServicio);
                if (ServicioEncontrado == null)
                {
                    throw new TaskCanceledException("No se encuentra el servicio");
                }
                ServicioEncontrado.Nombre = ServicioModelo.Nombre;
                ServicioEncontrado.IdCategoria = ServicioModelo.IdCategoria;
                ServicioEncontrado.Precio = ServicioModelo.Precio;
                ServicioEncontrado.EsActivo = ServicioModelo.EsActivo;
                ServicioEncontrado.PulgadaIn = ServicioModelo.PulgadaIn;

                bool respuesta = await _servicioRepositorio.Editar(ServicioEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se puede Editar");
                }
                return respuesta;

            }
            catch
            {
                throw;
            }



        }

        public async Task<bool> Eliminar(int Id)
        {
            try
            {
                var ServicioEncontrado = await _servicioRepositorio.Obtener(s => s.IdServicio == Id);
                if (ServicioEncontrado == null)
                {
                    throw new TaskCanceledException("El servicio no exiate");
                }
                bool respuesta = await _servicioRepositorio.Eliminar(ServicioEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se elimino con exito");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

    }
}
