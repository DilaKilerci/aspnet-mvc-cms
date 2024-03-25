using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
  public class ArticleManager : IArticleService
  {
    private readonly CmsContext _context;
    private readonly IMapper _mapper;

    public ArticleManager(CmsContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IResult> Add(ArticleAddDto articleAddDto, int createdById)
    {
      var article = _mapper.Map<Article>(articleAddDto);
      article.CreatedById = createdById;
      article.ModifiedById = createdById;
      article.DoctorId = createdById;
      await _context.Articles.AddAsync(article);
      await _context.SaveChangesAsync();
      return new Result(ResultStatus.Success,$"{articleAddDto.Title} titled article saved successfully.");
    }

    public async Task<IResult> Delete(int articleId, int modifiedById)
    {
      var article = await _context.Articles.FirstOrDefaultAsync(a=>a.Id==articleId);
      if(article != null)
      {
        article.IsDeleted = true;
        article.ModifiedById = modifiedById;
        article.ModifiedDate=DateTime.Now;
        _context.Articles.Update(article);
        await _context.SaveChangesAsync();
        return new Result(ResultStatus.Success, $"{article.Title} titled article deleted successfully.");
      }
      return new Result(ResultStatus.Error, "No article found.");
    }

    public async Task<IDataResult<ArticleDto>> Get(int articleId)
    {
      var article = await _context.Articles
                                  .Include(a => a.Category)
                                  .SingleOrDefaultAsync(x => x.Id == articleId);

      if (article != null)
      {
        return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
        {
          Article = article,
          ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<ArticleDto>(ResultStatus.Error, "No article found", null);
    }

    public async Task<IDataResult<ArticleListDto>> GetAll()
    {
      var articles = await _context.Articles
                          .Include(a => a.Category).ToListAsync();
      if (articles.Any())
      {
        return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
        {
          Articles = articles,
          ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<ArticleListDto>(ResultStatus.Error, "No articles found", null);
    }

    public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
    {
      var result = await _context.Articles.AnyAsync(c => c.Id == categoryId);

      if (result)
      {
        var articles = await _context.Articles
                                      .Include(a => a.Category)
                                      .Where(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive)
                                      .ToListAsync();
        if (articles.Any())
        {
          return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
          {
            Articles = articles,
            ResultStatus = ResultStatus.Success,
          });
        }
        return new DataResult<ArticleListDto>(ResultStatus.Error, "No articles found", null);
      }
      return new DataResult<ArticleListDto>(ResultStatus.Error, "No categories found", null);

    }

    public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
    {
      var articles = await _context.Articles
                                    .Include(a => a.Category)
                                    .Where(a => !a.IsDeleted)
                                    .ToListAsync();

      if (articles.Any())
      {
        return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
        {
          Articles = articles,
          ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<ArticleListDto>(ResultStatus.Error, "No articles found", null);
    }

    public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
    {
      var articles = await _context.Articles
                                    .Include(a => a.Category)
                                    .Where(a => !a.IsDeleted && a.IsActive)
                                    .ToListAsync();
      if (articles.Any())
      {
        return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
        {
          Articles = articles,
          ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<ArticleListDto>(ResultStatus.Error, "No articles found", null);
    }

    public async Task<IResult> HardDelete(int articleId)
    {

			var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == articleId);
			if (article != null)
      {        
        _context.Articles.Remove(article);
        return new Result(ResultStatus.Success, $"{article.Title} titled article deleted from database successfully.");
      }
      return new Result(ResultStatus.Error, "No article found.");
    }

    public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, int modifiedById)
    {
      var article = _mapper.Map<Article>(articleUpdateDto);
      article.ModifiedById = modifiedById;
      _context.Articles.Update(article);  //hocaya sor
      await _context.SaveChangesAsync();
      return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} titled article updated successfully.");
    }
  }
}
