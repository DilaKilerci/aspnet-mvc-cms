using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			RuleFor(x=>x.PasswordHash).NotEmpty().WithMessage("Password cannot be empty.")
																.Must(password => password.Length >= 8).WithMessage("Password must contains at least 8 character.")
																.Must(ContainUppercase).WithMessage("Password must contain at least one uppercase letter.")
																.Must(ContainLowercase).WithMessage("Password must contain at least one lowercase letter.")
																.Must(ContainDigit).WithMessage("Password must contain number")
																.Must(ContainSpecialCharacter).WithMessage("Password must contain one special character.");
			RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please select a role.");
    }

		private bool ContainUppercase(byte[] password)
		{
			string strPassword = System.Text.Encoding.UTF8.GetString(password);
			return Regex.IsMatch(strPassword, @"[A-Z]");
		}

		private bool ContainLowercase(byte[] password)
		{
			string strPassword = System.Text.Encoding.UTF8.GetString(password);
			return Regex.IsMatch(strPassword, @"[a-z]");
		}

		private bool ContainDigit(byte[] password)
		{
			string strPassword = System.Text.Encoding.UTF8.GetString(password);
			return Regex.IsMatch(strPassword, @"\d");
		}

		private bool ContainSpecialCharacter(byte[] password)
		{
			string strPassword = System.Text.Encoding.UTF8.GetString(password);
			return Regex.IsMatch(strPassword, @"[^a-zA-Z0-9]");
		}

	}
}
