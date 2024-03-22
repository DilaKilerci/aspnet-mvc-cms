using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
  public class Role:EntityBase,IEntity
  {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
