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

        switch (context.Response.StatusCode)
        {
            case StatusCodes.Status401Unauthorized:
                context.Response.Redirect("/authenticate/login-view");
                break;
            case StatusCodes.Status403Forbidden:
                context.Response.Redirect("/error/access-denied");
                break;
        }
    }
}