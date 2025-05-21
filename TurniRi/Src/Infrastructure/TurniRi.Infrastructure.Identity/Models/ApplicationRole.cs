using System;
using Microsoft.AspNetCore.Identity;

namespace TurniRi.Infrastructure.Identity.Models
{
    public class ApplicationRole(string name) : IdentityRole<Guid>(name)
    {
    }
}
