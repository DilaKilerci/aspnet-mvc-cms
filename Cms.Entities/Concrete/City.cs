using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
	public class City : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Doctor> Doctors { get; set; }
		public ICollection<Hospital> Hospitals { get; set; }
		public ICollection<User> Users { get; set; }
	}
}
