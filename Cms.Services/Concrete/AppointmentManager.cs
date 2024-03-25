using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.AppointmentDtos;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
	public class AppointmentManager : IAppointmentService
	{
	private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public AppointmentManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IResult> Add(AppointmentAddDto appointmentAddDto, int createdById)
		{
			var result = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentAddDto.AppointmentId);
			if(result == null) {
				var appointment = _mapper.Map<Appointment>(appointmentAddDto);
				appointment.ModifiedById = createdById;
				appointment.CreatedById = createdById;
				appointment.DoctorId = createdById;
				await _context.Appointments.AddAsync(appointment);
				await _context.SaveChangesAsync();
				return new Result(ResultStatus.Success, $"Appointment created for${appointmentAddDto.AppointmentDate} at ${appointmentAddDto.WorkingHourId} successfully.");
			}
			return new Result(ResultStatus.Success, $"Appointment is not avaliable for${appointmentAddDto.AppointmentDate} at ${appointmentAddDto.WorkingHourId}. Please try again. ");

		}

		public async Task<IResult> Delete(int appointmentId, int modifiedById)
		{
			var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
			if (appointment != null)
			{
				appointment.IsDeleted = true;
				appointment.ModifiedById = modifiedById;
				appointment.ModifiedDate = DateTime.Now;
				_context.Appointments.Update(appointment);
				await _context.SaveChangesAsync();
				return new Result(ResultStatus.Success, "Appointment deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No article found.");
		}

		public async Task<IDataResult<AppointmentDto>> Get(int appointmentId)
		{
			var appointment = await _context.Appointments
																	.Include(a => a.Category)
																	.Include(a => a.User)
																	.Include(a => a.Hospital)
																	.SingleOrDefaultAsync(x => x.Id == appointmentId);

			if (appointment != null)
			{
				return new DataResult<AppointmentDto>(ResultStatus.Success, new AppointmentDto
				{
					Appointment = appointment,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AppointmentDto>(ResultStatus.Error, "No appointment found", null);
		}

		public async Task<IDataResult<AppointmentListDto>> GetAll()
		{
			var apponitments = await _context.Appointments
																	.Include(a => a.Category)
																	.Include(a => a.User)
																	.Include(a => a.Hospital).ToListAsync();
			if (apponitments.Any())
			{
				return new DataResult<AppointmentListDto>(ResultStatus.Success, new AppointmentListDto
				{
					Appointments = apponitments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AppointmentListDto>(ResultStatus.Error, "No appointment found", null);
		}

		public async Task<IDataResult<AppointmentListDto>> GetAllByDoctor(int doctorId)
		{
			var result = await _context.Appointments.AnyAsync(c => c.Id == doctorId);

			if (result)
			{
				var appointments = await _context.Appointments
																	.Include(a => a.Category)
																	.Include(a => a.User)
																	.Include(a => a.Hospital)
																			.Where(a => a.DoctorId == doctorId && !a.IsDeleted && a.IsActive)
																			.ToListAsync();
				if (appointments.Any())
				{
					return new DataResult<AppointmentListDto>(ResultStatus.Success, new AppointmentListDto
					{
						Appointments = appointments,
						ResultStatus = ResultStatus.Success,
					});
				}
				return new DataResult<AppointmentListDto>(ResultStatus.Error, "No appointments found", null);
			}
			return new DataResult<AppointmentListDto>(ResultStatus.Error, "No doctors found", null);
		}

		public async Task<IDataResult<AppointmentListDto>> GetAllByNonDeleted()
		{
			var appointments = await _context.Appointments
																	.Include(a => a.Category)
																	.Include(a => a.User)
																	.Include(a => a.Hospital)
																		.Where(a => !a.IsDeleted)
																		.ToListAsync();

			if (appointments.Any())
			{
				return new DataResult<AppointmentListDto>(ResultStatus.Success, new AppointmentListDto
				{
					Appointments = appointments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AppointmentListDto>(ResultStatus.Error, "No appointments found", null);
		}

		public async Task<IDataResult<AppointmentListDto>> GetAllByNonDeletedAndActive()
		{
			var appointments = await _context.Appointments
																	.Include(a => a.Category)
																	.Include(a => a.User)
																	.Include(a => a.Hospital)
																		.Where(a => !a.IsDeleted && a.IsActive)
																		.ToListAsync();

			if (appointments.Any())
			{
				return new DataResult<AppointmentListDto>(ResultStatus.Success, new AppointmentListDto
				{
					Appointments = appointments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<AppointmentListDto>(ResultStatus.Error, "No appointments found", null);
		}

		public async Task<IResult> HardDelete(int appointmentId)
		{
			var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
			if (appointment != null)
			{
				_context.Appointments.Remove(appointment);
				return new Result(ResultStatus.Success, "Appointment deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No appointment found.");
		}

		public async Task<IResult> Update(AppointmentUpdateDto appointmentUpdateDto, int modifiedById)
		{
			var appointment = _mapper.Map<Appointment>(appointmentUpdateDto);
			appointment.ModifiedById = modifiedById;
			_context.Appointments.Update(appointment);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, "Appointment updated successfully.");
		}
	}
}
