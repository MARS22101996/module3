using Shop.Controllers;
using Microsoft.AspNet.Identity;
using System.Web;
using Moq;
using Shop.Models;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.IO;
using System.Security.Principal;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Routing;
using Shop;

namespace Shop.Tests
{
    [TestFixture]
    public class UnitTest1
    {

   
        [Test]
        public void GET__Login_UserLoggedIn_Failed()
        {
            // Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                userManager.Object, signInManager.Object);

            var loginModel = new LoginViewModel { Email = "test.@mail.ru" };

            accountController.ModelState.AddModelError("test", "test");
            // Act
            var result = accountController.Login(loginModel, "returnurl").Result as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "Login");
        }

       
        [Test]
        public void GET__Login_UserLoggedIn_RedirectsToHomeIndex()
        {
            // Arrange
            var userStore = new Mock<UserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                userManager.Object, signInManager.Object)
            {
            };

            var loginModel = new LoginViewModel { Email = "mariasuvalova96@gmail.com", Password = "Riama_221012" };

            // Act
            var result = accountController.Login(loginModel, null).Result;

            Assert.That(result, Is.TypeOf<RedirectToRouteResult>());
        }

        [Test]
        public void GET__Register_UserLoggedIn_RedirectsToHomeIndex()
        {
            // Arrange
            HttpContext.Current = CreateHttpContext(userLoggedIn: true);
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                userManager.Object, signInManager.Object);

            // Act
            var result = accountController.Register();

            // Assert
            NUnit.Framework.Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void GET__Register_UserLoggedOut_ReturnsView()
        {
            // Arrange
            HttpContext.Current = CreateHttpContext(userLoggedIn: false);
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                userManager.Object, signInManager.Object);

            // Act
            var result = accountController.Register();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        private static HttpContext CreateHttpContext(bool userLoggedIn)
        {
            var httpContext = new HttpContext(
                new HttpRequest(string.Empty, "http://sample.com", string.Empty),
                new HttpResponse(new StringWriter())
            )
            {
                User = userLoggedIn
                    ? new GenericPrincipal(new GenericIdentity("userName"), new string[0])
                    : new GenericPrincipal(new GenericIdentity(string.Empty), new string[0])
            };

            return httpContext;
        }
    }
}
