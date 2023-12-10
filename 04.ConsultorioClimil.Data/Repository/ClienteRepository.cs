using _02.ConsultorioClimil.Core.Domain;
using _03.ConsultorioClimil.Manager.Interfaces;
using _04.ConsultorioClimil.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsultorioClimil.Data.ClienteRepository
{
    public class ClienteRepository: IClienteRepository
    {

        private readonly ConsultorioClimilContext context;

     public ClienteRepository(ConsultorioClimilContext consultorioClimilContext) { 

            this.context = consultorioClimilContext;
     }




        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {

            return await context.clientes.
                
                AsNoTracking().ToListAsync();

        }

        public async Task<Cliente> GetIdClienteAsync(int id)
        {
           // var ClienteBancodado = await context.clientes.FindAsync(id);// Find ante de ir base de dado verificar pilha Trackind ja existe esse objeto em memoria


            var ClienteBancodado = await context.clientes.
               
                SingleOrDefaultAsync(p => p.Id == id);
           
            if (ClienteBancodado == null)
            {

                throw new Exception("Cliente nao encontrado");

            }



            return ClienteBancodado;
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente){




           await context.clientes.AddAsync(cliente);
           await context.SaveChangesAsync();
           return cliente;
        
        }

        public async Task<Cliente> UpdateClienteAsync(int id , Cliente cliente)
        {
            var ClienteBancodado = await context.clientes.FindAsync(id);

            if(ClienteBancodado == null)
            {

                throw new Exception("Cliente nao encontrado");

            }

            // Vai atualizar os valores
            context.Entry(ClienteBancodado).CurrentValues.SetValues(cliente);

            await context.SaveChangesAsync();

            return cliente;

            


        }

        public async Task<Cliente> DeleteClienteAsync(int id)
        {

            var ClienteBancoDado = await context.clientes.FindAsync(id);

            if(ClienteBancoDado == null) {

                throw new Exception($"Cliente com ID {id} não encontrado");
          
            }

            context.Remove(ClienteBancoDado);

            await context.SaveChangesAsync();

            return ClienteBancoDado;

           



        }
    }
}
