using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Entities.Concrete.Dtos.DoctorDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
  public interface IDoctorService
  {
		Task<IDataResult<DoctorDto>> Get(int doctorId);
		Task<IDataResult<DoctorListDto>> GetAll();
		Task<IDataResult<DoctorListDto>> GetAllByNonDeleted();
		Task<IDataResult<DoctorListDto>> GetAllByNonDeletedAndActive();
		Task<IDataResult<DoctorListDto>> GetAllByCategory(int categoryId);
		Task<IResult> Add(DoctorAddDto doctorAddDto, int createdById);
		Task<IResult> Update(DoctorUpdateDto doctorUpdateDto, int modifiedById);
		Task<IResult> Delete(int doctorId, int modifiedById);
		Task<IResult> HardDelete(int doctorId);
	}
}
