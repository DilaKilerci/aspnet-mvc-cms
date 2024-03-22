using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete.Dtos.DoctorDtos;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.UserDtos;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cms.Services.Concrete
{
	public class UserManager : IUserService
	{
		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public UserManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<IResult> Add(UserAddDto userAddDto, int createdById)
		{
			var user = _mapper.Map<User>(userAddDto);
			user.CreatedById = createdById;
			user.ModifiedById = createdById;
			user.RoleId = 3;
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, "User saved successfully.");
		}

		public async Task<IResult> Delete(int userId, int modifiedById)
		{
			var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
			if (user != null)
			{
				user.IsDeleted = true;
				user.ModifiedById = modifiedById;
				user.ModifiedDate = DateTime.Now;
				await _context.SaveChangesAsync();
				return new Result(ResultStatus.Success, "User deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No user found.");
		}

		public async Task<IDataResult<UserDto>> Get(int userId)
		{
			var user = await _context.Users
																	.SingleOrDefaultAsync(u => u.Id == userId);

			if (user != null)
			{
				return new DataResult<UserDto>(ResultStatus.Success, new UserDto
				{
					User = user,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<UserDto>(ResultStatus.Error, "No user found", null);
		}

		public async Task<IDataResult<UserListDto>> GetAll()
		{
			var users = await _context.Users.ToListAsync();
			if (users.Any())
			{
				return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
				{
					Users = users,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<UserListDto>(ResultStatus.Error, "No users found", null);
		}

		public async Task<IDataResult<UserListDto>> GetAllByNonDeleted()
		{
			var users = await _context.Users
																		.Where(d => !d.IsDeleted)
																		.ToListAsync();

			if (users.Any())
			{
				return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
				{
					Users = users,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<UserListDto>(ResultStatus.Error, "No users found", null);
		}

		public async Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActive()
		{
			var users = await _context.Users
																		.Where(d => !d.IsDeleted && d.IsActive)
																		.ToListAsync();
			if (users.Any())
			{
				return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
				{
					Users = users,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<UserListDto>(ResultStatus.Error, "No users found", null);
		}

		public async Task<IResult> HardDelete(int userId)
		{
			var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (result != null)
			{
				var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

				_context.Users.Remove(user);
				return new Result(ResultStatus.Success, $"{user.Name} {user.Surname}  deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No user found.");
		}

		public async Task<IResult> Update(UserUpdateDto userUpdateDto, int modifiedById)
		{
			var user = _mapper.Map<User>(userUpdateDto);
			user.ModifiedById = modifiedById;
			_context.Users.Update(user);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, $"{user.Name} {user.Surname}  updated successfully.");
		}
	}
}
