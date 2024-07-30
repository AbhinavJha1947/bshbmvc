using Microsoft.AspNetCore.Authorization;

namespace BiharStateHousingBoard.Models
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public RoleRequirement(string role)
        {
            Role = role;
        }
    }
}
