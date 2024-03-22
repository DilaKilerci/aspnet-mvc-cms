using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.CommentDtos
{
	public class CommentListDto:DtoGetBase
	{
        public IList<Comment> Comments { get; set; }
    }
}
