using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.CommentDtos
{
	public class CommentAddDto
	{
		public string Text { get; set; }
		public int ArticleId { get; set; }
		public Article Article { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }
	}
}
