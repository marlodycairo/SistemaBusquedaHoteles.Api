using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.ApplicationServices;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.DomainServices;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using SistemaBusquedaHoteles.Api.Domain.Validators;

namespace SistemaBusquedaHoteles
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFluentValidation();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Ignorar referencia circular. Corregir error JsonException. "A possible object cycle was detected."
            services.AddControllers().AddJsonOptions(opt =>
                                        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDefault"));
            });

            services.AddScoped<IHabitacionesRepository, HabitacionesRepository>();
            services.AddScoped<ISedesRepository, SedesRepository>();
            services.AddScoped<ITipoAlojamientoRepository, TipoAlojamientoRepository>();

            services.AddScoped<IHabitacionesDomain, HabitacionesDomainServices>();
            services.AddScoped<ISedesDomain, SedesDomainServices>();
            services.AddScoped<ITipoAlojamientoDomain, TipoAlojamientoDomainServices>();

            services.AddScoped<IHabitacionesApplication, HabitacionesApplicationService>();
            services.AddScoped<ISedesApplication, SedesApplicationService>();
            services.AddScoped<ITipoAlojamientoApplication, TipoAlojamientoApplicationService>();

            services.AddScoped<ITarifasRepository, TarifasRepository>();
            services.AddScoped<ITarifasDomain, TarifasDomainServices>();
            services.AddScoped<ITarifasApplication, TarifasApplicationServices>();

            services.AddScoped<IReservacionRepository, ReservacionRepository>();
            services.AddScoped<IReservacionDomain, ReservacionDomainServices>();
            services.AddScoped<IReservacionApplication, ReservacionApplicationServices>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteDomain, ClienteDomainService>();
            services.AddScoped<IClienteApplication, ClienteApplicationService>();

            services.AddTransient<RoomValidator>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaBusquedaHoteles", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaBusquedaHoteles v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
