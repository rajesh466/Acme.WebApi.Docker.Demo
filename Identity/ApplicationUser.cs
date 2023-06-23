using Microsoft.AspNetCore.Identity;

namespace Acme.WebApi.Docker.Demo.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }

    }
}
