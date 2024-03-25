using Cms.Data.EntityFramework.Contexts;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<CmsContext>();
			serviceCollection.AddScoped<IAppointmentService, AppointmentManager>();
			serviceCollection.AddScoped<IArticleService, ArticleManager>();
			serviceCollection.AddScoped<ICategoryService, CategoryManager>();
			serviceCollection.AddScoped<IHospitalService, HospitalManager>();
			serviceCollection.AddScoped<IRoleService, RoleManager>();
			serviceCollection.AddScoped<IUserService, UserManager>();

			return serviceCollection;
		}
	}
}
