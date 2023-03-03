using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace SwagTest.Diagnostics
{
    class SerilogMiddleware
    {
        const string MessageTemplate = "HTTP {RequestMethod} {RequestPath}"; // responded {StatusCode} in {Elapsed:0.0000} ms";
        readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            
            var level = httpContext.Response?.StatusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;
            var path = httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget ?? httpContext.Request.Path.ToString();

            Log.Write(level, MessageTemplate, httpContext.Request.Method, path/*, statusCode, elapsedMs*/);

            await _next(httpContext);
        }
    }
}
