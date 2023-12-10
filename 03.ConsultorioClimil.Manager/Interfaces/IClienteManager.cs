using _02.ConsultorioClimil.Core.Domain;
using ConsultorioClimil.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsultorioClimil.Manager.Interfaces
{
    public interface IClienteManager
    {

        Task<IEnumerable<Cliente>> GetAllClientesAsync();

        Task<Cliente> GetIdClienteAsync(int id);

        Task<Cliente> CreateClienteAsync(CreateClienteDto createClienteDto);

        Task<Cliente> UpdateClienteAsync(int id, UpdateClienteDto updateClienteDto);


        Task<Cliente> DeleteClienteAsync(int id);


    }
}
