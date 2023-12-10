using _03.ConsultorioClimil.Manager.Implementations;
using _03.ConsultorioClimil.Manager.Interfaces;
using _03.ConsultorioClimil.Manager.Mappings;
using _04.ConsultorioClimil.Data.ClienteRepository;
using _04.ConsultorioClimil.Data.Context;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace _01.ConsultorioClimil.WebApi.configuration
{
    public static class DependencyInjectionConfig
    {


        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ConsultorioClimilContext>(); // Se eu tivesse feito a conec��o do banco de dado nessa classe program.cs, ConsultorioClimilContext ja ta tava disponibilizado como servico

            services.AddScoped<IClienteManager, ClienteManager>();

            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));

          


        }



    }
}
