using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.AppointmentDtos
{
	public class AppointmentAddDto
	{
		public DateTime AppointmentDate { get; set; }
		public int AppointmentId { get; set; }
		public Appointment Appointment { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int HospitalId { get; set; }
		public Hospital Hospital { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }
		public int WorkingHourId { get; set; }
		public WorkingHour WorkingHour { get; set; }
	}
}
