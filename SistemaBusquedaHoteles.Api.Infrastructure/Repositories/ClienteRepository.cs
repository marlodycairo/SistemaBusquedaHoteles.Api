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

        public Clientes CreateReservacion(Clientes clientes)
        {
            context.Cliente.Add(clientes);
            context.SaveChanges();

            return clientes;
        }

        public void DeleteReservacion(int id)
        {
            var reserva = context.Cliente.FirstOrDefault(p => p.Id == id);

            context.Remove(reserva);



            return ;
        }

        public Clientes GetReservaById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clientes> GetReservaciones()
        {
            throw new NotImplementedException();
        }

        public Clientes UpdateReservacion(Clientes clientes)
        {
            throw new NotImplementedException();
        }
    }
}
