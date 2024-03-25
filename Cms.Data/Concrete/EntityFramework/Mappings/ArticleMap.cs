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
  public class ArticleMap : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      builder.HasKey(a => a.Id);
      builder.Property(a => a.Id).ValueGeneratedOnAdd();
      builder.Property(a => a.Title).HasMaxLength(200);
      builder.Property(a => a.Title).IsRequired();
      builder.Property(a => a.Content).IsRequired();
      builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
      builder.Property(a => a.CreatedById).IsRequired();
      builder.Property(a => a.ModifiedById).IsRequired();
      builder.Property(a => a.CreatedDate).IsRequired();
      builder.Property(a => a.ModifiedDate).IsRequired();
      builder.Property(a => a.IsActive).IsRequired();
      builder.Property(a => a.IsDeleted).IsRequired();
      builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
      builder.HasOne<User>(a => a.User).WithMany(d => d.Articles).HasForeignKey(a => a.DoctorId);
      builder.ToTable("Articles");
      builder.HasData(new Article
      {
        Id = 3,
        Title = "Heart Attack Symptoms",
        Content = "Heart attack symptoms can vary widely between individuals, but commonly include chest pain or discomfort, often described as pressure, squeezing, or fullness. This pain may radiate to the arms, neck, jaw, back, or stomach. Other symptoms can include shortness of breath, nausea, lightheadedness, cold sweats, and fatigue. It's important to note that symptoms may be different for men and women, with women sometimes experiencing less typical symptoms such as unusual fatigue, sleep disturbances, or indigestion. Prompt recognition of heart attack symptoms is crucial for seeking immediate medical attention, as early intervention can greatly improve outcomes and prevent complications.",
        CategoryId = 6,
        DoctorId = 9,
        IsActive = true,
        IsDeleted = false,
        CreatedById = 1,
        CreatedDate = DateTime.Now,
        ModifiedById = 1,
        ModifiedDate = DateTime.Now,
      }); ;
    }
  }
}
