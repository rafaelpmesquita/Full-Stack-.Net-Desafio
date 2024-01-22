using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using TesteNetCore.Application.Commands.AcceptLead;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Repository;
using TesteNetCore.Domain.Repository.Configuration;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            RegisterRepositories(services);
            services.AddScoped<DbContext, LeadDbContext>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddSingleton<IObjectConverter, ObjectConverter>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ChangeStatusLeadHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLeadsQueryHandler).Assembly));
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddDbContext<LeadDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool EhAmbienteProducacao()
        {
            return CurrentEnvironment.EnvironmentName == "producao";
        }


    }
}