using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class RoleValidator : AbstractValidator<Role>
  {
        public RoleValidator()
        {
      RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be empty");
      RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name can be at most 100 character.");
      RuleFor(x => x.Description).NotNull().WithMessage("Description cannot be empty");
      RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description can be at most 200 character.");
    }
    }
}
