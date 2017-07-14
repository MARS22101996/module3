using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Models;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class UserRegisterSteps : TestBase
    {
        private readonly RegisterViewModel _registerModel;
        private ActionResult _resultSuccess;
        private ViewResult _resultFail;
        private readonly AccountController _sut;

        public UserRegisterSteps()
        {
            _sut = AccountController;
            _registerModel = new RegisterViewModel();
        }

        [Given(@"User enter phone number (.*)")]
        public void GivenUserEnterPhoneNumber(string phonenumber)
        {
            _registerModel.MobilePhone = phonenumber;
        }

        [When(@"Click on the Registration button, when phone number has a valid format")]
        public void WhenClickOnTheRegistrationButtonWhenPhoneNumberHasAValidFormat()
        {
            _resultSuccess = _sut.Register(_registerModel).Result;
        }

        [When(@"Click on the Registration button, when phone number does not have a valid format")]
        public void WhenClickOnTheRegistrationButtonWhenPhoneNumberDoesNotHaveAValidFormat()
        {
            _sut.ModelState.AddModelError("test", @"test");

            _resultFail = _sut.Register(_registerModel).Result as ViewResult;
        }

        [Then(@"Successful Registration")]
        public void ThenSuccessfulRegistration()
        {
            Assert.IsInstanceOfType(_resultSuccess, typeof(RedirectToRouteResult));
        }

        [Then(@"Failed Registration")]
        public void ThenFailedRegistration()
        {
            Assert.AreEqual(_resultFail.ViewName, "Register");
        }
    }
}