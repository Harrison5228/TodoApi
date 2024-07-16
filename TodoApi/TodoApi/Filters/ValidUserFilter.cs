using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoApi.Services.Interfaces;

namespace TodoApi.Filters;

public class ValidUserFilter(ISessionService sessionService) : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var skipValidation = context.ActionDescriptor.EndpointMetadata
            .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
        
        if(string.IsNullOrEmpty(sessionService.GetSessionUser()) && !skipValidation)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
