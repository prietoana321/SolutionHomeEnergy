using AutoMapper;
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

        public Task<List<Prospecto>> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
