﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;
        public BaseException() : base("Falha ao processar solicitação.") { }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, HttpStatusCode statusCode) : base(message: message)
        {
            StatusCode = statusCode;
        }
        public BaseException(string message, HttpStatusCode statusCode, Exception innerException) : base(message: message, innerException: innerException)
        {
            StatusCode = statusCode;
        }
    }
}