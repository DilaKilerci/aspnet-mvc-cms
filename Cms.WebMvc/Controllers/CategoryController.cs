using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Microsoft.AspNetCore.Mvc;

namespace Cms.WebMvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }
    public async Task<IActionResult> Index()
    {
      var result = await _categoryService.GetAllByNonDeleted();
      if (result.ResultStatus == ResultStatus.Success)
      {
        return View(result.Data);
      }
      return View();
    }
  }
}
