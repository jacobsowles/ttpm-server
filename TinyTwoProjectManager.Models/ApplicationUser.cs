using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TinyTwoProjectManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}