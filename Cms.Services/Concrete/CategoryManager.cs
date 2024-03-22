using AutoMapper;
using Cms.Data.Abstract;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Services.Abstract;
using Cms.Services.Validators;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
  public class CategoryManager : ICategoryService
  {
    private readonly CmsContext _context;
    private readonly IMapper _mapper;
    private readonly CategoryDtoValidator _categoryValidator;

    

    public CategoryManager(CmsContext context, IMapper mapper/*, CategoryValidator categoryValidator*/)
    {
      _context = context;
      _mapper = mapper;
      //_categoryValidator = categoryValidator;
    }

    public async Task<IResult> Add(CategoryAddDto categoryAddDto, int createdById)
    {
      var category = _mapper.Map<Category>(categoryAddDto);
      //var validationResult = _categoryValidator.Validate(category);
      //if (!validationResult.IsValid)
      //{
      //  return new Result (ResultStatus.Error,(validationResult.Errors.First().ErrorMessage)); // Doğrulama başarısız ise hata mesajını döndür
      //}

      //var category = _mapper.Map<Category>(categoryAddDto);
      category.CreatedById = createdById;
      category.ModifiedById= createdById;
      await _context.Categories.AddAsync(category);
      await _context.SaveChangesAsync();
      return new Result(ResultStatus.Success, $"{categoryAddDto.Name} added successfully.");
    }

    public async Task<IDataResult<CategoryDto>> Delete(int categoryId, int modifiedById)
    {
      var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);

      if (category != null)
      {
        category.IsDeleted = true;
        category.ModifiedById = modifiedById;
        category.ModifiedDate = DateTime.Now;
        var updatedCategory= _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto{
          Id = category.Id,
          Name = category.Name,
          Description = category.Description,
          IsActive = category.IsActive,
          IsDeleted = category.IsDeleted,
          ResultStatus =ResultStatus.Success,
        });
      }
      return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
      {
        Category = null,
        ResultStatus = ResultStatus.Error
      });
    }

    public async Task<IDataResult<CategoryDto>> Get(int categoryId)
    {
      var category = await _context.Categories.Include(c => c.Articles)
                                               .SingleOrDefaultAsync(c => c.Id == categoryId);
      if (category != null)
      {
				return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto{
        Id=category.Id,
        Name=category.Name,
        Description=category.Description,
        IsActive=category.IsActive,
        IsDeleted=category.IsDeleted,
        });
      }
      return new DataResult<CategoryDto>(ResultStatus.Error, "No category found.", null);
    }

		public async Task<IDataResult<CategoryListDto>> GetDeletedCategoriesForHardDelete()
		{
			var categories = await _context.Categories.Where(c => c.IsDeleted ==true).ToListAsync();
      if (categories.Any())
      {
        return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
        {
          Categories = categories,
          ResultStatus = ResultStatus.Success,
        });
      }
			return new DataResult<CategoryListDto>(ResultStatus.Error, "No deleted category found.", null);
		}

		public async Task<IDataResult<CategoryListDto>> GetAll()
    {
      var categories = await _context.Categories.Include(c => c.Articles).ToListAsync();
      if (categories.Count > 0)
      {
        return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto{
          Categories = categories,
          ResultStatus = ResultStatus.Success,

        });
      }
      return new DataResult<CategoryListDto>(ResultStatus.Error, "No categories found.", new CategoryListDto
      { 
        Categories=null,
        ResultStatus=ResultStatus.Error,
        Message="No category found."
      });
    }

    public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
    {
      var categories = await _context.Categories.Where(c => !c.IsDeleted).Include(c => c.Articles).ToListAsync();
      if (categories.Any())
      {
        return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto{
        Categories=categories,
        ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<CategoryListDto>(ResultStatus.Error, "No non-deleted categories found.", null);
    }

    public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
    {
      var categories = await _context.Categories.Where(c => !c.IsDeleted&&c.IsActive).Include(c => c.Articles).ToListAsync();
      if (categories.Any())
      {
        return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
        {
          Categories = categories,
          ResultStatus = ResultStatus.Success,
        });
      }
      return new DataResult<CategoryListDto>(ResultStatus.Error, "No non-deleted categories found.", null);
    }

    public async Task<IResult> HardDelete(int categoryId)
    {
      var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);

      if (category != null)
      {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return new Result(ResultStatus.Success, $"{category.Name} deleted from database successfully.");
      }
      return new DataResult<Category>(ResultStatus.Error, "No category found.", null);
    }

    public async Task<IResult> Update(CategoryDto categoryDto, int modifiedById)
    {

      var category = await _context.Categories.FindAsync(categoryDto.Id);

      if (category == null)
      {
        return new DataResult<Category>(ResultStatus.Error, "Category not found.", null);
      }

      category.Name = categoryDto.Name;
      category.Description = categoryDto.Description;
      category.IsActive = categoryDto.IsActive;
      category.IsDeleted = categoryDto.IsDeleted;
      category.ModifiedById = modifiedById;
      category.ModifiedDate = DateTime.Now;

      _context.Categories.Update(category);
      await _context.SaveChangesAsync();

      return new Result(ResultStatus.Success, $"{category.Name} titled category updated successfully.");
      /*var category = _mapper.Map<Category>(categoryDto);
      category.ModifiedById = modifiedById;
      _context.Categories.Update(category);  //hocaya sor
      await _context.SaveChangesAsync();
      return new Result(ResultStatus.Success, $"{categoryDto.Name} titled category updated successfully.");*/
    }
  }
}
