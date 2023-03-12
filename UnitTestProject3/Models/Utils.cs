using OpenQA.Selenium;


namespace UnitTestProject3.Models
{
    public class Utils
    {
        private readonly IWebDriver Driver;

        public Utils(IWebDriver driver)
        {
            Driver = driver;
        }

        public string GetTextByCssSelector(string cssSelector)
        {
            IWebElement resultElement = Driver.FindElement(By.CssSelector(cssSelector));
            return resultElement.Text;
        }

    }
}
