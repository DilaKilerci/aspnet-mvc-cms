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
  public class DoctorMap : IEntityTypeConfiguration<Doctor>
  {
    public void Configure(EntityTypeBuilder<Doctor> builder)
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
      builder.Property(d => d.Picture).IsRequired();
      builder.Property(d => d.Picture).HasMaxLength(250);
      builder.HasOne<Role>(d => d.Role).WithMany(r => r.Doctors).HasForeignKey(d => d.RoleId);
      builder.HasOne<Hospital>(d => d.Hospital).WithMany(h => h.Doctors).HasForeignKey(d => d.HospitalId);
      builder.HasOne<Category>(d => d.Category).WithMany(h => h.Doctors).HasForeignKey(d => d.CategoryId);
      builder.HasOne<City>(d => d.City).WithMany(h => h.Doctors).HasForeignKey(d => d.CityId);
      builder.Property(d => d.CreatedById).IsRequired();
      builder.Property(d => d.ModifiedById).IsRequired();
      builder.Property(d => d.CreatedDate).IsRequired();
      builder.Property(d => d.ModifiedDate).IsRequired();
      builder.Property(d => d.IsActive).IsRequired();
      builder.Property(d => d.IsDeleted).IsRequired();
      builder.ToTable("Doctors");

      builder.HasData(new Doctor
      {
        Id = 9,
        Name = "Doctor",
        Surname = "Doctor",
        CityId=58,
        Phone="5552223344",
        CitizenId="11111111111",
        DateOfBirth=new DateTime(1987,05,7),
        Email = "doctor@gmail.com",
        Password = "Doctor.123",
        Picture= "https://as1.ftcdn.net/v2/jpg/01/62/59/04/1000_F_162590462_StuNG5boff6MVrZOCmbnDv8HPNfITqZl.jpg",
        HospitalId=5,
        RoleId=2,
        CategoryId=6,
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
