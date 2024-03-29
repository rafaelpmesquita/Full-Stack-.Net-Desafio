﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using TesteNetCore.API.Service;
using TesteNetCore.API.Service.Interface;
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Repository;
using TesteNetCore.Domain.Repository.Configuration;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            RegisterRepositories(services);
            services.AddScoped<DbContext, LeadDbContext>();
            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<IObjectConverter, ObjectConverter>();
            services.AddCors();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ChangeStatusLeadHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLeadsQueryHandler).Assembly));
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddDbContext<LeadDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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