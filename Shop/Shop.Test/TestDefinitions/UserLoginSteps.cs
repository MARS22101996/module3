using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class UserLoginSteps : TestBase
    {
        private readonly LoginViewModel _loginModel;
        private ActionResult _resultSuccess;
        private ViewResult _resultFail;
        private readonly AccountController _sut;

        public UserLoginSteps()
        {
            _sut = AccountController;
            _loginModel = new LoginViewModel();
        }

        [Given(@"User enters peronal username (.*) and password  (.*)")]
        public void GivenUserEntersPeronalUsernameTestuser_AndPasswordTest(string email, string password)
        {
            _loginModel.Email = email;
            _loginModel.Password = password;
        }

        [Given(@"User enter personal username (.*)")]
        public void GivenUserEnterPersonalUsernameTestuser_(string email)
        {
            _loginModel.Email = email;
        }

        [Given(@"User enter personal password (.*)")]
        public void GivenUserEnterPersonalPasswordTest(string password)
        {
            _loginModel.Password = password;
        }

        [When(@"Click on the LogIn button, when one field is not entered")]
        public void WhenClickOnTheLogInButtonWhenOneFieldIsNotEntered()
        {
            _sut.ModelState.AddModelError("test", @"test");

            _resultFail = _sut.Login(_loginModel, "returnurl").Result as ViewResult;
        }

        [When(@"Click on the LogIn button, when all fields are entered")]
        public void WhenClickOnTheLogInButtonWhenAllFieldsAreEntered()
        {
            _resultSuccess = _sut.Login(_loginModel, "returnurl").Result;
        }

        [Then(@"Login was not processed and user stay at the Login page")]
        public void ThenLoginWasNotProcessedAndUserStayAtTheLoginPage()
        {
            Assert.AreEqual(_resultFail.ViewName, "Login");
        }

        [Then(@"Successful Log in")]
        public void ThenSuccessfulLogIn()
        {
            Assert.IsInstanceOfType(_resultSuccess, typeof(RedirectToRouteResult));
        }
    }
}