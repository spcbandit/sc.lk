using System.Net;
using System.Text;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SC.LK.Application.Abstractions.Logging;

namespace SC.LK.Infrastructure.Logger.Middleware;

public class ExceptionHandlerMw
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlerMw(RequestDelegate next, ILogger<ExceptionHandlerMw> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            LogRequest(context);
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }
    
    private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)  
    {  
        int statusCode = (int)HttpStatusCode.InternalServerError;  
        var result = JsonConvert.SerializeObject(new  
        {  
            Type = "ERROR",
            Message = new {
                StatusCode = statusCode,  
                Error = exception.Message,
                exception.StackTrace
            }
        });
        
        _logger.LogError(result);
        context.Response.ContentType = "application/json";  
        context.Response.StatusCode = statusCode;  
        return context.Response.WriteAsync(result);  
    }
    public async Task<string> GetRequestBodyAsync(HttpRequest request)
    {
        string strRequestBody = string.Empty;
        HttpRequestRewindExtensions.EnableBuffering(request);
        using (StreamReader reader = new StreamReader(
                   request.Body,
                   Encoding.UTF8,
                   detectEncodingFromByteOrderMarks: false,
                   leaveOpen: true))
        {
             strRequestBody = await reader.ReadToEndAsync();
            request.Body.Position = 0;
        }
        return strRequestBody;
    }
    private void LogRequest(HttpContext context)
    {
        var message = new
        {
            Body = GetRequestBodyAsync(context.Request),
            context.Request.Headers,
            context.Request.Cookies,
            context.Request.Query,
            context.Request.Path,
            context.Request.Method,
        };
        _logger.LogInformation(JsonConvert.SerializeObject(new {Type = "REQUEST", message}));
    }
}   
