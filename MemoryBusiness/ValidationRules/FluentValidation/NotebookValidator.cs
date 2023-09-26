using FluentValidation;
using Memory.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.ValidationRules.FluentValidation
{
    public class NotebookValidator : AbstractValidator<Notebook>
    {
        public NotebookValidator()
        {
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Title).MaximumLength(50);
            RuleFor(x => x.Content).NotNull();

        }
    }
}
