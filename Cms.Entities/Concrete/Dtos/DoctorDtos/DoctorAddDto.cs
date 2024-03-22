using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.DoctorDtos
{
	public class DoctorAddDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public string CitizenId { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Picture { get; set; }
		public int HospitalId { get; set; }
		public Hospital Hospital { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
