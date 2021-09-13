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

        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Sedes> Sedes { get; set; }
        public DbSet<TipoAlojamiento> TipoAlojamiento { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<Clientes> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Configuración de relaciones uno a uno y uno a muchos
            //modelBuilder.Entity<Habitaciones>()
            //    .HasOne(h => h.Reservacion)
            //    .WithOne(i => i.Habitaciones)
            //    .HasForeignKey<Reservacion>(h => h.HabitacionId);

            //modelBuilder.Entity<Sedes>()
            //    .HasOne(s => s.Reservacion)
            //    .WithOne(i => i.Sedes)
            //    .HasForeignKey<Reservacion>(s => s.SedeId);

            modelBuilder.Entity<Habitaciones>()
               .HasOne(s => s.Reserva)
               .WithOne(i => i.Habitacion)
               .HasForeignKey<Reservacion>(s => s.HabitacionId);

            ////Configuracion propiedades de navegacion consultar: (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)
            //modelBuilder.Entity<Sedes>()
            //    .Navigation(p => p.Habitaciones)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
