using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TSBTest.PageObjects
{
    public class ListItemPage
    {
        private IWebDriver driver;

        public IWebElement ListItemHeading => driver.FindElement(By.ClassName("mp-value-category-content"));
        public IWebElement ListingTitleTextBox => driver.FindElement(By.Id("listing-title"));
        public IWebElement BrowseAllCategoriesLink => driver.FindElement(By.CssSelector(".browse-categories.last"));
        public SelectElement FirstCategoryOptionSelect => new SelectElement(driver.FindElement(By.Id("selector_0")));
        public SelectElement SecondCategoryOptionSelect => new SelectElement(driver.FindElement(By.Id("selector_1")));
        public SelectElement ThirdCategoryOptionSelect => new SelectElement(driver.FindElement(By.Id("selector_2")));
        public SelectElement FourthCategoryOptionSelect => new SelectElement(driver.FindElement(By.Id("selector_3")));
        public IWebElement ListOneCategoryRadio => driver.FindElement(By.Id("one-category-radio"));
        public IWebElement ListItemFirstNextButton => driver.FindElement(By.Id("submit_button"));
        public IWebElement DescriptionTextArea => driver.FindElement(By.TagName("textarea"));
        public IWebElement ListItemSecondNextButton => driver.FindElement(By.Id("submit1"));
        public IWebElement ListItemThirdNextButton => driver.FindElement(By.Id("submit1"));
        public IWebElement StartPriceTextBox => driver.FindElement(By.Id("startPriceInput"));
        public IWebElement ShippingRadioButton => driver.FindElement(By.Id("deliveryIdk"));
        public IWebElement ListItemFourthNextButton => driver.FindElement(By.Id("submit1"));
        public IWebElement CashPaymentCheckbox => driver.FindElement(By.Id("payment_cash_on_pickup"));
        public IWebElement ContinueUploadButton => driver.FindElement(By.Id("ContinueUpload"));
        public IWebElement BasicListingButton => driver.FindElement(By.Id("basic-selector"));
        public IWebElement ListItemFifthNextButton => driver.FindElement(By.Id("promo-submit"));
        public IWebElement StartAuctionButton => driver.FindElement(By.Id("submit_sell"));
        public IWebElement PageText => driver.FindElement(By.TagName("tbody"));

        public ListItemPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetListItemPageHeadingText()
        {
            return ListItemHeading.Text;
        }

        public void EnterListingTitle(string listingTitle)
        {
            ListingTitleTextBox.Clear();
            ListingTitleTextBox.SendKeys(listingTitle);
            ListingTitleTextBox.SendKeys(Keys.Tab);
        }

        public void ListItem(string itemDescription, string startPrice)
        {
            BrowseAllCategoriesLink.Click();
            FirstCategoryOptionSelect.SelectByText("Mobile phones >");
            SecondCategoryOptionSelect.SelectByText("Mobile phones >");
            ThirdCategoryOptionSelect.SelectByText("iPhone >");
            FourthCategoryOptionSelect.SelectByText("iPhone 6s");
            ListOneCategoryRadio.Click();
            ListItemFirstNextButton.Click();
            DescriptionTextArea.SendKeys(itemDescription);
            ListItemSecondNextButton.Click();
            StartPriceTextBox.SendKeys(startPrice);
            ListItemThirdNextButton.Click();
            ShippingRadioButton.Click();
            CashPaymentCheckbox.Click();
            ListItemFourthNextButton.Click();
            ContinueUploadButton.Click();
            BasicListingButton.Click();
            ListItemFifthNextButton.Click();
            StartAuctionButton.Click();
        }

        public string GetPageText()
        {
            return PageText.Text;
        }
    }
}
