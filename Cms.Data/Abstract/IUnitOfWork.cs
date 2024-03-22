using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Abstract
{
  public interface IUnitOfWork:IAsyncDisposable
  {
  IAdminRepository Admins { get; }
  IAppointmentRepository Appointments { get; }
  IArticleRepository Articles { get; }
  ICategoryRepository Categories { get; } //_unitOfWork.Categories.AddAsync()
  ICommentRepository Comments { get; }
  IDoctorRepository Doctors { get; }
  IHospitalRepository Hospitals { get; }
  IRoleRepository Roles { get; }
  IUserRepository Users { get; }

    Task<int> SaveAsync();
  }
}
