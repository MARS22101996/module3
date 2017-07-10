using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Controllers;
using Shop.Models;
using System.Web.Mvc;
using TechTalk.SpecFlow;


namespace Shop.Tests.TestDefinitions
{
    [Binding]
    public class LoginEmailEnteredSteps
    {
        private LoginViewModel _loginModel = new LoginViewModel();
        private ViewResult _result;

        [Given(@"User enter testuser_(.*)")]
        public void GivenUserEnterTestuser_(string username)
        {
            _loginModel.Email = "test.@mail.ru";
        }
        
        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            var accountController = new AccountController(
                userManager.Object, signInManager.Object);

            var loginModel = new LoginViewModel { Email = "test.@mail.ru" };

            accountController.ModelState.AddModelError("test", "test");

            _result = accountController.Login(_loginModel, "returnurl").Result as ViewResult;
        }

        [Then(@"Login was not processed")]
        public void ThenLoginWasNotProcessed()
        {
            Assert.AreEqual(_result.ViewName, "Login");
        }
    }
}
