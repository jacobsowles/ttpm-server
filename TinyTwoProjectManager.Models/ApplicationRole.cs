using Microsoft.AspNet.Identity.EntityFramework;

namespace TinyTwoProjectManager.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string name) : base(name)
        {
        }
    }
}