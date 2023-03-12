using NUnit.Framework;
using OpenQA.Selenium;
using System;
using UnitTestProject3.Models;

namespace UnitTestProject3.Pages
{
    public class TestCorreiosPage
    {
        private readonly IWebDriver Driver;
        private Utils utils;


        public TestCorreiosPage(IWebDriver driver)
        {
            Driver = driver;
            utils = new Utils(driver);
        }

        
        public void AccessCepSearch()
        {
            utils = new Utils(Driver);

            string pageTitleText = utils.GetTextByCssSelector("#titulo_tela > h2");
            Assert.AreEqual("Busca CEP", pageTitleText, "Result obtained is different from the expected result.");
        }

        public void InputZipCode(string zipCode)
        {
            IWebElement inputZipCode = Driver.FindElement(By.Id("endereco"));
            IWebElement btnSearch = Driver.FindElement(By.ClassName("botoes"));

            inputZipCode.SendKeys(zipCode);
            btnSearch.Click();
        }

        public void DataReturn(string itemSearch, string street, string neighborhood, string state)
        {
            utils = new Utils(Driver);
            string resultStreet = "";

            resultStreet = utils.GetTextByCssSelector("#resultado-DNEC td:nth-child(1)");

            if (itemSearch == "Lojas Bemol")
            {
                resultStreet = resultStreet.Replace("\r\n", " ");
            }

            string resultNeighborhood = utils.GetTextByCssSelector("#resultado-DNEC td:nth-child(2)");
            string resultState = utils.GetTextByCssSelector("#resultado-DNEC td:nth-child(3)");

            Assert.AreEqual(street, resultStreet, "Result obtained is different from the expected result.");
            Assert.AreEqual(neighborhood, resultNeighborhood, "Result obtained is different from the expected result.");
            Assert.AreEqual(state, resultState, "Result obtained is different from the expected result.");

            Console.WriteLine("Data found: " + resultStreet+ " - " +resultNeighborhood + " - " + resultState);
           
            IWebElement btnNewSearch = Driver.FindElement(By.Id("btn_nbusca"));
            btnNewSearch.Click();
        }

      

    }
}
