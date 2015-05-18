using GoldenGateShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace GoldenGateShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}
