﻿using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Utilities.Results.Concrete
{
  public class Result : IResult
  {
    public Result(ResultStatus resultStatus)
    {
      ResultStatus = resultStatus;
    }
    public Result(ResultStatus resultStatus, string message)
    {
      ResultStatus = resultStatus;
      Message = message;
    }
    public Result(ResultStatus resultStatus, string message, Exception exception)
    {
      ResultStatus = resultStatus;
      Message = message;
      Exception = exception;
    }

    public ResultStatus ResultStatus { get; }

    public string Message { get; }

    public Exception Exception { get; }
  }
}
