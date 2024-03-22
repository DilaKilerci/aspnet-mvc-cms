using AutoMapper;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.AutoMapper.Profiles
{
  public class ArticleProfile : Profile
  {
    public ArticleProfile()
    {
      CreateMap<ArticleAddDto, Article>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now));
      CreateMap<ArticleUpdateDto, Article>().ForMember(dest=>dest.ModifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));

    }
  }
}
