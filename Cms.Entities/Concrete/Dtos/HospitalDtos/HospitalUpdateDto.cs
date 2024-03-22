using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.HospitalDtos
{
	public class HospitalUpdateDto
	{
		public string Name { get; set; }
		public int CityId { get; set; }
        public bool IsActive { get; set; }
    }
}
