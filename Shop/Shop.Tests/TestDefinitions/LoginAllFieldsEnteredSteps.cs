using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class LoginAllFieldsEnteredSteps
    {
        private LoginViewModel _loginModel = new LoginViewModel();
        private ActionResult _result;

        [Given(@"User enters testuser_(.*) and Test@(.*)")]
        public void GivenUserEntersTestuser_AndTest(int p0, int p1)
        {
            _loginModel.Email = "test.@mail.ru";
            _loginModel.Password = "123455";
        }
        
        [When(@"Click on the LogIn button, when all fields are entered")]
        public void WhenClickOnTheLogInButtonWhenAllFieldsAreEntered()
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


            _result = accountController.Login(_loginModel, null).Result;

        }
        
        [Then(@"Successful Log in")]
        public void ThenSuccessfulLogIn()
        {
            Assert.IsInstanceOfType(_result, typeof(RedirectToRouteResult));
        }
    }
}
