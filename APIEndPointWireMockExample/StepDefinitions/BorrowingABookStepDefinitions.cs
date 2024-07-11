using APIEndPointWireMockExample.Models;
using APIEndPointWireMockExample.Support;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace APIEndPointWireMockExample.StepDefinitions
{
    [Binding]
    public class BorrowingABookStepDefinitions : BaseSteps
    {
        int bookId = 1;
        int userId = 1;
        public BorrowingABookStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper): base(specFlowOutputHelper) { }

        [Given(@"a book is available")]
        public async Task GivenABookIsAvailable()
        {
            // ensure the book is available (handled by WireMock)
            string urlIsAvailable = BaseUrl + _checkStatusBookEP;
            urlIsAvailable = urlIsAvailable.Replace("{bookId}", bookId.ToString());
            _response = await _httpClient.GetAsync(urlIsAvailable);
            responsebody = await _response.Content.ReadAsStringAsync();
            var jsResponse = JsonConvert.DeserializeObject<BookStatusResponse>(responsebody);
            var status = jsResponse.Status;
            ClassicAssert.AreEqual(status, "available");
        }

        [When(@"a user borrows the book")]
        public async Task WhenAUserBorrowsTheBook()
        {
            var jsonObject = new JObject
            {
                { "bookId", bookId },
                { "userId", userId }
            };
            var jsonContent = jsonObject.ToString();
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync($"{BaseUrl}{_borrowingABookEP}", content);
            responsebody = await _response.Content.ReadAsStringAsync();
        }

        [Then(@"the book status should be ""([^""]*)""")]
        public void ThenTheBookStatusShouldBe(string borrowed)
        {
            var responseObject = JObject.Parse(responsebody); // Deserialize without a specific class
            var message = responseObject["message"].ToString(); // Access status dynamically
            ClassicAssert.AreEqual(borrowed, message);
        }
    }
}
