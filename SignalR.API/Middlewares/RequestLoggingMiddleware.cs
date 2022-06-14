using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                //var userAgent = context.Request.Headers["User-Agent"];
                //string uaString = Convert.ToString(userAgent[0]);
                //var uaParser = Parser.GetDefault();
                //ClientInfo c = uaParser.Parse(uaString);
                //var browsr = c.UserAgent.Family; //IP Address from the request.
                //                                 // Note in localhost you will get ::1 but when it hosted you will get IP Address
                //                                 //var ipaddrs = Accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                //                                 //// timezone convert from UTC to EST
                //                                 //var timeUtc = DateTime.UtcNow;
                //                                 //TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                //                                 //DateTime easternTime = TimeZoneInfo.ConvertTime(timeUtc, easternZone);

                _logger.LogInformation(
                    "==> Request  : {method} , Url : {url} , StatusCode : {statusCode} , BrowserName : { browsername } , IpAddress : {RemoteIpAddress}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode,
                     context.Request.Headers["User-Agent"].ToString(), //c.UserAgent.Family,
                    context.Request.HttpContext.Connection.RemoteIpAddress.ToString());
            }
        }
    }

}
