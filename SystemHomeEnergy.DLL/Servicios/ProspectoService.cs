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

        public Task<ProspectoDTO> Crear(ProspectoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(ProspectoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Prospecto>> lista()
        {
            throw new NotImplementedException();
        }

    }
}

