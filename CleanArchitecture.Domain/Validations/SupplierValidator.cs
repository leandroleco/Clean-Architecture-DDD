using CleanArchitecture.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Validations
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {

        public SupplierValidator()
        {
            RuleFor(s => s.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(s => s.Cnpj).IsValidCNPJ();                
        }
    }
}
