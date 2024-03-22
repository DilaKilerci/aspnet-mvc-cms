using Cms.Shared.Entities.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.ArticleDtos
{
  public class ArticleListDto : DtoGetBase
  {
    public IList<Article> Articles { get; set; }

  }
}
