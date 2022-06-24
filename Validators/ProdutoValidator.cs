using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProdutoStoreApi.Models;

namespace ProdutoStoreApi.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatorio")
                .NotNull().WithMessage("Nome não pode ser null");

            RuleFor(p=>p.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatorio")
                .NotNull().WithMessage("Descrição não pode ser null");

            RuleFor(p => p.CategoriaID)
                .GreaterThan(0).WithMessage("É obrigatorio informar uma categoria")
                .NotNull().WithMessage("Categoria não pode ser null");
            
           
        }
    }
}
