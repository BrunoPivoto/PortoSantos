using FluentValidation;
using Porto.Domain.Entities;

namespace Porto.Domain.Validators{
    public class ContainerValidator : AbstractValidator<Container>{
        public ContainerValidator(){
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não pode ser vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
            
            RuleFor(x => x.ClientContainer)
                .NotEmpty().WithMessage("O cliente não pode ser vazio")
                .NotNull().WithMessage("O cliente não pode ser nulo");
            
            RuleFor(x => x.NumContainer)
                .NotEmpty().WithMessage("O número não pode ser vazio")
                .NotNull().WithMessage("O número não pode ser nulo")
                .Matches(@"([A-Z]{4})([0-9]{7})").WithMessage("Formato inválido, deve possuir 4 letras e 7 números");

            RuleFor(x => x.TypeContainer)
                .NotEmpty().WithMessage("O tipo não pode ser vazio")
                .NotNull().WithMessage("O tipo não pode ser nulo");
            
            RuleFor(x => x.StatusContainer)
                .NotEmpty().WithMessage("O status não pode ser vazio")
                .NotNull().WithMessage("O status não pode ser nulo");
            
            RuleFor(x => x.CategoryContainer)
                .NotEmpty().WithMessage("A categoria não pode ser vazia")
                .NotNull().WithMessage("A categoria não pode ser nula");    
        }
    }
}