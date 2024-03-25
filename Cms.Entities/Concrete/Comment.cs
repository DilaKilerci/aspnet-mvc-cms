using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
  public class Comment : EntityBase, IEntity
  {
    public string Text { get; set; }
    public int ArticleId { get; set; }
    public Article Article { get; set; }
    public User User { get; set; }
		public int UserId { get; set; } //doctors can share articles
		public int DoctorId { get; set; } 
	}
}
