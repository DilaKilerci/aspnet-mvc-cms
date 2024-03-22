using AutoMapper;
using Cms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.CommentDtos;

namespace Cms.Services.AutoMapper.Profiles
{
	public class CommentProfile : Profile
	{
		public CommentProfile()
		{
			CreateMap<CommentAddDto, Comment>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
			CreateMap<CommentUpdateDto, Comment>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
		}
	}
}
