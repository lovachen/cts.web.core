using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cts.web.core.Jwt
{
    public class ValidJtiHandler : AuthorizationHandler<ValidJtiRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidJtiRequirement requirement)
        {

            context.Fail();

            return Task.CompletedTask;
        }
    }
}
