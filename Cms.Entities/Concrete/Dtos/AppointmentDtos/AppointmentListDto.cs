﻿using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.AppointmentDtos
{
	public class AppointmentListDto:DtoGetBase
	{
        public IList<Appointment> Appointments { get; set; }
    }
}
