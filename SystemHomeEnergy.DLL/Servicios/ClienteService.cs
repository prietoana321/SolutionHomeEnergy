﻿using AutoMapper;
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
    public   class ClienteService:IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepositorio;

        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }
        public async Task<List<ClienteDTO>> lista()
        {
            try
            {
                var queryCliente = await _clienteRepositorio.Consultar();
                var listaCliente = queryCliente.Include(Auditor => Auditor.Idauditor);
                return _mapper.Map<List<ClienteDTO>>(listaCliente.ToList());
            }
            catch
            { throw; }
        }
        public async Task<ClienteDTO> Crear(ClienteDTO modelo)
        {
            try
            {
                //nuestro usuariocreado recibe un CLIENTE, pero no es del tipo dto, asi que para recibirlo en _clienteoRepositorio debemos covertirlo, así lo aceptará el modelo
                var ClienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>(modelo));
                if (ClienteCreado.IdCliente == 0)
                {
                    throw new TaskCanceledException("Cliente no se pudo crear");
                }
                //con el await obtenemos, si es cero el CLIENTE fallo, sino, continuaria aquí
                var query = await _clienteRepositorio.Consultar(u => u.IdCliente == ClienteCreado.IdCliente);
                ClienteCreado = query.Include(Auditor => Auditor.Idauditor).First();
                return _mapper.Map<ClienteDTO>(ClienteCreado);
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> Editar(ClienteDTO modelo)
        {

            try
            {
                var clienteModelo = _mapper.Map<Cliente>(modelo);
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.IdCliente == clienteModelo.IdCliente);
                if (clienteEncontrado == null)
                {
                    throw new TaskCanceledException("Usuario no existe");
                }
                usuarioEncontrado.NombreCompleto = usuarioModelo.NombreCompleto;
                usuarioEncontrado.Correo = usuarioModelo.Correo;
                usuarioEncontrado.IdRol = usuarioModelo.IdRol;
                usuarioEncontrado.Clave = usuarioModelo.Clave;
                usuarioEncontrado.EsActivo = usuarioModelo.EsActivo;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

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

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

       
    }
}