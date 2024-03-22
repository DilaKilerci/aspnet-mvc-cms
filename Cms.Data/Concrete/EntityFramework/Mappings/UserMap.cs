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
      builder.Property(d => d.Password).IsRequired();
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
        Password = "User.123",
        RoleId = 3,
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
