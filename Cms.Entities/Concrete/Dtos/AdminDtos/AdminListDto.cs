﻿using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.AdminDtos
{
    public class AdminListDto : DtoGetBase
    {
        public IList<Admin> Admins { get; set; }
    }
}
