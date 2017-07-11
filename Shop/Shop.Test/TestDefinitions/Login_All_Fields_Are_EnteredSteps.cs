using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using System;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Shop.Test
{
    [Binding]
    public class Login_All_Fields_Are_EnteredSteps : TestBase
    {
        private LoginViewModel _loginModel = new LoginViewModel();
        private ActionResult _result;
        private AccountController _sut;

        public Login_All_Fields_Are_EnteredSteps()
        {
            _sut = GetAccountController();
        }

        [Given(@"User enters username (.*) and password  (.*)")]
        public void GivenUserEntersUsernameTestuser_AndPasswordTest(string password, string email)
        {
            _loginModel.Email = email;
            _loginModel.Password = password;
        }
        
        [When(@"Click on the LogIn button, when all fields are entered")]
        public void WhenClickOnTheLogInButtonWhenAllFieldsAreEntered()
        {
            _result = _sut.Login(_loginModel, "returnurl").Result;
        }
        
        [Then(@"Successful Log in")]
        public void ThenSuccessfulLogIn()
        {
            Assert.IsInstanceOfType(_result, typeof(RedirectToRouteResult));
        }
    }
}
