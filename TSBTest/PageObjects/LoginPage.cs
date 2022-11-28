using System;
using OpenQA.Selenium;

namespace TSBTest.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public IWebElement EmailTextbox => driver.FindElement(By.Id("Email"));
        public IWebElement PasswordTextbox => driver.FindElement(By.Id("Password"));
        public IWebElement RememberMeCheckbox => driver.FindElement(By.ClassName("form-group-checkbox-input__checkbox-text"));
        public IWebElement SignInButton => driver.FindElement(By.Id("SignIn"));
        public IWebElement PageHeadingText => driver.FindElement(By.ClassName("login-text"));
        public IWebElement ValidationError => driver.FindElement(By.ClassName("validation-summary-errors"));
        public IWebElement FieldValidationError => driver.FindElement(By.ClassName("field-validation-error"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogIn(String username, String password)
        {
            EmailTextbox.Clear();
            EmailTextbox.SendKeys(username);
            PasswordTextbox.Clear();
            PasswordTextbox.SendKeys(password);
            SignInButton.Click();
        }

        public string GetPageHeading()
        {
            return PageHeadingText.Text;
        }

        public string GetValidationErrorText()
        {
            return ValidationError.Text;
        }

        public string GetFieldValidationErrorText()
        {
            return FieldValidationError.Text;
        }
    }
}
