using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
  public class Doctor : EntityBase, IEntity
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
    public string Picture { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<WorkingHour> WorkingHours { get; set; }
    public ICollection<Article> Articles { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
  }
}
