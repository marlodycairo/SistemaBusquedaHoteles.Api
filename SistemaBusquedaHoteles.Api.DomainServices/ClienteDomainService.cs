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

        public Domain.Models.Customer CreateCliente(Infrastructure.Entities.Customer clientes)
        {
            clienteRepository.CreateCliente(clientes);

            var obclientes = mapper.Map<Domain.Models.Customer>(clientes);

            return obclientes;
        }

        public void DeleteCliente(int id)
        {
            clienteRepository.DeleteCliente(id);
        }

        public Domain.Models.Customer GetClienteById(int id)
        {
            var obCliente = clienteRepository.GetClienteById(id);

            var cliente = mapper.Map<Domain.Models.Customer>(obCliente);

            return cliente;
        }

        public IEnumerable<Domain.Models.Customer> GetClientes()
        {
            var obClientes = clienteRepository.GetClientes();

            var clientes = mapper.Map<IEnumerable<Domain.Models.Customer>>(obClientes);

            return clientes;
        }

        public Domain.Models.Customer UpdateCliente(Domain.Models.Customer cliente)
        {
            var obCliente = mapper.Map<Infrastructure.Entities.Customer>(cliente);

            clienteRepository.UpdateCliente(obCliente);

            return cliente;
        }
    }
}
