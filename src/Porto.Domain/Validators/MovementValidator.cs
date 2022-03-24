using FluentValidation;
using Porto.Domain.Entities;

namespace Porto.Domain.Validators{
    public class MovementValidator : AbstractValidator<Movement>{
        public MovementValidator(){
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não pode ser vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
            
            RuleFor(x => x.TypeMovement)
                .NotEmpty().WithMessage("O tipo de movimentação não pode ser vazio")
                .NotNull().WithMessage("O tipo de movimentação não pode ser nulo");
            
            RuleFor(x => x.DateInitial)
                .NotEmpty().WithMessage("A data incial não pode ser vazia")
                .NotNull().WithMessage("A data incial não pode ser nula")
                .Matches(@"(\d{2})[-.\/](\d{2})[-.\/](\d{4})").WithMessage("Formato inválido, deve ser xx/xx/xxxx");

            RuleFor(x => x.HourInitial)
                .NotEmpty().WithMessage("A hora incial não pode ser vazia")
                .NotNull().WithMessage("A hora incial não pode ser nula")
                .Matches(@"(\d{2})[-.\:](\d{2})").WithMessage("Formato inválido, deve xx:xx");
            
            RuleFor(x => x.DateFinish)
                .NotEmpty().WithMessage("A data final não pode ser vazia")
                .NotNull().WithMessage("A data final não pode ser nula")
                .Matches(@"(\d{2})[-.\/](\d{2})[-.\/](\d{4})").WithMessage("Formato inválido, deve ser xx/xx/xxxx");
            
            RuleFor(x => x.HourFinish)
                .NotEmpty().WithMessage("A hora final não pode ser vazia")
                .NotNull().WithMessage("A hora final não pode ser nula")
                .Matches(@"(\d{2})[-.\:](\d{2})").WithMessage("Formato inválido, deve xx:xx");    
        }
    }
}