using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
  public class Article : EntityBase, IEntity
  {
    public string Title { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int DoctorId { get; set; }
    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
  }
}
