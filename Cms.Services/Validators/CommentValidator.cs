using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class CommentValidator : AbstractValidator<Comment>
  {
    public CommentValidator()
    {
      RuleFor(x => x.Text).NotNull().WithMessage("Text cannot be empty");
      RuleFor(x => x.Text).MaximumLength(500).WithMessage("Text can be at most 500 character.");

    }
  }
}
