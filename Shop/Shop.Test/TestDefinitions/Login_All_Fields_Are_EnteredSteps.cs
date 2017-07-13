using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class Login_All_Fields_Are_EnteredSteps : TestBase
    {
        private readonly LoginViewModel _loginModel;
        private ActionResult _result;
        private readonly AccountController _sut;

        public Login_All_Fields_Are_EnteredSteps()
        {
            _sut = AccountController;
            _loginModel = new LoginViewModel();
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
