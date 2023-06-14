using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (dateOfBirthClaim is null)
                return Task.CompletedTask;

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);

            var yearOldUser = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-yearOldUser))
                yearOldUser--;

            if (yearOldUser >= requirement.Idade)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
