﻿using Cms.Shared.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Utilities.Results.Abstract
{
  public interface IResult
  {
    public ResultStatus ResultStatus { get; }
    public string Message { get; }
    public Exception Exception { get; }
  }
}
