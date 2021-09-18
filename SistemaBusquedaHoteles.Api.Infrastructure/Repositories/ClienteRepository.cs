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

        public Customer CreateCliente(Customer cliente)
        {
            context.Customer.Add(cliente);
            context.SaveChanges();

            return cliente;
        }

        public void DeleteCliente(int id)
        {
            var cliente = context.Customer.FirstOrDefault(p => p.Id == id);

            context.Remove(cliente).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Customer GetClienteById(int id)
        {
            return context.Customer.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetClientes()
        {
            return context.Customer
                .Include(p => p.Reservacion)
                .ToList();
        }

        public Customer UpdateCliente(Customer cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();

            return cliente;
        }
    }
}
