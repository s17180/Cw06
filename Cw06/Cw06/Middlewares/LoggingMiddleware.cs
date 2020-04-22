using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw06.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if(httpContext.Request != null)
            {
                string path = httpContext.Request.Path;
                string method = httpContext.Request.Method;
                string queryString = httpContext.Request.QueryString.ToString();
                string bodyString = "";

                using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8,
                   true, 1024, true))
                {
                    bodyString = await reader.ReadToEndAsync();
                }

                string fPath = "LOGS.txt";

                using (StreamWriter writer = File.AppendText(fPath))
                {

                    await writer.WriteLineAsync("Path: " + path + ", Method: " + method +
                        ", Querry: " + queryString + ".");
                    await writer.WriteLineAsync("Body: " + bodyString);

                }

            }

            if (_next != null) await _next(httpContext);
        }
    }
}
