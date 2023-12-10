using _04.ConsultorioClimil.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _01.ConsultorioClimil.WebApi.configuration
{
    public static class DataBaseConfig
    {


        // criar mminha migation
        public static void UseDataConfiguration(this IApplicationBuilder app) {

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConsultorioClimilContext>();



        
        
        
        }





    }
}
