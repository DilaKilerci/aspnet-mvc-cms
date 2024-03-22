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
  public class CategoryMap : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Id).ValueGeneratedOnAdd();
      builder.Property(c => c.Name).IsRequired();
      builder.Property(c => c.Name).HasMaxLength(100);
      builder.Property(c => c.Description).IsRequired();
      builder.Property(c => c.Description).HasMaxLength(200);
      builder.Property(c => c.CreatedById).IsRequired();
      builder.Property(c => c.ModifiedById).IsRequired();
      builder.Property(c => c.CreatedDate).IsRequired();
      builder.Property(c => c.ModifiedDate).IsRequired();
      builder.Property(c => c.IsActive).IsRequired();
      builder.Property(c => c.IsDeleted).IsRequired();
      builder.ToTable("Categories");

      //Category sınıfında bulunan ICollectionler için bir şey yapmamıza gerek yok.

      builder.HasData(new Category
      {
        Id = 6,
        Name="Cardiology",
        Description="Heart Disease",
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
