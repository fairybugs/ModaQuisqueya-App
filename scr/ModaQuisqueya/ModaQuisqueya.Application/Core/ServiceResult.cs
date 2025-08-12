using System;
namespace ModaQuisqueya.Application.Core
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ServiceResult Success(string message = "Operación exitosa.")
        {
            return new ServiceResult { IsSuccess = true, Message = message };
        }

        public static ServiceResult Failure(string message)
        {
            return new ServiceResult { IsSuccess = false, Message = message };
        }
    }
}
