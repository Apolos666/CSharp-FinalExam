namespace CSharp_FinalExam.Infrastructure.CustomMiddleware;

public class AccessDeniedRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public AccessDeniedRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        
        if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            context.Response.Redirect("/error/access-denied");
        }
    }
}