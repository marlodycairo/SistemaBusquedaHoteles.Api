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

        public Domain.Models.Customers CreateCliente(Infrastructure.Entities.Customer clientes)
        {
            clienteRepository.CreateCliente(clientes);

            var obclientes = mapper.Map<Domain.Models.Customers>(clientes);

            return obclientes;
        }

        public void DeleteCliente(int id)
        {
            clienteRepository.DeleteCliente(id);
        }

        public Domain.Models.Customers GetClienteById(int id)
        {
            var obCliente = clienteRepository.GetClienteById(id);

            var cliente = mapper.Map<Domain.Models.Customers>(obCliente);

            return cliente;
        }

        public IEnumerable<Domain.Models.Customers> GetClientes()
        {
            var obClientes = clienteRepository.GetClientes();

            var clientes = mapper.Map<IEnumerable<Domain.Models.Customers>>(obClientes);

            return clientes;
        }

        public Domain.Models.Customers UpdateCliente(Domain.Models.Customers cliente)
        {
            var obCliente = mapper.Map<Infrastructure.Entities.Customer>(cliente);

            clienteRepository.UpdateCliente(obCliente);

            return cliente;
        }
    }
}
