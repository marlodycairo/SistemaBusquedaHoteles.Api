using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext context;

        public ClienteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Clientes CreateCliente(Clientes cliente)
        {
            context.Cliente.Add(cliente);
            context.SaveChanges();

            return cliente;
        }

        public void DeleteCliente(int id)
        {
            var cliente = context.Cliente.FirstOrDefault(p => p.Id == id);

            context.Remove(cliente).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Clientes GetClienteById(int id)
        {
            return context.Cliente.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Clientes> GetClientes()
        {
            return context.Cliente.ToList();
        }

        public Clientes UpdateCliente(Clientes cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();

            return cliente;
        }
    }
}
