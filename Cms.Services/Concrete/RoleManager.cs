using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete.Dtos.HospitalDtos;
using Cms.Entities.Concrete.Dtos.RoleDtos;
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
	public class RoleManager:IRoleService
	{
		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public RoleManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IDataResult<RoleDto>> Get(int roleId)
		{
			var role = await _context.Roles
																	.SingleOrDefaultAsync(x => x.Id == roleId);

			if (role != null)
			{
				return new DataResult<RoleDto>(ResultStatus.Success, new RoleDto
				{
					Role = role,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<RoleDto>(ResultStatus.Error, "No roles found", null);
		}

		public async Task<IDataResult<RoleListDto>> GetAll()
		{
			var roles = await _context.Roles.ToListAsync();
			if (roles.Any())
			{
				return new DataResult<RoleListDto>(ResultStatus.Success, new RoleListDto
				{
					Roles = roles,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<RoleListDto>(ResultStatus.Error, "No roles found", null);
		}
				
		public async Task<IDataResult<RoleListDto>> GetAllByActive()
		{
			var roles = await _context.Roles
																		.Where(a => a.IsActive)
																		.ToListAsync();
			if (roles.Any())
			{
				return new DataResult<RoleListDto>(ResultStatus.Success, new RoleListDto
				{
					Roles = roles,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<RoleListDto>(ResultStatus.Error, "No roles found", null);
		}
	}
}
