using Cms.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{

  public class Category:EntityBase,IEntity
  {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection <User> Users { get; set; }
        public ICollection <Article> Articles { get; set; }
        public ICollection <Appointment> Appointments { get; set; }

    
  }
}
