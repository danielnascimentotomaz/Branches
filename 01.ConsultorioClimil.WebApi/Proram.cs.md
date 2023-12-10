using _01.ConsultorioClimil.WebApi.configuration;
using _03.ConsultorioClimil.Manager.Implementations;
using _03.ConsultorioClimil.Manager.Interfaces;
using _03.ConsultorioClimil.Manager.Mappings;
using _03.ConsultorioClimil.Manager.Validation;
using _04.ConsultorioClimil.Data.ClienteRepository;
using _04.ConsultorioClimil.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


/*>>>>>>>>>>>>>> Disponibilizando os servicos >>>>>>>>>>>>>>>*/

// Add services to the container.
// coloquei minha conexcao com banco de dado no projeto 04.ConsultorioClimil.Data obs Quando tava colocando aqui tava dando erro desing na hora de ciar minhas nigration




builder.Services.AddControllers().AddFluentValidation(
     p => {
         p.RegisterValidatorsFromAssemblyContaining<CreateClienteDtoValidation>();
         p.RegisterValidatorsFromAssemblyContaining<UpdateClienteValidation>();

         p.ValidatorOptions.LanguageManager.Culture= new CultureInfo("pt-BR");
    } );





builder.Services.AddEndpointsApiExplorer();



// Disponibilizando a classe ClienteRepository e ConsultorioClimilContext como servico pra eu poder usar inje��o de depend�ncia
builder.Services.AddScoped<ConsultorioClimilContext>(); // Se eu tivesse feito a conec��o do banco de dado nessa classe program.cs, ConsultorioClimilContext ja ta tava disponibilizado como servico

builder.Services.AddScoped<IClienteManager, ClienteManager>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddAutoMapper(typeof(CreateClienteMappingProfile),typeof(UpdateClienteMappingProfilecs));









// CONFIGURAÇÃO DO  swagger()
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consult�rio Climil", Version = "v1" }));



/*>>>>>>>>>>>>>> Aplicando os servicos >>>>>>>>>>>>>>>*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();


    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("./swagger/v1/swagger.json", "Consultorio climil");
    });
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

app.UseAuthorization();

app.MapControllers();

app.Run();
