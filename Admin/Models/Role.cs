using Microsoft.AspNetCore.Identity;

namespace Admin.Models
{
    public class Role
    {
        public static string[] Roles { get; set; } = new string[] { "Admin", "Agent" };
    }
}