using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace APIEndPointWireMockExample.StepDefinitions
{
    [Binding]
    public class CheckingBookStatusStepDefinitions : BaseSteps
    {
        int bookId;
        string status;

        public CheckingBookStatusStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper) : base(specFlowOutputHelper) { }

        [Given(@"a book (.*) has been borrowed")]
        public void GivenABookHasBeenBorrowed(int bookId)
        {
            this.bookId = bookId;
        }

        [When(@"the status is checked")]
        public async Task WhenTheStatusIsChecked()
        {
            var url = getFullApiCheckStatusBook().Replace("{bookId}", bookId.ToString());
            _response = await _httpClient.GetAsync(url);
            responsebody = await _response.Content.ReadAsStringAsync();
            Assert.That(verifyOKStatus(_response), Is.True);
            var jsonBody = JObject.Parse(responsebody);
            status = jsonBody["status"].ToString();
        }

        [Then(@"the status should be ""([^""]*)""")]
        public void ThenTheStatusShouldBe(string expectedStatus)
        {
            Assert.That(status, Is.EqualTo(expectedStatus));
        }

        [Given(@"a book (.*) has been available")]
        public void GivenABookHasBeenAvailable(int bookId)
        {
            this.bookId = bookId;
        }
    }
}
