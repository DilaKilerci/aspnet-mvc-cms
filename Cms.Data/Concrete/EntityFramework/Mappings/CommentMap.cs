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
  public class CommentMap : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Id).ValueGeneratedOnAdd();
      builder.Property(c => c.Text).IsRequired();
      builder.Property(c => c.Text).HasMaxLength(500);
      builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);
      builder.HasOne<User>(c => c.User).WithMany(a => a.Comments).HasForeignKey(c => c.UserId);
      builder.Property(c => c.CreatedById).IsRequired();
      builder.Property(c => c.ModifiedById).IsRequired();
      builder.Property(c => c.CreatedDate).IsRequired();
      builder.Property(c => c.ModifiedDate).IsRequired();
      builder.Property(c => c.IsActive).IsRequired();
      builder.Property(c => c.IsDeleted).IsRequired();
      builder.ToTable("Comments");

      builder.HasData(new Comment
      {
        Id = 2,
        Text = "Test comment.",
        ArticleId =3,
        UserId=27,
        DoctorId=9,
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
