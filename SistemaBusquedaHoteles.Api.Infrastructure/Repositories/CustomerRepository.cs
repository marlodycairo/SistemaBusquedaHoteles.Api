﻿using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<CustomerResponse> CreateCliente(Customer cliente)
        {
            var customerExists = await context.Customer.AnyAsync(p => p.IDCliente == cliente.IDCliente);

            if (customerExists)
            {
                return new CustomerResponse() { Response = ResponseMessages.ExistRegister };
            }

            context.Customer.Add(cliente);

            await context.SaveChangesAsync();

            return new CustomerResponse() { Response = ResponseMessages.SuccedSavedRegister };
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = context.Customer.FirstOrDefaultAsync(p => p.Id == id);

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
            context.Entry(cliente);

            await context.SaveChangesAsync();

            return cliente;
        }
    }
}
