using _02.ConsultorioClimil.Core.Domain;
using _03.ConsultorioClimil.Manager.Interfaces;
using AutoMapper;
using ConsultorioClimil.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsultorioClimil.Manager.Implementations
{
    public class ClienteManager : IClienteManager
    {

        // Injeção de dependência
        private readonly IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;
        public ClienteManager(IClienteRepository clienteRepository,IMapper mapper) {
            this._clienteRepository = clienteRepository;
            this._mapper = mapper;
        
        
        }



        // Método

        public async Task<Cliente> CreateClienteAsync(CreateClienteDto createClienteDto)
        {

            //                      Destino  -> Origem

            var cliente = _mapper.Map<Cliente>(createClienteDto);


           return await _clienteRepository.CreateClienteAsync(cliente);
            

        }

       

        public async  Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllClientesAsync();
        }

        public async Task<Cliente> GetIdClienteAsync(int id)
        {
            return await _clienteRepository.GetIdClienteAsync(id);
        }



        public async  Task<Cliente> UpdateClienteAsync(int id,UpdateClienteDto updateClienteDto )
        {

            //                        Destino  -> Origem
            var cliente = _mapper.Map<Cliente>(updateClienteDto);

            return await _clienteRepository.UpdateClienteAsync(id, cliente);    
        }

        public async Task<Cliente> DeleteClienteAsync(int id)
        {
           return await _clienteRepository.DeleteClienteAsync(id);

        }



    }
}
