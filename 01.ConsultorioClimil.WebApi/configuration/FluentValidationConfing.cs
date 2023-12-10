using _03.ConsultorioClimil.Manager.Validation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace _01.ConsultorioClimil.WebApi.configuration
{
    public static  class FluentValidationConfing
    {

        public static void UseFluentValidationConfinguration(this IServiceCollection services)
        { 
         services.AddControllers()


        .AddFluentValidation(p => {

         p.RegisterValidatorsFromAssemblyContaining<CreateClienteDtoValidation>();

         p.RegisterValidatorsFromAssemblyContaining<UpdateClienteValidation>();

       
         p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");

         });



        }




    }
}
