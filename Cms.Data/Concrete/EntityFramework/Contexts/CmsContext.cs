using Microsoft.EntityFrameworkCore;

using Cms.Entities.Concrete;
using Cms.Data.Concrete.EntityFramework.Mappings;

namespace Cms.Data.EntityFramework.Contexts
{

  public class CmsContext : DbContext
  {
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Comment> Comments { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkingHour> WorkingHour { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0EBVB1K\SQLEXPRESS;Initial Catalog=Cms;Persist Security Info=True;User ID=sa;Password=12345;Trusted_Connection=True;TrustServercertificate=Yes");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
			modelBuilder.ApplyConfiguration(new CityMap());
      modelBuilder.ApplyConfiguration(new AppointmentMap());
      modelBuilder.ApplyConfiguration(new ArticleMap());
      modelBuilder.ApplyConfiguration(new CategoryMap());
      modelBuilder.ApplyConfiguration(new CommentMap());
      modelBuilder.ApplyConfiguration(new HospitalMap());
      modelBuilder.ApplyConfiguration(new RoleMap());
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new WorkingHourMap());

		}

  }
}
