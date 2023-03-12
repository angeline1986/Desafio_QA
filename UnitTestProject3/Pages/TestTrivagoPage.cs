using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace UnitTestProject3.Pages
{
    public class TestTrivagoPage
    {
        private readonly IWebDriver Driver;
       

        public TestTrivagoPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void checkPage()
        {
            //utils = new Utils(Driver);
            String expectedTitlePage = "trivago.com.br";

            string tabTitle = Driver.Title;
            string padrao = @"(trivago\.com\.br).*";
            string extractTabletitle = Regex.Replace(tabTitle, padrao, "$1");

            Assert.AreEqual(extractTabletitle, expectedTitlePage, "Result obtained is different from the expected result.");
        }

        public void searchInfo(string itemFind)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            IWebElement inputSearch = Driver.FindElement(By.CssSelector("input#input-auto-complete"));
            inputSearch.SendKeys(itemFind);

            IWebElement confirmSearch = Driver.FindElement(By.CssSelector(".cursor-pointer:nth-child(1) .text-grey-900 .text-grey-900"));
            confirmSearch.Click();

            IWebElement initialDate = Driver.FindElement(By.CssSelector(".text-center:nth-child(1) tr:nth-child(3) > .p-0:nth-child(1) .absolute"));
            initialDate.Click();

            IWebElement finalDate = Driver.FindElement(By.CssSelector(".text-center:nth-child(2) tr:nth-child(5) > .p-0:nth-child(2) .absolute"));
            finalDate.Click();

            IWebElement buttonSearch = Driver.FindElement(By.CssSelector("button[type = 'submit']"));
            buttonSearch.Click();

            Thread.Sleep(40000);

            buttonSearch = Driver.FindElement(By.CssSelector("button[type = 'submit']"));
            buttonSearch.Click();

            Thread.Sleep(4000);

        }

        public void checkInfo()
        {
            IWebElement dropDownOrderBy = Driver.FindElement(By.CssSelector("select > option:nth-child(2)"));
            dropDownOrderBy.Click();

            IWebElement firstItem = Driver.FindElement(By.CssSelector("section:nth-child(1)"));
            string txtFirstItem = firstItem.Text;
            Console.WriteLine("First Option: " + txtFirstItem);

            IWebElement rateFirstItem = Driver.FindElement(By.CssSelector("span.space-x-1.flex.text-m"));
            string txtRateFirstItem = rateFirstItem.Text;
            Console.Write("Rating Firts Option: " + txtRateFirstItem);

            IWebElement priceFirstItem = Driver.FindElement(By.CssSelector("em.PricePerStay_formattedPrice__uIcBf"));
            string txtPriceFirstItem = priceFirstItem.Text;
            Console.WriteLine("Price Firts Option: " + txtPriceFirstItem);

            Assert.AreEqual(txtFirstItem, "Hotel Express Vieiralves", "Result obtained is different from the expected result.");
            Assert.AreEqual(txtRateFirstItem, "7.6\r\nBom (979 avaliações)", "Result obtained is different from the expected result.");
            Assert.AreEqual(txtPriceFirstItem, "R$ 7.122", "Result obtained is different from the expected result.");

        }

    }
}
