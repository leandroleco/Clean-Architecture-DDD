using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        { 
            RuleFor(i => i.Description)
                .NotNull()  
                .NotEmpty()
                .WithMessage("Descrição é obrigatória");

            RuleFor(i => i.ManufacturedDate)
                .LessThan(i => i.ValidityDate)
                .WithMessage("Data de Fabricação deve ser menor que a data de Validade");
        }
    }
}
