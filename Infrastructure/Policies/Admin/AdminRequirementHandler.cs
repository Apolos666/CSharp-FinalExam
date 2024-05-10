using Microsoft.AspNetCore.Authorization;

namespace CSharp_FinalExam.Infrastructure.Policies.Admin;

public class AdminRequirementHandler : AuthorizationHandler<AdminRequirements>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirements requirement)
    {
        
        var claims = context.User.Claims;
        return Task.CompletedTask;
    }
}