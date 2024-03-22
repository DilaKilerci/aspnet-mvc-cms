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
  public class AdminMap : IEntityTypeConfiguration<Admin>
  {
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
      builder.HasKey(d => d.Id);
      builder.Property(d => d.Id).ValueGeneratedOnAdd();
      builder.Property(d => d.Name).IsRequired();
      builder.Property(d => d.Name).HasMaxLength(100);
      builder.Property(d => d.Surname).IsRequired();
      builder.Property(d => d.Surname).HasMaxLength(100);
      builder.Property(d => d.Email).IsRequired();
      builder.HasIndex(d => d.Email).IsUnique();
      builder.Property(d => d.Password).IsRequired();
      builder.Property(d => d.Name).HasMaxLength(100);
      builder.HasOne<Role>(d => d.Role).WithMany(r => r.Admins).HasForeignKey(d => d.RoleId);
      builder.Property(d => d.CreatedById).IsRequired();
      builder.Property(d => d.ModifiedById).IsRequired();
      builder.Property(d => d.CreatedDate).IsRequired();
      builder.Property(d => d.ModifiedDate).IsRequired();
      builder.Property(d => d.IsActive).IsRequired();
      builder.Property(d => d.IsDeleted).IsRequired();
      builder.ToTable("Admins");

      builder.HasData(new Admin
      {
        Id = 1,
        Name = "Admin",
        Surname = "Admin",
        Email = "admin@gmail.com",
        Password = "Admin.123",
        RoleId = 1,
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
