using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TSBTest.Utils
{
    public class DriverSetup
    {
        public DriverSetup()
        {
        }

        public IWebDriver SetupDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}
