using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Common
{
    public class ResponseResult
    {
        public bool  IsSuccess { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }


        public ResponseResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public ResponseResult(bool isSuccess, string? message) : this(isSuccess)
        {
            Message = message;
        }
        public ResponseResult(bool isSuccess, string? message,object? data):this(isSuccess,message) 
        {
            Data = data;
        }
    }
}
