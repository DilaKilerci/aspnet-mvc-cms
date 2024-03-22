using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class ArticleValidator : AbstractValidator<Article>
  {
    public ArticleValidator()
    {
      RuleFor(x => x.Title).NotNull().WithMessage("Name cannot be empty");
      RuleFor(x => x.Title).MaximumLength(200).WithMessage("Title can be at most 200 character.");
      RuleFor(x => x.Content).NotNull().WithMessage("Content cannot be empty");
      RuleFor(x => x.Content).MaximumLength(1000).WithMessage("Name can be at most 100 character.");
      RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Please select the related department for your article.");
    }
  }
}
