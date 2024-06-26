﻿using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Utilities.Results.Concrete
{
  public class DataResult<T> : IDataResult<T>
  {
    public DataResult(ResultStatus resultStatus, T data)
    {
      ResultStatus = resultStatus;
      Data = data;
    }
    public DataResult(T data)
    {
      
      Data = data;
    }

    public DataResult(ResultStatus resultStatus, string message, T data)
    {
      ResultStatus = resultStatus;
      Message = message;
      Data = data;
    }

    public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
    {
      ResultStatus = resultStatus;
      Message = message;
      Data = data;
      Exception = exception;
    }

    public T Data { get; }

    public ResultStatus ResultStatus { get; }

    public string Message { get; }

    public Exception Exception { get; }
  }
}
