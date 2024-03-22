using Cms.Entities.Concrete.Dtos.CategoryDtos;
using Cms.Services.AutoMapper.Profiles;
using Cms.Services.Extensions;
using Cms.Services.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAuthentication(
CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
	option.LoginPath = "/Login/Index";
option.ExpireTimeSpan = TimeSpan.FromHours(24);

});
builder.Services.AddAutoMapper(typeof(AdminProfile), typeof(AppointmentProfile), typeof(ArticleProfile),typeof(CategoryProfile), typeof(CommentProfile), typeof(DoctorProfile), typeof(HospitalProfile), typeof(RoleProfile),typeof(UserProfile));


builder.Services.AddScoped<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
builder.Services.AddScoped<IValidator<CategoryDto>, CategoryDtoValidator>();
builder.Services.LoadMyServices();  //servis katmanýndan mvc katmanýna servileri baðlama 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
	name: "Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Login}/{action=Index}/{id?}"
	);
	endpoints.MapDefaultControllerRoute();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



app.Run();
