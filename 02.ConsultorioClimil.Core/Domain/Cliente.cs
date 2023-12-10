using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConsultorioClimil.Core.Domain
{
    public class Cliente
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }

        public char Sex { get; set; } 

        public string? Telephone { get; set; }

        public string? Document { get; set; }

        public DateTime Creation { get; set; }

        public DateTime LastUpdate { get; set; }

        public Endereco Endereco { get; set; }



       


 







    }
}
