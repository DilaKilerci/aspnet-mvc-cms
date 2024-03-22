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
  public class RoleMap : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.HasKey(r => r.Id);
      builder.Property(r => r.Id).ValueGeneratedOnAdd();
      builder.Property(r => r.Name).IsRequired();
      builder.Property(r => r.Name).HasMaxLength(100);
      builder.Property(r => r.Description).IsRequired();
      builder.Property(r => r.Description).HasMaxLength(200);
      builder.Property(r => r.CreatedById).IsRequired();
      builder.Property(r => r.ModifiedById).IsRequired();
      builder.Property(r => r.CreatedDate).IsRequired();
      builder.Property(r => r.ModifiedDate).IsRequired();
      builder.Property(r => r.IsActive).IsRequired();
      builder.Property(r => r.IsDeleted).IsRequired();
      builder.ToTable("Roles");

      builder.HasData(new Role { 
      Id=1,
      Name="Admin",
      Description="Full access",
      IsActive=true,
      IsDeleted=false,
      CreatedById=1,  
      CreatedDate=DateTime.Now,
      ModifiedById=1,
      ModifiedDate=DateTime.Now,  
      },
      new Role
      {
        Id = 2,
        Name = "Doctor",
        Description = "Semi access",
        IsActive = true,
        IsDeleted = false,
        CreatedById = 1,
        CreatedDate = DateTime.Now,
        ModifiedById = 1,
        ModifiedDate = DateTime.Now,
      },
      new Role
      {
        Id = 3,
        Name = "User",
        Description = "Usage only",
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
