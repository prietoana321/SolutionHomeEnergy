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
                return _mapper.Map<ProspectoDTO>(ProspectoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProspectoDTO modelo)
        {
            try
            {
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
                var prospectoEncontrado = await _prospectoRepositorio.Obtener(v => v.IdProspecto == Id);
                if (prospectoEncontrado == null)
                {
                    throw new TaskCanceledException("El prospecto no existe");
                }
                bool respuesta = await _prospectoRepositorio.Eliminar(prospectoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo eliminar");
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

