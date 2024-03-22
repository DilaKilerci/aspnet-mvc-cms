using AutoMapper;
//using Cms.Data.Migrations;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.AdminDtos;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.AutoMapper.Profiles
{
    public class AdminProfile : Profile
	{
		public AdminProfile()
		{
			CreateMap<AdminAddDto, Admin>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<AdminUpdateDto, Admin>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
	}
}
