using Microsoft.AspNetCore.Identity;

namespace Admin.Models
{
    public class Role : IdentityRole<int>
    {
        public static string[] Roles { get; set; } = new string[] { "Admin", "Agent", "Benificer" };
    }
}