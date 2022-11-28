using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TSBTest.PageObjects;
using TSBTest.Utils;
using OpenQA.Selenium;

namespace TSBTest
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver _driver;
        private string _baseUrl = "https://www.tmsandbox.co.nz/";

        [TestInitialize]
        public void SetupTest()
        {
            _driver = new DriverSetup().SetupDriver();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            _driver.Quit();
        }


        [TestMethod]
        public void LoginWithValidCredentialsSucceeds()
        {
            var HomePage = new HomePage(_driver);
            var LoginPage = HomePage.NavigateToLoginPage(_baseUrl);
            Assert.AreEqual("Log in", LoginPage.GetPageHeading());
            LoginPage.LogIn("etwood@gmail.com", "TSBTestingEvan123!");
            Assert.IsTrue(HomePage.GetLoggedInUserName().Contains("Evantest"));
        }

        [TestMethod]
        public void LoginWithInvalidCredentialsFails()
        {
            var HomePage = new HomePage(_driver);
            var LoginPage = HomePage.NavigateToLoginPage(_baseUrl);
            Assert.AreEqual("Log in", LoginPage.GetPageHeading());
            LoginPage.LogIn("blahblah@test.com", "blahblah123!");
            Assert.AreEqual("Invalid email or password", LoginPage.GetValidationErrorText());
        }

        [TestMethod]
        public void VerifyEmailAddressRequired()
        {
            var HomePage = new HomePage(_driver);
            var LoginPage = HomePage.NavigateToLoginPage(_baseUrl);
            Assert.AreEqual("Log in", LoginPage.GetPageHeading());
            LoginPage.LogIn("etwood@gmail.com", "");
            Assert.AreEqual("This field is required", LoginPage.GetFieldValidationErrorText());
        }

        [TestMethod]
        public void VerifyPasswordRequired()
        {
            var HomePage = new HomePage(_driver);
            var LoginPage = HomePage.NavigateToLoginPage(_baseUrl);
            Assert.AreEqual("Log in", LoginPage.GetPageHeading());
            LoginPage.LogIn("", "TSBTestingEvan123!");
            Assert.AreEqual("This field is required", LoginPage.GetFieldValidationErrorText());
        }
    }
}
