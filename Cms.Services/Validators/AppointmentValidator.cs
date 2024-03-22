using Cms.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Validators
{
  public class AppointmentValidator : AbstractValidator<Appointment>
  {
    public AppointmentValidator()
    {
      RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage("Please select a date");
      RuleFor(x => x.HospitalId).NotEmpty().WithMessage("Please select a hospital.");
      RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Please select a department.");
      RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Please select a doctor.");
    }
  }
}
