using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class ClienteDomainService : IClienteDomain
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteDomainService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public ClienteViewModel CreateCliente(Customer clientes)
        {
            clienteRepository.CreateCliente(clientes);

            var obclientes = mapper.Map<ClienteViewModel>(clientes);

            return obclientes;
        }

        public void DeleteCliente(int id)
        {
            clienteRepository.DeleteCliente(id);
        }

        public ClienteViewModel GetClienteById(int id)
        {
            var obCliente = clienteRepository.GetClienteById(id);

            var cliente = mapper.Map<ClienteViewModel>(obCliente);

            return cliente;
        }

        public IEnumerable<ClienteViewModel> GetClientes()
        {
            var obClientes = clienteRepository.GetClientes();

            var clientes = mapper.Map<IEnumerable<ClienteViewModel>>(obClientes);

            return clientes;
        }

        public ClienteViewModel UpdateCliente(ClienteViewModel cliente)
        {
            var obCliente = mapper.Map<Customer>(cliente);

            clienteRepository.UpdateCliente(obCliente);

            return cliente;
        }
    }
}
