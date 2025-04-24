using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace Quantum.Logging.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private const string DefaultRequestCompletionMessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        //private static LogEventLevel DefaultGetLevel(
        //    HttpContext ctx,
        //    double _,
        //    Exception? ex)
        //{
        //    return ex == null && ctx.Response.StatusCode <= 499 ? LogEventLevel.Information : LogEventLevel.Error;
        //}
        ///// <summary>
        ///// A function returning the <see cref="T:Serilog.Events.LogEventLevel" /> based on the <see cref="T:Microsoft.AspNetCore.Http.HttpContext" />, the number of
        ///// elapsed milliseconds required for handling the request, and an <see cref="T:System.Exception" /> if one was thrown.
        ///// The default behavior returns <see cref="F:Serilog.Events.LogEventLevel.Error" /> when the response status code is greater than 499 or if the
        ///// <see cref="T:System.Exception" /> is not null.
        ///// </summary>
        ///// <value>
        ///// A function returning the <see cref="T:Serilog.Events.LogEventLevel" />.
        ///// </value>
        //public Func<HttpContext, double, Exception?, LogEventLevel> GetLevel { get; set; }

        ///// <summary>
        ///// Include the full URL query string in the <c>RequestPath</c> property
        ///// that is attached to request log events. The default is <c>false</c>.
        ///// </summary>
        ////public bool IncludeQueryInRequestPath { get; set; }

        //options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        //{
        //    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        //    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        //};

        public static void UserQuantumHttpRequestLogging(this IApplicationBuilder app,
            string messageTemplate = DefaultRequestCompletionMessageTemplate,
            bool includeQueryInRequestPath = true,
            Func<HttpContext, double, Exception, LogEventLevel> getLevelFunction = null)
        {
            app.Use(async (context, next) =>
            {
                app.UseSerilogRequestLogging(co =>
                {
                    co.MessageTemplate = messageTemplate;

                    if (getLevelFunction is not null)
                        co.GetLevel = getLevelFunction;

                    co.IncludeQueryInRequestPath = includeQueryInRequestPath;
                    co.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                    {
                        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    };
                });

                await next();
            });
        }

    }
}