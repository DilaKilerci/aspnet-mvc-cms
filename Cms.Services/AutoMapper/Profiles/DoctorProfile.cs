using AutoMapper;
using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.DoctorDtos;

namespace Cms.Services.AutoMapper.Profiles
{
	public class DoctorProfile : Profile
	{
		public DoctorProfile()
		{
			CreateMap<DoctorAddDto, Doctor>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<DoctorUpdateDto, Doctor>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
	}
}
