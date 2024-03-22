using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.HospitalDtos;
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
using Cms.Entities.Concrete.Dtos.ArticleDtos;

namespace Cms.Services.Concrete
{
	public class HospitalManager:IHospitalService
	{
		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public HospitalManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IResult> Add(HospitalAddDto hospitalAddDto, int createdById)
		{
			var hospital = _mapper.Map<Hospital>(hospitalAddDto);

			hospital.CreatedById = createdById;
			hospital.ModifiedById = createdById;
			await _context.Hospitals.AddAsync(hospital);
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, $"{hospitalAddDto.Name} added successfully.");
		}

		public async Task<IResult> Delete(int hospitalId, int modifiedById)
		{
			var hospital = await _context.Hospitals.FirstOrDefaultAsync(a => a.Id == hospitalId);

			if (hospital != null)
			{
				hospital.IsDeleted = true;
				hospital.ModifiedById = modifiedById;
				hospital.ModifiedDate = DateTime.Now;
				_context.Hospitals.Update(hospital);
				return new Result(ResultStatus.Success, $"{hospital.Name} deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No hospital found.");
		}

		public async Task<IDataResult<HospitalDto>> Get(int hospitalId)
		{
			var hospital = await _context.Hospitals
																	.SingleOrDefaultAsync(x => x.Id == hospitalId);

			if (hospital != null)
			{
				return new DataResult<HospitalDto>(ResultStatus.Success, new HospitalDto
				{
					Hospital = hospital,
				});
			}
			return new DataResult<HospitalDto>(ResultStatus.Error, "No hospital found", null);
		}

		public async Task<IDataResult<HospitalListDto>> GetAll()
		{
			var hospitals = await _context.Hospitals.ToListAsync();
			if (hospitals.Any())
			{
				return new DataResult<HospitalListDto>(ResultStatus.Success, new HospitalListDto
				{
					Hospitals = hospitals,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<HospitalListDto>(ResultStatus.Error, "No hopitals found", null);
		}

		public async Task<IDataResult<HospitalListDto>> GetAllByCity(int cityId)
		{
			var result = await _context.Cities.AnyAsync(c => c.Id == cityId);

			if (result)
			{
				var hospitals = await _context.Hospitals
																			.Include(a => a.City)
																			.Where(a => a.CityId == cityId && !a.IsDeleted && a.IsActive)
																			.ToListAsync();
				if (hospitals.Any())
				{
					return new DataResult<HospitalListDto>(ResultStatus.Success, new HospitalListDto
					{
						Hospitals = hospitals,
						ResultStatus = ResultStatus.Success,
					});
				}
				return new DataResult<HospitalListDto>(ResultStatus.Error, "No hospitals found", null);
			}
			return new DataResult<HospitalListDto>(ResultStatus.Error, "No hospitals found for this city", null);
		}

		public async Task<IDataResult<HospitalListDto>> GetAllByNonDeleted()
		{
			var hospitals = await _context.Hospitals
																		.Include(h =>h.City)
																		.Where(a => !a.IsDeleted)
																		.ToListAsync();

			if (hospitals.Any())
			{
				return new DataResult<HospitalListDto>(ResultStatus.Success, new HospitalListDto
				{
					Hospitals = hospitals,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<HospitalListDto>(ResultStatus.Error, "No hospitals found", null);
		}

		public async Task<IDataResult<HospitalListDto>> GetAllByNonDeletedAndActive()
		{
			var hospitals = await _context.Hospitals
																		.Include(h => h.City)
																		.Where(a => !a.IsDeleted && a.IsActive)
																		.ToListAsync();
			if (hospitals.Any())
			{
				return new DataResult<HospitalListDto>(ResultStatus.Success, new HospitalListDto
				{
					Hospitals = hospitals,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<HospitalListDto>(ResultStatus.Error, "No hospitals found", null);
		}

		public async Task<IResult> HardDelete(int hospitalId)
		{
			var hospital = await _context.Hospitals.FirstOrDefaultAsync(a => a.Id == hospitalId);
			if (hospital != null)
			{
				_context.Hospitals.Remove(hospital);
				return new Result(ResultStatus.Success, $"{hospital.Name}  deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No hospital found.");
		}

		public async Task<IResult> Update(HospitalUpdateDto hospitalUpdateDto, int modifiedById)
		{
			var hospital = _mapper.Map<Hospital>(hospitalUpdateDto);
			hospital.ModifiedById = modifiedById;
			_context.Hospitals.Update(hospital);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, $"{hospitalUpdateDto.Name} updated successfully.");
		}
	}
}
