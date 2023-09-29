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
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> _menuRepositorio;
        private readonly IMapper __mapper;

        public MenuService(IGenericRepository<Menu> menuRepositorio, IMapper mapper)
        {
            _menuRepositorio = menuRepositorio;
            __mapper = mapper;
        }

        public async Task<List<MenuDTO>> lista(int IdMenu)
        {
            try
            {
                var queryMenu = await _menuRepositorio.Consultar();
                var listaMenu = queryMenu.Include(Menu => Menu.IdMenu).ToList();
                return __mapper.Map<List<MenuDTO>>(listaMenu).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
           
