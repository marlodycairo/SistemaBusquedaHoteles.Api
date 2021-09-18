using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class ClienteApplicationService : IClienteApplication
    {
        private readonly IClienteDomain clienteDomain;
        private readonly IMapper mapper;

        public ClienteApplicationService(IClienteDomain clienteDomain, IMapper mapper)
        {
            this.clienteDomain = clienteDomain;
            this.mapper = mapper;
        }

        public Domain.Models.Customer CreateCliente(Domain.Models.Customer clientes)
        {
            var obClientes = mapper.Map<Infrastructure.Entities.Customer>(clientes);
            var cliente = clienteDomain.CreateCliente(obClientes);
            return cliente;
        }

        public void DeleteCliente(int id)
        {
            clienteDomain.DeleteCliente(id);
        }

        public Domain.Models.Customer GetClienteById(int id)
        {
            return clienteDomain.GetClienteById(id);
        }

        public IEnumerable<Domain.Models.Customer> GetClientes()
        {
            return clienteDomain.GetClientes();
        }

        public Domain.Models.Customer UpdateCliente(Domain.Models.Customer clientes)
        {
            return clienteDomain.UpdateCliente(clientes);
        }
    }
}
