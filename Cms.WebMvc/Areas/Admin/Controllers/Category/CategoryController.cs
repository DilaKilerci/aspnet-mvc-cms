using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Services.Abstract;
using Cms.Services.AutoMapper.Profiles;
using Cms.Services.Validators;
using Cms.Shared.Utilities.Results.Complex_Types;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AutoMapper;
using Cms.Entities.Concrete;

namespace Cms.WebMvc.Areas.Admin.Controllers.Category
{
  [Area("Admin")]
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }


    public async Task<IActionResult> Index()
    {
      //var result = await _categoryService.GetAll();
      //return View(result.Data);

      var result = await _categoryService.GetAllByNonDeleted();
      if (result.ResultStatus == ResultStatus.Success)
      {
        return View(result.Data);
      }
      return View();
    }

    [HttpGet]
    public IActionResult Create()
    {

      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoryAddDto categoryAddDto, [FromServices] IValidator<CategoryAddDto> validator)
    {
      ValidationResult results = validator.Validate(categoryAddDto);

      /*CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(categoryAddDto);*/
      if (!results.IsValid)
      {
        ModelState.Clear();

        results.Errors.ForEach(error =>
        {
          ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        });

        return View();
      }

      var data = categoryAddDto;
      int createdById = 1;
      await _categoryService.Add(data, createdById);
      return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var category = await _categoryService.Get(id);
      if (category.ResultStatus == ResultStatus.Success)
      {
        return View(category.Data);
      }
      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto categoryDto, int modifiedById, [FromServices] IValidator<CategoryDto> validator)
    {

      ValidationResult results = validator.Validate(categoryDto);

      /*CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(categoryAddDto);*/
      if (!results.IsValid)
      {
        ModelState.Clear();

        results.Errors.ForEach(error =>
        {
          ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        });

        return View();
      }
      var result = await _categoryService.Update(categoryDto, modifiedById);
      
      if(result.ResultStatus==ResultStatus.Success)
      {
        RedirectToAction("Index","Category");
      }
      return RedirectToAction("Edit", "Category");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
      var category = await _categoryService.Get(id);
      if (category.ResultStatus == ResultStatus.Success)
      {
        return View(category.Data);
      }
      return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int categoryId, int modifiedById)
    {
      modifiedById = 1;
      var category = await _categoryService.Delete(categoryId, modifiedById);
      if (category.ResultStatus == ResultStatus.Success)
      {
        return View(category.Data);
      }
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteHard()
    {
      var result = await _categoryService.GetDeletedCategoriesForHardDelete();
      if (result.ResultStatus == ResultStatus.Success)
      {
        return View(result.Data);
      }
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteHard(int categoryId)
    {
      var category = await _categoryService.HardDelete(categoryId);

      if (category.ResultStatus == ResultStatus.Success)
      {
        RedirectToAction("Index", "Category");
      }
      TempData["ErrorMessage"] = category.Message;
      return RedirectToAction("Index", "Category");

    }
  }
}
