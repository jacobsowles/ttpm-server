using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInService : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInService(ApplicationUserService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserService) UserManager);
        }

        public static ApplicationSignInService Create(IdentityFactoryOptions<ApplicationSignInService> options, IOwinContext context)
        {
            return new ApplicationSignInService(context.GetUserManager<ApplicationUserService>(), context.Authentication);
        }
    }
}