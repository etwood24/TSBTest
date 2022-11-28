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
    public class SearchTests
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

    }
}
