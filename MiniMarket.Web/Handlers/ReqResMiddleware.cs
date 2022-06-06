using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.Web.Handlers
{
    public class ReqResMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ReqResMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            // Request
            context.Request.EnableBuffering(); // Important!
            var bodyTextReq = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0; // Important!
            Logger.Info($"Start request Logging Middleware: {bodyTextReq}");


            try
            {
                await _next(context);
            }
            finally
            {
                // Response
                newBody.Seek(0, SeekOrigin.Begin);
                var bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                Logger.Info($"Response Logging Middleware: {bodyText}");
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }

        }
    }
}
