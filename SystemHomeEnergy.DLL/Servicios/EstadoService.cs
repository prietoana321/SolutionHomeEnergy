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

namespace SystemHomeEnergy.DLL.Estados
{
    public class EstadoService:IEstadoService
    {
        private readonly IGenericRepository<Estado> _estadoRepositorio;
        private readonly IMapper _mapper;

        public EstadoService(IGenericRepository<Estado> estadoRepositorio, IMapper mapper)
        {
            _estadoRepositorio = estadoRepositorio;
            _mapper = mapper;
        }
        public async Task<List<EstadoDTO>> Lista()
        {
            try
            {
                var queryEstado = await _estadoRepositorio.Consultar();
                var listaEstado = queryEstado.Include(cat => cat.Cotizacions).ToList();
                return _mapper.Map<List<EstadoDTO>>(listaEstado).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<EstadoDTO> Crear(EstadoDTO modelo)
        {
            try
            {
                var estadoCreado = await _estadoRepositorio.Crear(_mapper.Map<Estado>(modelo));
                if (estadoCreado.IdEstado == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el producto");
                }
                return _mapper.Map<EstadoDTO>(estadoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EstadoDTO modelo)
        {
            try
            {
                var EstadoModelo = _mapper.Map<Estado>(modelo);
                var EstadoEncontrado = await _estadoRepositorio.Obtener(v => v.IdEstado == EstadoModelo.IdEstado);
                if (EstadoEncontrado == null)
                {
                    throw new TaskCanceledException("No se encuentra el Estado");
                }
                EstadoEncontrado.Nombre = EstadoModelo.Nombre;
                EstadoEncontrado.Descripcion = EstadoModelo.Descripcion;

        bool respuesta = await _estadoRepositorio.Editar(EstadoEncontrado);
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
                var EstadoEncontrado = await _estadoRepositorio.Obtener(s => s.IdEstado == Id);
                if (EstadoEncontrado == null)
                {
                    throw new TaskCanceledException("El Estado no existe");
                }
                bool respuesta = await _estadoRepositorio.Eliminar(EstadoEncontrado);
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
