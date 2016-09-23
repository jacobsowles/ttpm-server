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

        public virtual ICollection<TaskGroup> TaskGroups { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }

        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}