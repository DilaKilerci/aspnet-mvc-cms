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
  public class HospitalMap : IEntityTypeConfiguration<Hospital>
  {
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
      builder.HasKey(d => d.Id);
      builder.Property(d => d.Id).ValueGeneratedOnAdd();
      builder.Property(d => d.Name).IsRequired();
      builder.Property(d => d.Name).HasMaxLength(100);
      builder.Property(d => d.CreatedById).IsRequired();
      builder.Property(d => d.ModifiedById).IsRequired();
      builder.Property(d => d.CreatedDate).IsRequired();
      builder.Property(d => d.ModifiedDate).IsRequired();
      builder.Property(d => d.IsActive).IsRequired();
      builder.Property(d => d.IsDeleted).IsRequired();
			builder.HasOne<City>(d => d.City).WithMany(h => h.Hospitals).HasForeignKey(d => d.CityId);
			builder.ToTable("Hospitals");

      builder.HasData(new Hospital
      {
        Id = 5,
        Name = "Test Hospital",
        CityId = 58,
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
