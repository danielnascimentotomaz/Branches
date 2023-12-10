using ConsultorioClimil.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsultorioClimil.Manager.Validation
{
  
    public class CreateClienteDtoValidation : AbstractValidator<CreateClienteDto>
    {

        public CreateClienteDtoValidation() {


           
                //propriedade "Name", exigindo que não seja nula, não esteja vazia, tenha comprimento mínimo de 10 caracteres e comprimento máximo de 100 caracteres.
                RuleFor(x => x.Name).NotNull().NotEmpty();

                //propriedade "BirthDate", exigindo que não seja nula, não esteja vazia, data esteja no passado e a pessoa ter menos 130 anos.
                RuleFor(x => x.BirthDate)
                 .NotNull().WithMessage("A data de nascimento é obrigatória.")
                 .NotEmpty().WithMessage("A data de nascimento não pode estar vazia.");


                RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);

                // propriedade "Telephone" para garantir que não seja nula, não esteja vazia e siga o padrão exprecões regulares o primeiro número seja 2 a 9  e o restante do 10 número seja 0 a 9, fornecendo uma mensagem de erro personalizada se a validação falhar.

                RuleFor(x => x.Telephone).NotNull().NotEmpty();
                //Matches("[2,9][0,9]{10}").WithMessage("O telefone tem que ter o formato [2,9][0,9]{10}")

                // propriedade "Sex" para garantir que não seja nula, não esteja vazia e satisfaça uma condição adicional definida pelo método EhMF.
                RuleFor(x => x.Sex).NotNull().NotEmpty().Must(EhMF).WithMessage("O sexo precisa ser M Ou F");
                //RuleFor(x => x.Endereco).SetValidator(new CreateEnderecoDtoValidation());




        }






            private bool EhMF(char arg)
            {

                //Verificando se sexo é masculino ou feminino
                return arg == 'F' || arg == 'M';
            }




        }
    }

