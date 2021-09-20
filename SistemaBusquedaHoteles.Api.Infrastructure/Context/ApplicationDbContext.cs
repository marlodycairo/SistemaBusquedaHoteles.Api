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

        public DbSet<ReservationsRooms> ConsultaReservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Configuración de relaciones uno a uno y uno a muchos
            modelBuilder.Entity<Location>()
                .HasOne(r => r.Reservations)
                .WithOne(i => i.Locations)
                .HasForeignKey<Reservation>(r => r.SedeId);

            modelBuilder.Entity<Customer>()
                .HasOne(h => h.Reservations)
                .WithOne(i => i.Customers)
                .HasForeignKey<Reservation>(h => h.ClienteId);

            modelBuilder.Entity<Location>()
                .HasOne(s => s.Room)
                .WithOne(i => i.Locations)
                .HasForeignKey<Rooms>(s => s.SedeId);

            modelBuilder.Entity<Rate>()
               .HasOne(s => s.Reservations)
               .WithOne(i => i.Rates)
               .HasForeignKey<Reservation>(s => s.TarifaId);

            modelBuilder.Entity<RoomTypes>()
               .HasOne(s => s.Reservations)
               .WithOne(i => i.RoomType)
               .HasForeignKey<Reservation>(s => s.TipoAlojamientoId);

            modelBuilder.Entity<Rooms>()
               .HasOne(s => s.Reservations)
               .WithOne(i => i.Room)
               .HasForeignKey<Reservation>(s => s.HabitacionId);

            modelBuilder.Entity<RoomTypes>()
               .HasOne(s => s.Room)
               .WithOne(i => i.RoomType)
               .HasForeignKey<Rooms>(s => s.TipoId);

            modelBuilder.Entity<ReservationsRooms>()
                .HasKey(p => new { p.ReservationsId, p.RoomsId });

            ////Configuracion propiedades de navegacion consultar: (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)
            //modelBuilder.Entity<Sedes>()
            //    .Navigation(p => p.Habitaciones)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
