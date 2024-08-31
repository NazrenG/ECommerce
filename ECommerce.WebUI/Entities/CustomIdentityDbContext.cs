using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebUI.Entities
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
