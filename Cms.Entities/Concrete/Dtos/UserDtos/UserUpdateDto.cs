using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.UserDtos
{
	public class UserUpdateDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public City City { get; set; }
		public int CityId { get; set; }
		public string Phone { get; set; }
		public string CitizenId { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
