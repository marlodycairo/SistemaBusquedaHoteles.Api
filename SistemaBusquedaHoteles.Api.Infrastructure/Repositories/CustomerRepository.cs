using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> CreateCliente(Customer cliente)
        {
            await context.Customer.AddAsync(cliente);

            await context.SaveChangesAsync();

            return cliente;
        }

        public async Task DeleteCliente(int id)
        {
            Task<Customer> cliente = context.Customer.FirstOrDefaultAsync(p => p.Id == id);

            context.Remove(cliente);

            await context.SaveChangesAsync();
        }

        public async Task<Customer> GetClienteById(int id)
        {
            return await context.Customer.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetClientes()
        {
            return await context.Customer.ToListAsync();
        }

        public async Task<Customer> UpdateCliente(Customer cliente)
        {
            context.Update(cliente);

            await context.SaveChangesAsync();

            return cliente;
        }
    }
}
