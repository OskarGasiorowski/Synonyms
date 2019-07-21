using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using MediatR;
using Swashbuckle.AspNetCore.Swagger;
using Synonyms.Api.Validators;
using FluentValidation.AspNetCore;

namespace Synonyms.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var assemblies = DependencyContext.Default.RuntimeLibraries
                .Where(library => library.Name.StartsWith("Synonyms"))
                .Select(library => Assembly.Load(new AssemblyName(library.Name)))
                .ToArray();
            
            services
                .AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateSynonymValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .Services
                .AddMediatR(assemblies)
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyModules(assemblies);
            this.ApplicationContainer = builder.Build();
            
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()) //todo cors
                .UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
        }
    }
}