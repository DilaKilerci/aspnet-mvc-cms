using AutoMapper;
using Cms.Data.Abstract;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.AdminDtos;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class AdminManager : IAdminService
	{
		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public AdminManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IResult> Add(AdminAddDto adminAddDto, int createdById)
		{
			var admin = _mapper.Map<Admin>(adminAddDto);

			admin.CreatedById = createdById;
			admin.ModifiedById = createdById;
			admin.RoleId = 1;
			await _context.Admins.AddAsync(admin);
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, $"{adminAddDto.Name} added as a Admin successfully.");

		}

		public async Task<IResult> Delete(int adminId, int modifiedById)
		{
			var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminId);

			if (admin != null)
			{
				admin.IsDeleted = true;
				admin.ModifiedById = modifiedById;
				admin.ModifiedDate = DateTime.Now;
				_context.Admins.Update(admin);
				return new Result(ResultStatus.Success, $"{admin.Name} deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No admin found.");
		}

		public async Task<IDataResult<AdminDto>> Get(AdminDto adminDto)
		{
			var admin = await _context.Admins
																	.SingleOrDefaultAsync(x => x.Id == adminDto.Id);

			if (admin != null)
			{
				return new DataResult<AdminDto>(ResultStatus.Success, adminDto);
			}
			return new DataResult<AdminDto>(ResultStatus.Error, "No admin found", null);
		}

		public async Task<IDataResult<AdminLoginDto>> GetAdminForLogin(AdminLoginDto adminDto)
		{
			var admin = await _context.Admins
																	.SingleOrDefaultAsync(x => x.Email==adminDto.Email && x.Password==adminDto.Password);

			if (admin != null)
			{
				return new DataResult<AdminLoginDto>(ResultStatus.Success, new AdminLoginDto{
					Id=adminDto.Id,
					Email=adminDto.Email,
					Password=adminDto.Password,
					RoleId=adminDto.RoleId,
				});
			}
			return new DataResult<AdminLoginDto>(ResultStatus.Error, "No admin found", null);
		}

		public async Task<IDataResult<AdminListDto>> GetAll()
		{
			var admins = await _context.Admins.ToListAsync();
			if (admins.Any())
			{
				return new DataResult<AdminListDto>(ResultStatus.Success, new AdminListDto
				{
					Admins = admins,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AdminListDto>(ResultStatus.Error, "No admins found", null);
		}

		public async Task<IDataResult<AdminListDto>> GetAllByNonDeleted()
		{
			var admins = await _context.Admins
																		.Where(a => !a.IsDeleted)
																		.ToListAsync();

			if (admins.Any())
			{
				return new DataResult<AdminListDto>(ResultStatus.Success, new AdminListDto
				{
					Admins = admins,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AdminListDto>(ResultStatus.Error, "No admins found", null);
		}

		public async Task<IDataResult<AdminListDto>> GetAllByNonDeletedAndActive()
		{
			var admins = await _context.Admins
																		.Where(a => !a.IsDeleted && a.IsActive)
																		.ToListAsync();
			if (admins.Any())
			{
				return new DataResult<AdminListDto>(ResultStatus.Success, new AdminListDto
				{
					Admins = admins,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AdminListDto>(ResultStatus.Error, "No admins found", null);
		}

		public async Task<IResult> HardDelete(int adminId)
		{
			var result = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminId);
			if (result != null)
			{
				var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminId);

				_context.Admins.Remove(admin);
				return new Result(ResultStatus.Success, $"{admin.Name} named admin deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No admin found.");
		}

		public async Task<IResult> Update(AdminUpdateDto adminUpdateDto, int modifiedById)
		{
			var admin = _mapper.Map<Admin>(adminUpdateDto);
			admin.ModifiedById = modifiedById;
			_context.Admins.Update(admin);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, "Admin updated successfully.");
		}
	}
}
