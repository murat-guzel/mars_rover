using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Mars_Rover.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel loglevel, string message, Exception exception = null, string responseBody = null,
           string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
           long? duration = null, string hostName = null, string url = null)
        {

            Console.WriteLine(JsonSerializer.Serialize(new
            {
                CorrelationId = Trace.CorrelationManager.ActivityId,
                DateTime = DateTime.Now,
                LogLevel = loglevel.ToString(),
                Message = message,
                Exception = exception?.ToString(),
                ResponseBody = responseBody,
                RequestBody = requestBody,
                HttpMethod = httpMethod?.Method,
                HttpStatusCode = (int)httpStatusCode,
                Duration = duration,
                HostName = hostName,
                Url = url,
            }));
        }

    }
}
