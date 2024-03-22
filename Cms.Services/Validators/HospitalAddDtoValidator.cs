using Cms.Entities.Concrete.Dtos.HospitalDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class HospitalAddDtoValidator:AbstractValidator<HospitalAddDto>
  {
        public HospitalAddDtoValidator()
        {
      RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be empty");
      RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name can be at most 100 character.");
      RuleFor(x => x.CityId).NotNull().WithMessage("City cannot be empty");
    }
    }
}
