using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TinyTwoProjectManager.Models
{
    public class ApplicationRole : IdentityRole
    {
        public DateTime DateCreated { get; set; }

        public ApplicationRole()
        {
            DateCreated = DateTime.Now;
        }

        public ApplicationRole(string name) : base(name)
        {
        }
    }
}