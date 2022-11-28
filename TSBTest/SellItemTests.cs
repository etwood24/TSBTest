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
    public class SellItemTests
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
        public void ListItemToSell()
        {
            var HomePage = new HomePage(_driver);
            var LoginPage = HomePage.NavigateToLoginPage(_baseUrl);
            LoginPage.LogIn("etwood@gmail.com", "TSBTestingEvan123!");
            var ListItemPage = HomePage.NavigateToListGeneralItemPage();
            Assert.IsTrue(ListItemPage.GetListItemPageHeadingText().Contains("Get it sold on Kiwis' trusted marketplace."));
            ListItemPage.EnterListingTitle("iPhone 6S");
            ListItemPage.ListItem("iPhone 6S", "200");
            Assert.IsTrue(ListItemPage.GetPageText().Contains("Your auction has started."));
        }
    }
}
