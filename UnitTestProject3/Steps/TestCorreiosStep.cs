using System;
using TechTalk.SpecFlow;
using UnitTestProject3.Pages;

namespace UnitTestProject3.Steps
{
    [Binding]
    public class TestCorreiosStep
    { 
        private readonly DriverHelper _driverHelper;
        private readonly TestCorreiosPage testCorreiosPage;

        public TestCorreiosStep(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            testCorreiosPage = new TestCorreiosPage(_driverHelper.Driver);
        }



        [Given(@"I access the CEP Search on the Correios website")]
        public void GivenIAccessTheCEPSearchOnTheCorreiosWebsite()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://www.buscacep.correios.com.br");
            testCorreiosPage.AccessCepSearch();
        }

        [When(@"I enter zip code I get address")]
        public void WhenIEnterZipCodeIGetAddress(Table table)
        {
            var data = table.Rows;
            foreach (var tableRow in data)
            {
                var dataSearch = tableRow[0];
                var dataAddress = tableRow[1];
                var dataNeighborhood = tableRow[2];
                var dataState = tableRow[3];

                testCorreiosPage.InputZipCode(dataSearch);
                Console.WriteLine("Searched value: " + tableRow[0]);

                testCorreiosPage.DataReturn(dataSearch,dataAddress, dataNeighborhood, dataState);
            }
        }

    }
}
