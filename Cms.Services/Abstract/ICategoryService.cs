using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface ICategoryService
  {
    Task<IDataResult<CategoryDto>> Get(int categoryId);
		Task<IDataResult<CategoryListDto>> GetDeletedCategoriesForHardDelete();
		Task<IDataResult<CategoryListDto>> GetAll();
    Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
    Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
    Task<IResult> Add(CategoryAddDto categoryAddDto, int createdById);
    Task<IResult> Update(CategoryDto categoryDto, int modifiedById);
    Task<IDataResult<CategoryDto>> Delete(int categoryId, int modifiedById);
    Task<IResult> HardDelete(int categoryId);

  }
}
