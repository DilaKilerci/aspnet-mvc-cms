using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Entities.Concrete;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Entities.Concrete.Dtos.ArticleDtos;

namespace Cms.Services.Abstract
{
  public interface IArticleService
  {
    Task<IDataResult<ArticleDto>> Get(int articleId);
    Task<IDataResult<ArticleListDto>> GetAll();
    Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
    Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
    Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
    Task<IResult> Add(ArticleAddDto articleAddDto, int createdById);
    Task<IResult> Update(ArticleUpdateDto articleUpdateDto, int modifiedById);
    Task<IResult> Delete(int articleId, int modifiedById);
    Task<IResult> HardDelete(int articleId);
  }
}
