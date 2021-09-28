using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.ApplicationServices;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Filters;
using SistemaBusquedaHoteles.Api.DomainServices;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Text.Json.Serialization;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Ignorar referencia circular. Corregir error JsonException. "A possible object cycle was detected."
            services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressModelStateInvalidFilter = true;
                });

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(fv =>
                {
                    //fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDefault"));
            });

            services.AddScoped<IRoomsRepository, RoomsRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IRoomTypesRepository, RoomTypesRepository>();

            services.AddScoped<IRoomsDomain, RoomsDomainServices>();
            services.AddScoped<ILocationDomain, LocationDomainServices>();
            services.AddScoped<IRoomTypesDomain, RoomTypesDomainServices>();

            services.AddScoped<IRoomsApplication, RoomsApplicationService>();
            services.AddScoped<ILocationApplication, SedesApplicationService>();
            services.AddScoped<IRoomTypesApplication, TipoAlojamientoApplicationService>();

            services.AddScoped<IRatesRepository, RatesRepository>();
            services.AddScoped<IRatesDomain, RatesDomainServices>();
            services.AddScoped<IRatesApplication, TarifasApplicationServices>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationDomain, ReservationDomainServices>();
            services.AddScoped<IReservationApplication, ReservacionApplicationServices>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDomain, CustomerDomainService>();
            services.AddScoped<ICustomerApplication, ClienteApplicationService>();

            //services.AddTransient<IValidator<Customer>, CustomerValidator>();

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
