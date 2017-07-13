using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using Shop.Controllers;
using Shops.DAL.Entities;

namespace Shop.Test
{
    public class TestBase
    {
        protected AccountController AccountController
        {
            get
            {
                var userStore = new Mock<IUserStore<ApplicationUser>>();
                var userManager = new Mock<ApplicationUserManager>(userStore.Object);
                var authenticationManager = new Mock<IAuthenticationManager>();
                var signInManager =
                    new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);
                var accountController = new AccountController(
                    userManager.Object, signInManager.Object);
                return accountController;
            }
        }
    }
}
