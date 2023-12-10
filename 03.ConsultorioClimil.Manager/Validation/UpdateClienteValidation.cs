using ConsultorioClimil.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03.ConsultorioClimil.Manager.Validation
{
    public class UpdateClienteValidation :AbstractValidator<UpdateClienteDto>
    {

        public UpdateClienteValidation() {

            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new CreateClienteDtoValidation());  // pra puder usar as validações da classe CreateClienteDtoValidation(






        }
    }
}
