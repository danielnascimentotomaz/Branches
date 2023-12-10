using _02.ConsultorioClimil.Core.Domain;
using _03.ConsultorioClimil.Manager.Interfaces;
using _03.ConsultorioClimil.Manager.Validation;
using _04.ConsultorioClimil.Data.ClienteRepository;
using _04.ConsultorioClimil.Data.Context;
using ConsultorioClimil.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _01.ConsultorioClimil.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ConsultorioClimilController : ControllerBase
    {
     
        private readonly IClienteManager clienteManager;

        private readonly ILogger _logger;


        public ConsultorioClimilController(IClienteManager clienteManager,ILogger<ConsultorioClimilController> logger) {

            this.clienteManager = clienteManager;
            this._logger = logger;


        }



        //Descição do método

        /// <summary>
        /// Retorna todos clientes cadastrados na base.......
        /// </summary>


        // retorno swagger
        [ProducesResponseType(typeof(List<Cliente>), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        
        [HttpGet]
        public async Task<IActionResult> GetAllClienteAsync()
        {
            _logger.LogInformation("Buscando todos os clintes");

            return Ok(await clienteManager.GetAllClientesAsync());


        }


        /// <summary>
        /// Retorna um cliente consultado pelo id.
        /// </summary>
        /// <param name="id" example="1">Id do cliente.</param>
        /// 

        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteAsync(int id)
        {

            return Ok(await clienteManager.GetIdClienteAsync(id));

        }



        /// <summary>
        /// Insere um novo cliente
        /// </summary>
        /// <param name="createClienteDto"></param>
        /// 
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpPost]
        public async Task<IActionResult> createClienteAsync([FromBody] CreateClienteDto createClienteDto)
        {


            /*   // Assim funciona Nossa Validações Mais vamos Adicionar  Program.cs builder.Services.AddControllers() vamos adicinar nossa Validação
            ClienteValidation Validation = new ClienteValidation();

            var validation = Validation.Validate(createClienteDto);

            if(validation.IsValid)
            {
                var ClienteInserido = await clienteManager.CreateClienteAsync(cliente);

                return CreatedAtAction(nameof(GetClienteAsync), new { id = cliente.Id }, cliente);

            }
            else
            {

                return BadRequest(validation.ToString());
            }*/


            var ClienteInserido = await clienteManager.CreateClienteAsync(createClienteDto);

            return CreatedAtAction(nameof(GetClienteAsync), new { id =ClienteInserido }, ClienteInserido);



        }

        /// <summary>
        /// Altera um cliente.
        /// </summary>
        /// <param name="alteraCliente"></param>
      
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClienteAsync(int id, [FromBody] UpdateClienteDto updateClienteDto)
        {

            return Ok(await clienteManager.UpdateClienteAsync(id, updateClienteDto));


        }


        /// <summary>
        /// Exclui um cliente.
        /// </summary>
        /// <param name="id" example="1">Id do cliente</param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base.</remarks>
        /// 
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteAaysnc(int id)
        {
            var cliente = await  clienteManager.DeleteClienteAsync(id);

            return Ok(cliente);





        }

      







    }




    }

