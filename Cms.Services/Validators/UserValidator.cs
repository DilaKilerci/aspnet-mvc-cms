using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be empty");
      RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name can be at most 100 character.");
      RuleFor(x => x.Surname).NotNull().WithMessage("Surname cannot be empty");
      RuleFor(x => x.Surname).MaximumLength(100).WithMessage("Surname can be at most 100 character.");
      RuleFor(x => x.City).NotNull().WithMessage("City cannot be empty");
      RuleFor(x => x.Phone).NotNull().WithMessage("Please enter a phone number.");
      RuleFor(x => x.Phone).Length(10);
      RuleFor(x => x.CitizenId).NotNull().WithMessage("Please enter the citizen ID.");
      RuleFor(x => x.CitizenId).Length(11);
      RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Please enter the date of birth.");
      RuleFor(x => x.Email).NotNull().WithMessage("Email cannot be empty");
      RuleFor(x => x.Email).EmailAddress().WithMessage("Please type an email");
      RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password must be at least 8 character.");
      RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Password must contain uppercase letter.")
                         .Matches("[a-z]").WithMessage("Password must contain lowercase letter.");
      RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Password must contain number.");
      RuleFor(x => x.Password).Matches(@"[!@#$%^&*()_+]").WithMessage("Password must contain special character.");
      RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please select a role.");
    }
  }
}
