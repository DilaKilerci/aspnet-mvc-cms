using Cms.Entities.Concrete;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Cms.Entities.Concrete.Dtos.AdminDtos;

namespace Cms.WebMvc.Controllers
{
	public class LoginController : Controller
	{
		private readonly IAdminService _adminService;

		public LoginController(IAdminService adminService)
		{
			_adminService = adminService;
		}


	

		[HttpGet]
		public async Task<IActionResult> Index()

		{

			ClaimsPrincipal claimUser = HttpContext.User;

			if (claimUser.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(AdminLoginDto adminUser)
		{

			var result = await _adminService.GetAdminForLogin(adminUser);

			if (result.ResultStatus == ResultStatus.Success && result.Data != null)
			{

				List<Claim> claims = new List<Claim>(){
					new Claim(ClaimTypes.NameIdentifier, adminUser.Email)};

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = adminUser.KeepLoggedIn

				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity), properties);
				return RedirectToAction("Index", "Home", new { area = "Admin" });
			}

			else
			{
				ViewData["ValidateMEssage"] = "User not found.";
				return View();
			}

		}
	}
}
