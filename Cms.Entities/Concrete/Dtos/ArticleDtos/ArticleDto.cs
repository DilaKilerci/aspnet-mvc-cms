using Cms.Shared.Entities.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.ArticleDtos
{
  public class ArticleDto : DtoGetBase
  {
    public Article Article { get; set; }

    //public override ResultStatus ResultStatus {get; set;}=ResultStatus.Success;

  }
}
