using Cms.Entities.Concrete.Dtos.HospitalDtos;
using Cms.Services.Abstract;
using Cms.Services.Validators;
using Cms.Shared.Utilities.Results.Complex_Types;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace Cms.WebMvc.Areas.Admin.Controllers.Hospital
{
	[Area("Admin")]
	public class HospitalController : Controller
  {
    private readonly IHospitalService _hospitalService;

    public HospitalController(IHospitalService hospitalService)
    {
      _hospitalService = hospitalService;
    }

    public async Task<IActionResult> Index()
    {
      //var result = await _categoryService.GetAll();
      //return View(result.Data);

      var result = await _hospitalService.GetAll();
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
    public async Task<IActionResult> Create(HospitalAddDto hospitalAddDto)
    {
      HospitalAddDtoValidator hospitalAddDtoValidator = new HospitalAddDtoValidator();
      ValidationResult results = hospitalAddDtoValidator.Validate(hospitalAddDto);


      if (results.IsValid)
      {
        var data = hospitalAddDto;
        int createdById = 1;
        await _hospitalService.Add(data, createdById);
        return RedirectToAction("Index", "Hospital");
      }
      else
      {
        foreach (var item in results.Errors)
        {
          ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
      }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int categoryId)
    {
      //var data = await _categoryService.Get(categoryId);
      //return View(data);
      return View();
    }
    [HttpPost]
    public IActionResult Edit(HospitalUpdateDto hospitalUpdateDto, int modifiedById)
    {
      return View();
    }

    
    /*public async Task<IActionResult> Delete(int id)
    {
      var hospitalDto = await _hospitalService.Get(id);
      return View(hospitalDto);
    }*/


    
    public async Task<IActionResult> Delete(int hospitalId, int modifiedById)
    {
      modifiedById = 1;
      await _hospitalService.Delete(hospitalId, modifiedById);
      return View();
    }
  }
}
