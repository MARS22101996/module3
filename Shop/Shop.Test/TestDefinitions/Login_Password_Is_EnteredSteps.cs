using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class Login_Password_Is_EnteredSteps : TestBase
    {
        private readonly LoginViewModel _loginModel;
        private ViewResult _result;
        private readonly AccountController _sut;

        public Login_Password_Is_EnteredSteps()
        {
            _sut = AccountController;
            _loginModel = new LoginViewModel();
        }

        [Given(@"User enter password (.*)")]
        public void GivenUserEnterPasswordTest(string password)
        {
            _loginModel.Password = password;
        }
        
        [When(@"Click on the button for log in, when email is not entered")]
        public void WhenClickOnTheButtonForLogInWhenEmailIsNotEntered()
        {
            _sut.ModelState.AddModelError("test", "test");

            _result = _sut.Login(_loginModel, "returnurl").Result as ViewResult;
        }
        
        [Then(@"Login was not processed without email")]
        public void ThenLoginWasNotProcessedWithoutEmail()
        {
            Assert.AreEqual(_result.ViewName, "Login");
        }
    }
}
