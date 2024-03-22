using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.HospitalDtos
{
	public class HospitalListDto:DtoGetBase
	{
		public IList<Hospital>  Hospitals { get; set; }
	}
}
