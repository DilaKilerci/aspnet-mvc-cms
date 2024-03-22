using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.CategoryDtos
{
  public class CategoryListDto:DtoGetBase
  { 
  public IList<Category> Categories { get; set; }
  }
}
