using DynamicForm.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Application.Implementations
{
    public class BaseService
    {
        public static Result<T> SetError<T>(int code, string message, Result<T> result)
        {

            result.ErrorResponse = new ErrorResponse
            {
                ResponseCode = code,
                ResponseMessage = message,
            };
            return result;
        }

        public static Result<T> SetSuccess<T>(T data, Result<T> result)
        {
            result.IsSuccessful = true;
            result.Data = data;
            return result;
        }
    }
}
