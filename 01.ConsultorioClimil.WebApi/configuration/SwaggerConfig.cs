using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace _01.ConsultorioClimil.WebApi.configuration
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Consultorio Climil",
                    Version = "v1",
                    Description = "API da aplicação Consultorio Climil",
                    Contact = new OpenApiContact
                    {
                        Name = "Daniel Nascimento Tomaz",
                        Email = "danielsabio1000@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/daniel-nascimento-tomaz/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });





                c.AddFluentValidationRulesScoped();
              

                

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);




            });

        }


        public static void UseSwaggerConfiration(this IApplicationBuilder app)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Consultorio climil");



            });
           
           
          
           
        }









    }
}
