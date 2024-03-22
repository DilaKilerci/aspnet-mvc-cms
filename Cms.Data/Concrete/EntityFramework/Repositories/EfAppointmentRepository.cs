using Cms.Data.Abstract;
using Cms.Entities.Concrete;
using Cms.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Concrete.EntityFramework.Repositories
{
    public class EfAppointmentRepository : EfEntityRepositoryBase<Appointment>, IAppointmentRepository
    {
        public EfAppointmentRepository(DbContext context) : base(context)
        {
        }
    }
}
