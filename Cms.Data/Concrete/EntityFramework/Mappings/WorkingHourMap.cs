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
	public class WorkingHourMap : IEntityTypeConfiguration<WorkingHour>
	{
		public void Configure(EntityTypeBuilder<WorkingHour> builder)
		{
			builder.HasKey(a => a.Id);
			builder.Property(a => a.Id).ValueGeneratedOnAdd();
			builder.Property(d => d.AppointmentTime)
									.IsRequired();
			builder.ToTable("WorkingHours");

			builder.HasData(
					new WorkingHour { Id = 1, DoctorId = 9, AppointmentTime = "09:00" },
					new WorkingHour { Id = 2, DoctorId = 9, AppointmentTime = "09:30" },
					new WorkingHour { Id = 3, DoctorId = 9, AppointmentTime = "10:00" },
					new WorkingHour { Id = 4, DoctorId = 9, AppointmentTime = "10:30" },
					new WorkingHour { Id = 5, DoctorId = 9, AppointmentTime = "11:00" },
					new WorkingHour { Id = 6, DoctorId = 9, AppointmentTime = "11:30" },
					new WorkingHour { Id = 7, DoctorId = 9, AppointmentTime = "13:00" },
					new WorkingHour { Id = 8, DoctorId = 9, AppointmentTime = "13:30" },
					new WorkingHour { Id = 9, DoctorId = 9, AppointmentTime = "14:00" },
					new WorkingHour { Id = 10, DoctorId = 9, AppointmentTime = "14:30" },
					new WorkingHour { Id = 11, DoctorId = 9, AppointmentTime = "15:00" },
					new WorkingHour { Id = 12, DoctorId = 9, AppointmentTime = "15:30" },
					new WorkingHour { Id = 13, DoctorId = 9, AppointmentTime = "16:00" },
					new WorkingHour { Id = 14, DoctorId = 9, AppointmentTime = "16:30" });

		}
	}
}

