using _02.ConsultorioClimil.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsultorioClimil.Data.Configuration
{

    //Declaração de uma classe chamada ClienteConfiguration que implementa a interface
    //IEntityTypeConfiguration para a entidade Cliente.
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {

        //Implementação do método Configure da interface, que recebe um objeto EntityTypeBuilder
        //para configurar propriedades e relacionamentos da entidade Cliente.
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            //Define a propriedade Id como a chave primária da entidade.
            builder.HasKey(p => p.Id);

            //Especifica o nome da tabela no banco de dados como "Tb_Clientes".
            builder.ToTable("Tb_Clientes");

            //Configura a propriedade Name como obrigatória e com no máximo 200 caracteres.
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);

            //Configura a propriedade Sex como obrigatória, com valor padrão "M" (masculino).
            builder.Property(p => p.Sex).IsRequired().HasDefaultValue("M");

            //Renomeia a coluna no banco de dados para "CPF" para a propriedade Document.
            builder.Property(p => p.Document).HasColumnName("CPF");


            //Adiciona um índice para a propriedade Name, o que pode melhorar a eficiência em consultas que usam essa coluna.
            builder.HasIndex(p => p.Name);

            


        }
    }
}
