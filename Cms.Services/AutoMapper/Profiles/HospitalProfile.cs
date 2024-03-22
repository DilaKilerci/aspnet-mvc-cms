using AutoMapper;
using Cms.Entities.Concrete.Dtos.DoctorDtos;
using Cms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.HospitalDtos;

namespace Cms.Services.AutoMapper.Profiles
{
	public class HospitalProfile : Profile
	{
		public HospitalProfile()
		{
			CreateMap<HospitalAddDto, Hospital>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<HospitalUpdateDto, Hospital>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
	}
}
