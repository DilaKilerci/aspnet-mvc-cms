using AutoMapper;
using Cms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.AppointmentDtos;

namespace Cms.Services.AutoMapper.Profiles
{
	public class AppointmentProfile:Profile
	{
		public AppointmentProfile()
		{
			CreateMap<AppointmentAddDto, Appointment>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<AppointmentUpdateDto, Appointment>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
	}
}
