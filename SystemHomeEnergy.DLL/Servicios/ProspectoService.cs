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
    public class ProspectoService: IProspectoService
    {
        private readonly IGenericRepository<Prospecto> _prospectoRepositorio;
        private readonly IMapper _mapper;

        public ProspectoService(IGenericRepository<Prospecto> prospectoRepositorio, IMapper mapper)
        {
            _prospectoRepositorio = prospectoRepositorio;
            _mapper = mapper;
        }
<<<<<<< HEAD

        public async Task<ProspectoDTO> Crear(ProspectoDTO modelo)
        {
            try
            {
                var ProspectoCreado = await _prospectoRepositorio.Crear(_mapper.Map<Prospecto>(modelo));
                if (ProspectoCreado.IdProspecto == 0)
                {
                    throw new TaskCanceledException(" no se pudo crear");
                }
                var query = await _prospectoRepositorio.Consultar(u => u.IdProspecto == ProspectoCreado.IdProspecto);
                ProspectoCreado = query.Include(Prospecto => Prospecto.IdProspecto).First();
=======
        public async Task<List<ProspectoDTO>> Lista()
        {
            try
            {
                var queryProspecto = await _prospectoRepositorio.Consultar();
                var listaProspecto = queryProspecto.Include(Auditor => Auditor.Idauditor);
                return _mapper.Map<List<ProspectoDTO>>(listaProspecto.ToList());
            }
            catch
            { throw; }
        }
        public async Task<ProspectoDTO> Crear(ProspectoDTO modelo)
        {
            try
            {
                //nuestro usuariocreado recibe un prospecto, pero no es del tipo dto, asi que para recibirlo en _prospectooRepositorio debemos covertirlo, así lo aceptará el modelo
                var ProspectoCreado = await _prospectoRepositorio.Crear(_mapper.Map<Prospecto>(modelo));
                if (ProspectoCreado.IdProspecto == 0)
                {
                    throw new TaskCanceledException("prospecto no se pudo crear");
                }
                //con el await obtenemos, si es cero el prospecto fallo, sino, continuaria aquí
                var query = await _prospectoRepositorio.Consultar(u => u.IdProspecto == ProspectoCreado.IdProspecto);
                ProspectoCreado = query.Include(Auditor => Auditor.Idauditor).First();
>>>>>>> 5cde3ad063724c937d46599d79734f4e932c5d2d
                return _mapper.Map<ProspectoDTO>(ProspectoCreado);
            }
            catch
            {
                throw;
            }
<<<<<<< HEAD

=======
>>>>>>> 5cde3ad063724c937d46599d79734f4e932c5d2d
        }

        public async Task<bool> Editar(ProspectoDTO modelo)
        {
            try
            {
<<<<<<< HEAD
                var ProspectoModelo = _mapper.Map<Prospecto>(modelo);
                var ProspectoEncontrado = await _prospectoRepositorio.Obtener(u => u.IdProspecto == ProspectoModelo.IdProspecto);
                if (ProspectoEncontrado == null)
                {
                    throw new TaskCanceledException("No se encuentra el Prospecto");
                }
                ProspectoEncontrado.Contacto = ProspectoModelo.Contacto;
                ProspectoEncontrado.Idauditor = ProspectoEncontrado.Idauditor;
                ProspectoEncontrado.RazonSocial = ProspectoEncontrado.RazonSocial;
                ProspectoEncontrado.Direccion = ProspectoEncontrado.Direccion;
                ProspectoEncontrado.Fecha = ProspectoEncontrado.Fecha;
                ProspectoEncontrado.EsActivo = ProspectoModelo.EsActivo;

                bool respuesta = await _prospectoRepositorio.Editar(ProspectoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se puede Editar");
                }
                return respuesta;

=======
                var prospectoModelo = _mapper.Map<Prospecto>(modelo);
                var prospectoEncontrado = await _prospectoRepositorio.Obtener(u => u.IdProspecto == prospectoModelo.IdProspecto);
                if (prospectoEncontrado == null)
                {
                    throw new TaskCanceledException("prospecto no existe");
                }

                prospectoEncontrado.Fachadaimg = prospectoModelo.Fachadaimg;
                prospectoEncontrado.Url = prospectoModelo.Url;
                prospectoEncontrado.NombreCompleto = prospectoModelo.NombreCompleto;
                prospectoEncontrado.Direccion = prospectoModelo.Direccion;
                prospectoEncontrado.Contacto = prospectoModelo.Contacto;
                prospectoEncontrado.RazonSocial = prospectoModelo.RazonSocial;
                prospectoEncontrado.Idauditor = prospectoModelo.Idauditor;
                prospectoEncontrado.Detalle = prospectoEncontrado.Detalle;
                prospectoEncontrado.EsActivo = prospectoEncontrado.EsActivo;

                 bool respuesta = await _prospectoRepositorio.Editar(prospectoEncontrado);

                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo editar");
                }
                return respuesta;
>>>>>>> 5cde3ad063724c937d46599d79734f4e932c5d2d
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
<<<<<<< HEAD
                var ProspectoEncontrado = await _prospectoRepositorio.Obtener(u => u.IdProspecto == Id);
                if (ProspectoEncontrado == null)
                {
                    throw new TaskCanceledException("El Prospecto no exiate");
                }
                bool respuesta = await _prospectoRepositorio.Eliminar(ProspectoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se elimino con exito");
=======
                var prospectoEncontrado = await _prospectoRepositorio.Obtener(v => v.IdProspecto == Id);
                if (prospectoEncontrado == null)
                {
                    throw new TaskCanceledException("El prospecto no existe");
                }
                bool respuesta = await _prospectoRepositorio.Eliminar(prospectoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo eliminar");
>>>>>>> 5cde3ad063724c937d46599d79734f4e932c5d2d
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

<<<<<<< HEAD
        public async Task<List<Prospecto>> lista()
        {
            try
            {
                var queryProspecto = await _prospectoRepositorio.Consultar();
                var listaProspecto = queryProspecto.Include(cat => cat.Idauditor).ToList();
                return _mapper.Map<List<ProspectoDTO>>(listaProspecto).ToList();
            }
            catch
            {
                throw;
            }
        }
=======
>>>>>>> 5cde3ad063724c937d46599d79734f4e932c5d2d
    }
}

