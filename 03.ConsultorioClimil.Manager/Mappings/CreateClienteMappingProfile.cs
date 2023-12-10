using _02.ConsultorioClimil.Core.Domain;
using AutoMapper;
using ConsultorioClimil.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsultorioClimil.Manager.Mappings
{
    public class CreateClienteMappingProfile : Profile
    {



        public CreateClienteMappingProfile() {


            //                 Origem -> Destino
            CreateMap<CreateClienteDto, Cliente>()
           // Usando ForMember pra adicionar um valor no atributo Creation
           .ForMember(d => d.Creation, o => o.MapFrom(x => DateTime.Now)).

           // Usando ForMember para pega apena ano mes dia   do Atributo BirthDate
           ForMember(d => d.BirthDate, o => o.MapFrom(x => x.BirthDate.Date));


        
        
        }
    }
}
