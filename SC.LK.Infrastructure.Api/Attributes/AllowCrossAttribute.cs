using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SC.LK.Infrastructure.Api.Attributes;

using System;
using System.Web.Http.Filters;

public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");

        base.OnActionExecuted(actionExecutedContext);
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class AllowCors : ActionFilterAttribute
{
    public string Headers { get; set; }
    public string Methods { get; set; }
    public string Origins { get; set; }
    
    public AllowCors(string headers, string methods, string origins)
    {
        Headers = headers;
        Origins = origins;
        Methods = methods;
    }
    public override void OnActionExecuting(HttpActionContext actionExecutedContext)
    {
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", Origins);
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", Methods);
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", Headers);

        base.OnActionExecuting(actionExecutedContext);
    }
    
}