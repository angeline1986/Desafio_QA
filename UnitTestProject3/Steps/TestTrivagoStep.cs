using System;
using TechTalk.SpecFlow;
using UnitTestProject3.Pages;

namespace UnitTestProject3.Steps
{
    [Binding]
    public sealed class TestTrivagoStep
    {
        private readonly DriverHelper _driverHelper;
        private readonly TestTrivagoPage testTrivagoPage;

        public TestTrivagoStep(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            testTrivagoPage = new TestTrivagoPage(_driverHelper.Driver);
        }

        [Given(@"that I access the Trivago website")]
        public void GivenThatIAccessTheTrivagoWebsite()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://www.trivago.com.br");
            testTrivagoPage.checkPage();
        }


        [When(@"I look for (.*)")]
        public void WhenILookFor(string itemSearch)
        {
            string textItemSearch = itemSearch.Replace("<", "").Replace(">", "");
            testTrivagoPage.searchInfo(textItemSearch);
        }


        [Then(@"I check the information of the first item")]
        public void ThenICheckTheInformationOfTheFirstItem()
        {
            testTrivagoPage.checkInfo();
        }

    }
}
