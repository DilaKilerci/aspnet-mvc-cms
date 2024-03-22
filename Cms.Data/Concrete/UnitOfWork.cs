using Cms.Data.Abstract;
using Cms.Data.Concrete.EntityFramework;
using Cms.Data.Concrete.EntityFramework.Repositories;
using Cms.Data.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Concrete
{
  public class UnitOfWork : IUnitOfWork
  {
  private readonly CmsContext _context;
    private readonly EfAdminRepository _adminRepository;
    private readonly EfAppointmentRepository _appointmentRepository;
    private readonly EfArticleRepository _articleRepository;
    private readonly EfCategoryRepository _categoryRepository;
    private readonly EfCommentRepository _commentRepository;
    private readonly EfDoctorRepository _doctorRepository;
    private readonly EfHospitalRepository _hospitalRepository;
    private readonly EfRoleRepository _roleRepository;
    private readonly EfUserRepository _userRepository;

    public UnitOfWork(CmsContext context)
    {
      _context = context;
    }

    

    public IAdminRepository Admins => _adminRepository ?? new EfAdminRepository(_context);

    public IAppointmentRepository Appointments => _appointmentRepository ?? new EfAppointmentRepository(_context);

    public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);

    public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

    public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

    public IDoctorRepository Doctors => _doctorRepository ?? new EfDoctorRepository(_context);

    public IHospitalRepository Hospitals => _hospitalRepository ?? new EfHospitalRepository(_context);

    public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

    public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

    public async ValueTask DisposeAsync()
    {
      await _context.DisposeAsync();
    }

    public async Task<int> SaveAsync()
    {
      return await _context.SaveChangesAsync();
    }
  }
}
