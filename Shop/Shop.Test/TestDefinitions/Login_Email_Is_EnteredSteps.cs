using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class Login_Email_Is_EnteredSteps : TestBase
    {
        private readonly LoginViewModel _loginModel;
        private ViewResult _result;
        private readonly AccountController _sut;

        public Login_Email_Is_EnteredSteps()
        {
            _sut = AccountController;
            _loginModel = new LoginViewModel();
        }

        [Given(@"User enter username (.*)")]
        public void GivenUserEnterUsernameTestuser_(string username)
        {
            _loginModel.Email = username;
        }
        
        [When(@"Click on the LogIn button, when password is not entered")]
        public void WhenClickOnTheLogInButtonWhenPasswordIsNotEntered()
        {
            _sut.ModelState.AddModelError("test", "test");

            _result = _sut.Login(_loginModel, "returnurl").Result as ViewResult;
        }
        
        [Then(@"Login was not processed without password")]
        public void ThenLoginWasNotProcessedWithoutPassword()
        {
            Assert.AreEqual(_result.ViewName, "Login");
        }
    }
}
