using _02.ConsultorioClimil.Core.Domain;
using _04.ConsultorioClimil.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsultorioClimil.Data.Context
{
     public class ConsultorioClimilContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Initial catalog=ConsultorioClimilBD;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Cliente> clientes { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration (new ClienteConfiguration());
         




        }









        /*

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);


            //Posso fazer n configuração na minha entidade

            // Dizendo que Id sera minha chave primaria
            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);

            modelBuilder.Entity<Cliente>().ToTable("tb_Clientes");
        
        
        
        
        }
        */



        }



  }

