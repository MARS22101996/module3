using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using Shop.Controllers;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test
{
    public class TestBase
    {
        protected AccountController GetAccountController()
        {

            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                 userManager.Object, signInManager.Object);
            return accountController;
        }
    }
}
