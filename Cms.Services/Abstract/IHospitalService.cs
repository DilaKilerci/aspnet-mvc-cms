using Cms.Entities.Concrete.Dtos.DoctorDtos;
using Cms.Entities.Concrete.Dtos.HospitalDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
  public interface IHospitalService
  {
		Task<IDataResult<HospitalDto>> Get(int hospitalId);
		Task<IDataResult<HospitalListDto>> GetAll();
		Task<IDataResult<HospitalListDto>> GetAllByNonDeleted();
		Task<IDataResult<HospitalListDto>> GetAllByNonDeletedAndActive();
		Task<IDataResult<HospitalListDto>> GetAllByCity(int cityId);
		Task<IResult> Add(HospitalAddDto hospitalAddDto, int createdById);
		Task<IResult> Update(HospitalUpdateDto hospitalUpdateDto, int modifiedById);
		Task<IResult> Delete(int hospitalId, int modifiedById);
		Task<IResult> HardDelete(int hospitalId);
	}
}
