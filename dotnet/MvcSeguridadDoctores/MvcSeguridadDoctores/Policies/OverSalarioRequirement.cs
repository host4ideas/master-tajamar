using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MvcSeguridadDoctores.Policies
{
    public class OverSalarioRequirement : AuthorizationHandler<OverSalarioRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OverSalarioRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == "SALARIO") == false)
            {
                context.Fail();
            }
            else
            {
                string data = context.User.FindFirstValue("SALARIO");
                int salario = int.Parse(data);

                if (salario >= 220000)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
}
