using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
  public class Hospital:EntityBase,IEntity
  {
        public string Name { get; set; }
		public City City { get; set; }
		public int CityId { get; set; }
		public ICollection<User> Users { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
  }
}
