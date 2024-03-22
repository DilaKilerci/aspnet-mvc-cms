using Cms.Entities.Concrete.Dtos.UserDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
	public interface IUserService
	{
		Task<IDataResult<UserDto>> Get(int userId);
		Task<IDataResult<UserListDto>> GetAll();
		Task<IDataResult<UserListDto>> GetAllByNonDeleted();
		Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActive();
		//Task<IDataResult<AdminListDto>> GetAllByCategory(int adminID); buna gerek var mı? Sanmıyorum
		Task<IResult> Add(UserAddDto userAddDto, int createdById);
		Task<IResult> Update(UserUpdateDto userUpdateDto, int modifiedById);
		Task<IResult> Delete(int userId, int modifiedById);
		Task<IResult> HardDelete(int userId);
	}
}
