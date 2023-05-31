using System.Diagnostics;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using NLog.Web;

namespace SC.LK;

public class ExceptionGlobalMiddleware
{
     private readonly RequestDelegate _next;
    private readonly ILogger<Middleware> _logger;
    public ExceptionGlobalMiddleware(RequestDelegate next,ILogger<Middleware> logger )
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)  
    {  
        try  
        {  
            await _next.Invoke(context);
        }  
        catch (Exception ex)  
        {
            
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);  
        }  
    }  
    public async Task HandleExceptionMessageAsync(HttpContext context, Exception exception)  
    {  
        context.Response.ContentType = "application/json";
        _logger.LogDebug(
            $"--EXCEPTION:{exception.Message}" +
            $"--STATUSCODE:{context.Response.StatusCode}"+
            $"\n--SOURCE:{exception.Source}"+
            $"\n--STACKTRACE:{exception.StackTrace}" +
            $"\n\n");
    }
    public async Task HandleErrorStatus(HttpContext context)  
    {
        _logger.LogDebug(
            $"--STATUSCODE:{context.Response.StatusCode}"+
            $"\n--SOURCE:{context.Request.Path}"+
            $"\n--METHOD:{context.Request.Method}"+
            $"\n\n");
    }

}