using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<RoomTypes> RoomTypes { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Configuración de relaciones uno a uno y uno a muchos
            modelBuilder.Entity<Customer>()
                .HasOne(h => h.Reservations)
                .WithOne(i => i.Customers)
                .HasForeignKey<Reservation>(h => h.ClienteId);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.IDCliente)
                .IsUnique();

            ////Configuracion propiedades de navegacion consultar: (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)
        }
    }
}
