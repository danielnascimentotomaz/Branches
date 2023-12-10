using _02.ConsultorioClimil.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioClimil.Core.Shared.ModelViews
{

    
    public class CreateClienteDto
    {
        
        public string Name { get; set; }

       

        public DateTime BirthDate { get; set; }

       

        public char Sex { get; set; }

        public string? Telephone { get; set; }

        public string? Document { get; set; }
   


       


    }
}
