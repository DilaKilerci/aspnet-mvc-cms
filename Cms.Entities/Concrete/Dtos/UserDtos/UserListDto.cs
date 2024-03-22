using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.UserDtos
{
	public class UserListDto : DtoGetBase
	{
		public IList<User> Users { get; set; }
	}
}
