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

        public DbSet<Rooms> Room { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RoomTypes> RoomType { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Configuración de relaciones uno a uno y uno a muchos
            modelBuilder.Entity<Customer>()
                .HasOne(r => r.Reservation)
                .WithOne(i => i.Customer)
                .HasForeignKey<Reservation>(r => r.Id);

            //modelBuilder.Entity<Habitaciones>()
            //    .HasOne(h => h.Reservacion)
            //    .WithOne(i => i.Habitaciones)
            //    .HasForeignKey<Reservacion>(h => h.HabitacionId);

            //modelBuilder.Entity<Sedes>()
            //    .HasOne(s => s.Reservacion)
            //    .WithOne(i => i.Sedes)
            //    .HasForeignKey<Reservacion>(s => s.SedeId);

            //modelBuilder.Entity<Habitaciones>()
            //   .HasOne(s => s.Reserva)
            //   .WithOne(i => i.Habitacion)
            //   .HasForeignKey<Reservacion>(s => s.HabitacionId);

            ////Configuracion propiedades de navegacion consultar: (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)
            //modelBuilder.Entity<Sedes>()
            //    .Navigation(p => p.Habitaciones)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
