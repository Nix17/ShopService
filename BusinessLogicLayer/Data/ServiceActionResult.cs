using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Data;

public interface IServiceActionResult<T> where T : class
{
    bool IsSuccess { get; set; }
    string Message { get; set; }
    T Result { get; set; }
}

public class ServiceActionResult<T> : IServiceActionResult<T> where T : class
{
    public ServiceActionResult(T result)
    {
        IsSuccess = true;
        Message = "OK";
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }

    public ServiceActionResult(bool success, T result)
    {
        IsSuccess = success;
        Message = "OK";
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }

    public ServiceActionResult(string message)
    {
        IsSuccess = false;
        Message = message;
        Result = null;
    }

    public ServiceActionResult(Exception ex)
    {
        IsSuccess = false;
        Message = ex.Message;
        Result = null;
    }

    public ServiceActionResult(bool isSuccess, string message, T result)
    {
        IsSuccess = isSuccess;
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Result { get; set; }
}