using Cms.Entities.Concrete.Dtos.AppointmentDtos;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
  public interface IAppointmentService
  {
		Task<IDataResult<AppointmentDto>> Get(int appointmentId);
		Task<IDataResult<AppointmentListDto>> GetAll();
		Task<IDataResult<AppointmentListDto>> GetAllByNonDeleted();
		Task<IDataResult<AppointmentListDto>> GetAllByNonDeletedAndActive();
		Task<IDataResult<AppointmentListDto>> GetAllByDoctor(int doctorId);
		Task<IResult> Add(AppointmentAddDto appointmentAddDto, int createdById);
		Task<IResult> Update(AppointmentUpdateDto appointmentUpdateDto, int modifiedById);
		Task<IResult> Delete(int appointmentId, int modifiedById);
		Task<IResult> HardDelete(int appointmentId);
	}
}
