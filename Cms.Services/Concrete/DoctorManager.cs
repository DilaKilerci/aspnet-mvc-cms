using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Entities.Concrete.Dtos.DoctorDtos;
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
	public class DoctorManager : IDoctorService
	{

		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public DoctorManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<IResult> Add(DoctorAddDto doctorAddDto, int createdById)
		{
			var doctor = _mapper.Map<Doctor>(doctorAddDto);
			doctor.CreatedById = createdById;
			doctor.ModifiedById = createdById;
			doctor.RoleId = 2;
			await _context.Doctors.AddAsync(doctor);
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, "Doctor saved successfully.");

		}

		public async Task<IResult> Delete(int doctorId, int modifiedById)
		{
			var doctor = await _context.Doctors.FirstOrDefaultAsync(a=>a.Id==doctorId);
			if (doctor != null)
			{
				doctor.IsDeleted = true;
				doctor.ModifiedById= modifiedById;
				doctor.ModifiedDate= DateTime.Now;
				await _context.SaveChangesAsync();
				return new Result(ResultStatus.Success, "Doctor deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No doctor found.");
		}

		public async Task<IDataResult<DoctorDto>> Get(int doctorId)
		{
			var doctor = await _context.Doctors
																	.Include(d => d.Category)
																	.Include(d => d.Hospital)
																	.SingleOrDefaultAsync(d => d.Id == doctorId);

			if (doctor != null)
			{
				return new DataResult<DoctorDto>(ResultStatus.Success, new DoctorDto
				{
					Doctor = doctor,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<DoctorDto>(ResultStatus.Error, "No doctor found", null);
		}

		public async Task<IDataResult<DoctorListDto>> GetAll()
		{
			var doctors = await _context.Doctors
																	.Include(d => d.Category)
																	.Include(d => d.Hospital).ToListAsync();
			if (doctors.Any())
			{
				return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
				{
					Doctors = doctors,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found", null);
		}

		public async Task<IDataResult<DoctorListDto>> GetAllByCategory(int categoryId)
		{
			var result = await _context.Categories.AnyAsync(c => c.Id == categoryId);

			if (result)
			{
				var doctors = await _context.Doctors
																			.Include(a => a.Category)
																			.Include(a => a.Hospital)
																			.Where(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive)
																			.ToListAsync();
				if (doctors.Any())
				{
					return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
					{
						Doctors = doctors,
						ResultStatus = ResultStatus.Success,
					});
				}
				return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found", null);
			}
			return new DataResult<DoctorListDto>(ResultStatus.Error, "No categories found", null);
		}

		public async Task<IDataResult<DoctorListDto>> GetAllByNonDeleted()
		{
			var doctors = await _context.Doctors
																		.Include(d => d.Category)
																		.Include(d => d.Hospital)
																		.Where(d => !d.IsDeleted)
																		.ToListAsync();

			if (doctors.Any())
			{
				return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
				{
					Doctors = doctors,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found", null);
		}

		public async Task<IDataResult<DoctorListDto>> GetAllByNonDeletedAndActive()
		{
			var doctors = await _context.Doctors
																		.Include(d => d.Category)
																		.Include(d => d.Hospital)
																		.Where(d => !d.IsDeleted && d.IsActive)
																		.ToListAsync();
			if (doctors.Any())
			{
				return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
				{
					Doctors = doctors,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found", null);
		}

		public async Task<IResult> HardDelete(int doctorId)
		{
			var result = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
			if (result != null)
			{
				var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);

				_context.Doctors.Remove(doctor);
				return new Result(ResultStatus.Success, $"{doctor.Name} {doctor.Surname}  deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No doctor found.");
		}

		public async Task<IResult> Update(DoctorUpdateDto doctorUpdateDto, int modifiedById)
		{
			var doctor = _mapper.Map<Doctor>(doctorUpdateDto);
			doctor.ModifiedById = modifiedById;
			_context.Doctors.Update(doctor);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, $"{doctor.Name} {doctor.Surname}  updated successfully.");
		}
	}
}
