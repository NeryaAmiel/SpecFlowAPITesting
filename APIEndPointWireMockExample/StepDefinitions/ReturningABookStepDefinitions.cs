using APIEndPointWireMockExample.Support;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Net.Http.Json;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace APIEndPointWireMockExample.StepDefinitions
{    
    [Binding]
    public class ReturningABookStepDefinitions : BaseSteps
    {
        int bookId;
        int userId;
        public ReturningABookStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper) : base(specFlowOutputHelper) { }

        [Given(@"a borrowed book id (.*) and userId (.*)")]
        public async Task GivenABorrowedBookIdAndUserId(int bookId, int userId)
        {
            this.bookId = bookId;
            this.userId = userId;
            //verify the book is Borrowed
            string urlIsAvailable = BaseUrl + _checkStatusBookEP;
            urlIsAvailable = urlIsAvailable.Replace("{bookId}", bookId.ToString());
            _response = await _httpClient.GetAsync(urlIsAvailable);
            responsebody = await _response.Content.ReadAsStringAsync();
            var jsResponse = JsonConvert.DeserializeObject<BookStatusResponse>(responsebody);
            var status = jsResponse.Status;
            ClassicAssert.AreEqual(status, "borrowed");
            _specFlowOutputHelper.WriteLine($"bookId: {bookId} is borrowed");
        }



        [When(@"a user Returns the book")]
        public async Task WhenAUserReturnsTheBook()
        {
            var reqbodyJson = new JObject()
            {
                {"bookId" , bookId },
                {"userId" , userId }
            };
            var content = new StringContent(reqbodyJson.ToString(), Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync(getFullApiReturningABook(), content);
            responsebody = await _response.Content.ReadAsStringAsync();
        }

        [Then(@"the message should be ""([^""]*)""")]
        public void ThenTheMessageShouldBe(string massage)
        {
            var massageJson = JObject.Parse(responsebody);
            var responseMassage = massageJson["message"].ToString();
            Assert.That(responseMassage, Is.EqualTo(massage));
        }
    }
}
