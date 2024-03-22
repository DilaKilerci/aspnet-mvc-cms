using AutoMapper;
using Cms.Entities.Concrete.Dtos.HospitalDtos;
using Cms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.UserDtos;

namespace Cms.Services.AutoMapper.Profiles
{
	public class UserProfile:Profile
	{
        public UserProfile()
        {
			CreateMap<UserAddDto, User>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<UserUpdateDto, User>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
    }
}
