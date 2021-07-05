using Microsoft.Extensions.DependencyInjection;
using System;
using TemplateApplication.Interface;
using TemplateApplication.Services;

namespace IoC
{
    public static class Injetor_Dependencia
    {
        public static void RegistrarServices(IServiceCollection services)
        {
            services.AddScoped<IUserValidadorService, UserValidadorService>();
        }
    }
}
