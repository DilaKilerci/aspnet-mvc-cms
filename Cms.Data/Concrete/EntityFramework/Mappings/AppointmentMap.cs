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
  public class AppointmentMap : IEntityTypeConfiguration<Appointment>
  {
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
      builder.HasKey(a => a.Id);
      builder.Property(a => a.Id).ValueGeneratedOnAdd();
      builder.Property(a=>a.AppointmentDate).IsRequired();
      builder.Property(a=>a.AppointmentDate).HasColumnType("datetime");
      builder.HasOne<Hospital>(a => a.Hospital).WithMany(h => h.Appointments).HasForeignKey(a => a.HospitalId);
      builder.HasOne<Category>(a => a.Category).WithMany(h => h.Appointments).HasForeignKey(a => a.CategoryId);
      builder.HasOne<Doctor>(a => a.Doctor).WithMany(h => h.Appointments).HasForeignKey(a => a.DoctorId);
      builder.HasOne<User>(a => a.User).WithMany(h => h.Appointments).HasForeignKey(a => a.UserId);
      builder.HasOne<WorkingHour>(a => a.WorkingHour).WithMany(h => h.Appointments).HasForeignKey(a => a.WorkingHourId);

      builder.HasData(new Appointment
      {
        Id = 7,
        AppointmentDate = new DateTime(2024,12,13),
        UserId = 27,
        HospitalId = 5,
        CategoryId=6,
        DoctorId = 9,
        WorkingHourId = 10,
        IsActive = true,
        IsDeleted = false,
        CreatedById = 1,
        CreatedDate = DateTime.Now,
        ModifiedById = 1,
        ModifiedDate = DateTime.Now,
      }
      ) ;
    }
  }
}
