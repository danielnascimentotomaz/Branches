using _03.ConsultorioClimil.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace _01.ConsultorioClimil.WebApi.configuration
{
    public static class AutoMapperConfig
    {

        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {

             services.AddAutoMapper(typeof(CreateClienteMappingProfile), typeof(UpdateClienteMappingProfilecs));




        }
    }
}
