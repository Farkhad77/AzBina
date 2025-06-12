using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Shared;

public class BaseResponse<T>
{
    public bool Success;
    public string? Message;
    public T Data { get; set; }
    public HttpStatusCode StatusCode;
    

    public BaseResponse(HttpStatusCode statusCode)
    {
        Success = true;
        StatusCode = statusCode;
    }
    public BaseResponse(string message, HttpStatusCode statusCode)
    {
        Message = message;
        Success = false;
        StatusCode = statusCode;
    }
    public BaseResponse(string message,bool isSuccess, HttpStatusCode statusCode)
    {
        Message = message;
        Success = isSuccess;
        StatusCode = statusCode;
    }
    public BaseResponse(string message, T data, HttpStatusCode statusCode)
    {
        Success = true;
        Message = message;
        Data = data;
        StatusCode = statusCode;
    }
}
