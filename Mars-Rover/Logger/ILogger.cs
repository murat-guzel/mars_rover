using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Mars_Rover.Logger
{
    public interface ILogger
    {
        void Log(LogLevel loglevel, string message, Exception exception = null, string responseBody = null,
           string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
           long? duration = null, string hostName = null, string url = null);
    }
}
