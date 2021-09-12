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

        public ClienteViewModel CreateCliente(ClienteViewModel clientes)
        {
            var obClientes = mapper.Map<Clientes>(clientes);
            var cliente = clienteDomain.CreateCliente(obClientes);
            return cliente;
        }

        public void DeleteCliente(int id)
        {
            clienteDomain.DeleteCliente(id);
        }

        public ClienteViewModel GetClienteById(int id)
        {
            return clienteDomain.GetClienteById(id);
        }

        public IEnumerable<ClienteViewModel> GetClientes()
        {
            return clienteDomain.GetClientes();
        }

        public ClienteViewModel UpdateCliente(ClienteViewModel clientes)
        {
            return clienteDomain.UpdateCliente(clientes);
        }
    }
}
