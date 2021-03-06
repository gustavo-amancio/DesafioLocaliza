using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IoC;

namespace WebAPI_Validador_Numeros
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            Injetor_Dependencia.RegistrarServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1.1.0",
                        Title = "Documento da WEB API .NET Core REST do Desafio da Localiza",
                        Description = "Documentando API que realiza calculos do dividendo e dos primos existentes na lista de dividendos"
                    }
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                //c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json","API Validador_Numeros");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
