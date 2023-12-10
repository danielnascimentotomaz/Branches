using _01.ConsultorioClimil.WebApi.configuration;
using _03.ConsultorioClimil.Manager.Implementations;
using _03.ConsultorioClimil.Manager.Interfaces;
using _03.ConsultorioClimil.Manager.Mappings;
using _03.ConsultorioClimil.Manager.Validation;
using _04.ConsultorioClimil.Data.ClienteRepository;
using _04.ConsultorioClimil.Data.Context;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


/*>>>>>>>>>>>>>> Disponibilizando os servicos >>>>>>>>>>>>>>>*/




// Add services to the container.
// coloquei minha conexcao com banco de dado no projeto 04.ConsultorioClimil.Data obs Quando tava colocando aqui tava dando erro desing na hora de ciar minhas nigration


// Injeção dependencia









builder.Services.AddControllers();

builder.Services.UseFluentValidationConfinguration();


builder.Services.AddEndpointsApiExplorer();

builder.Services.UseDependencyInjectionConfiguration();

builder.Services.UseAutoMapperConfiguration();

builder.Services.AddSwaggerConfiguration();
//////////////////////////////////////////////////////////////////////////////////////

var builde = WebApplication.CreateBuilder(args);

// Configurar o Serilog
Log.Logger = new LoggerConfiguration().Enrich.
    FromLogContext().WriteTo.Async(p => p.Console()).WriteTo.Async(p => p.File("Log.txt", fileSizeLimitBytes: 100000, rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day))
    
    .CreateLogger();

    
   
   

Log.Information("=========================Iniciando log=====================================");

builder.Host.UseSerilog(); // Adicione isso para que o Serilog seja usado pelo host




/*>>>>>>>>>>>>>> Aplicando os servicos >>>>>>>>>>>>>>>*/

// Configure the HTTP request pipeline.


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSerilogRequestLogging(); // Adicione middleware para registrar detalhes das solicitações HTTP
}






if (app.Environment.IsDevelopment()) 

{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerConfiration();
   

}





//Em resumo, essas duas linhas de codigo configuram como as URLs s�o interpretadas e direcionadas para o c�digo correspondente no ASP.NET Core.
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" );
});







app.UseHttpsRedirection();

app.UseDataConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
