using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
	public class WorkingHour: IEntity
	{
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public User User { get; set; }
        public string AppointmentTime { get; set; }
		public ICollection<Appointment> Appointments { get; set; }
	}
}
