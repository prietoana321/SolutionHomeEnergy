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
    public class CategoriaService: ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepositorio;
        private readonly IMapper mapper;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> lista()
        {
            try
            {
                var listaCategorias = await _categoriaRepositorio.Consultar();
                return mapper.Map<List<CategoriaDTO>>(listaCategorias.ToList());
            }

            catch
            {
                throw;
            }
        }
    }
}
