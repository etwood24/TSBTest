using System;
using OpenQA.Selenium;

namespace TSBTest.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        public IWebElement LoginButton => driver.FindElement(By.Id("LoginLink"));
        public IWebElement LoggedInState => driver.FindElement(By.Id("NotLoggedInDiv"));
        public IWebElement LoggedInUserName => driver.FindElement(By.CssSelector("div.login-area > div > form > p"));
        public IWebElement SellMenuFlyout => driver.FindElement(By.Id("SiteHeader_SiteTabs_sellLink"));
        public IWebElement ListGeneralItemMenuLink => driver.FindElement(By.Id("SiteHeader_SiteTabs_sellGeneralItem"));


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }

        public LoginPage NavigateToLoginPage(string baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl);
            LoginButton.Click();
            return new LoginPage(driver);   
        }

        public string GetLoggedInUserName()
        {
            return LoggedInUserName.Text;
        }

        public void ClickCategoryLink(string catagory)
        {
            driver.FindElement(By.LinkText(catagory)).Click();
        }

        public ListItemPage NavigateToListGeneralItemPage()
        {
            //driver.Navigate().GoToUrl(baseUrl);
            SellMenuFlyout.Click();
            ListGeneralItemMenuLink.Click();
            return new ListItemPage(driver);
        }
    }
}
