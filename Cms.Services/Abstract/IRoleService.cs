
using Cms.Entities.Concrete.Dtos.RoleDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
  public interface IRoleService
  {
		Task<IDataResult<RoleDto>> Get(int roleId);
		Task<IDataResult<RoleListDto>> GetAll();
		Task<IDataResult<RoleListDto>> GetAllByActive();
		
	}
}
