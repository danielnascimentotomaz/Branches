using _02.ConsultorioClimil.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsultorioClimil.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();

        Task<Cliente> GetIdClienteAsync(int id);

        Task<Cliente> CreateClienteAsync(Cliente cliente);


        Task<Cliente> UpdateClienteAsync(int id, Cliente cliente);

        Task<Cliente> DeleteClienteAsync(int id);








    }
}
