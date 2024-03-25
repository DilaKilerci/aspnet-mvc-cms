using Cms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Concrete.EntityFramework.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(d => d.Id);
      builder.Property(d => d.Id).ValueGeneratedOnAdd();
      builder.Property(d => d.Name).IsRequired();
      builder.Property(d => d.Name).HasMaxLength(100);
      builder.Property(d => d.Surname).IsRequired();
      builder.Property(d => d.Surname).HasMaxLength(100);
      builder.Property(d => d.Phone).IsRequired();
      builder.Property(d => d.Phone).HasMaxLength(10);
      builder.Property(d => d.CitizenId).IsRequired();
      builder.Property(d => d.CitizenId).HasMaxLength(11);
      builder.HasIndex(d => d.CitizenId).IsUnique();
      builder.Property(d => d.DateOfBirth).IsRequired();
      builder.Property(d => d.Email).IsRequired();
      builder.HasIndex(d => d.Email).IsUnique();
      builder.Property(d => d.PasswordHash).IsRequired();
      builder.Property(d => d.PasswordHash).HasColumnType("VARBINARY(500)");
      builder.HasOne<Role>(d => d.Role).WithMany(r => r.Users).HasForeignKey(d => d.RoleId);
			builder.HasOne<City>(d => d.City).WithMany(h => h.Users).HasForeignKey(d => d.CityId);
			builder.ToTable("Hospitals");
			builder.Property(d => d.CreatedById).IsRequired();
      builder.Property(d => d.ModifiedById).IsRequired();
      builder.Property(d => d.CreatedDate).IsRequired();
      builder.Property(d => d.ModifiedDate).IsRequired();
      builder.Property(d => d.IsActive).IsRequired();
      builder.Property(d => d.IsDeleted).IsRequired();
      builder.ToTable("Users");


      builder.HasData(new User
      {
        Id = 27,
        Name = "User",
        Surname = "User",
        CityId = 58,
        Phone = "5552223344",
        CitizenId = "12222222222",
        DateOfBirth = new DateTime(1990, 06, 7),
        Email = "user@gmail.com",
        PasswordHash = Encoding.ASCII.GetBytes("82d95ae4b384e338d7befbc64cd3e104"),
        RoleId = 3,
        IsActive = true,
        IsDeleted = false,
        CreatedById = 1,
        CreatedDate = DateTime.Now,
        ModifiedById = 1,
        ModifiedDate = DateTime.Now,
      }, new User{
				Id = 1,
				Name = "Admin",
				Surname = "Admin",
				Email = "admin@gmail.com",
				PasswordHash = Encoding.ASCII.GetBytes("7fe997c8d3b2dd1a1ae5e76b0acc6084"),
				RoleId = 1,
				IsActive = true,
				IsDeleted = false,
				CreatedById = 1,
				CreatedDate = DateTime.Now,
				ModifiedById = 1,
				ModifiedDate = DateTime.Now,
			}, new User{
				Id = 9,
				Name = "Doctor",
				Surname = "Doctor",
				CityId = 58,
				Phone = "5552223344",
				CitizenId = "11111111111",
				DateOfBirth = new DateTime(1987, 05, 7),
				Email = "doctor@gmail.com",
				PasswordHash = Encoding.ASCII.GetBytes("a0e83105abec0cfae4d153cbeb0b6fa7"),
				Picture = "https://as1.ftcdn.net/v2/jpg/01/62/59/04/1000_F_162590462_StuNG5boff6MVrZOCmbnDv8HPNfITqZl.jpg",
				RoleId = 2,
				IsActive = true,
				IsDeleted = false,
				CreatedById = 1,
				CreatedDate = DateTime.Now,
				ModifiedById = 1,
				ModifiedDate = DateTime.Now,
			}
      );
    }
  }
}
