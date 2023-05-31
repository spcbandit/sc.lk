using System.Collections;
using System.IO.Pipelines;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using NLog.Web;
using RestSharp.Extensions;
using SC.LK.Application.Extentions;
using ILogger = NLog.ILogger;

namespace SC.LK;

public class Middleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<Middleware> _logger;
    public  ExceptionGlobalMiddleware _exceptionGlobalMiddleware;
    public Middleware(RequestDelegate next,ILogger<Middleware> logger)
    {
        _next = next;
        _logger = logger;
        _exceptionGlobalMiddleware = new ExceptionGlobalMiddleware(next,logger);
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            _logger.LogDebug(
                $"\nREQUEST:\n" +
                $"--Path:{context.Request.Path}\n" +
                $"--QueryString:{context.Request.QueryString}\n"+ 
                $"--Method:{context.Request.Method}\n"+
                $"--ContentLength:{context.Request.ContentLength}\n");
            await _next.Invoke(context);
            _logger.LogDebug($"\nRESPONSE:\n" +
                             $"--StatusCode:{context.Response.StatusCode}\n" + 
                             "\n");
            if (context.Response.StatusCode == 401 || context.Response.StatusCode == 500)
            {
                await _exceptionGlobalMiddleware.HandleErrorStatus(context);
            }
        }
        catch(Exception ex)
        {
            /* Maybe not working -_- */
            await _exceptionGlobalMiddleware.HandleExceptionMessageAsync(context,ex);
        }

    }

}