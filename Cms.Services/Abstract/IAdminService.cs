using Cms.Entities.Concrete.Dtos.AdminDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAdminService
  {
		Task<IDataResult<AdminDto>> Get(AdminDto aDto);
		
		Task<IDataResult<AdminListDto>> GetAll();
		Task<IDataResult<AdminLoginDto>> GetAdminForLogin(AdminLoginDto adminDto);
		Task<IDataResult<AdminListDto>> GetAllByNonDeleted();
		Task<IDataResult<AdminListDto>> GetAllByNonDeletedAndActive();
		//Task<IDataResult<AdminListDto>> GetAllByCategory(int adminID); buna gerek var mı? Sanmıyorum
		Task<IResult> Add(AdminAddDto adminAddDto, int createdById);
		Task<IResult> Update(AdminUpdateDto adminUpdateDto, int modifiedById);
		Task<IResult> Delete(int adminId, int modifiedById);
		Task<IResult> HardDelete(int adminId);
	}
}
