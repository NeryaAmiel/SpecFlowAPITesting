using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace APIEndPointWireMockExample.StepDefinitions
{
    public class BaseSteps
    {
        protected readonly HttpClient _httpClient;
        protected HttpResponseMessage _response;
        protected const string BaseUrl = "http://localhost:8080";
        protected String responsebody;
        protected readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        // Endpoints
        protected string _borrowingABookEP = "/api/books/borrow";
        protected string _returningABookEP = "/api/books/return";
        protected string _checkStatusBookEP = "/api/books/status/{bookId}";


        public BaseSteps(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _httpClient = new HttpClient();
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        public string getFullApiBorrowingABook()
        {
            return $"{BaseUrl}{_borrowingABookEP}";
        }

        public string getFullApiReturningABook()
        {
            return $"{BaseUrl}{_returningABookEP}";
        }

        public string getFullApiCheckStatusBook()
        {
            return $"{BaseUrl}{_checkStatusBookEP}";
        }

        public bool verifyOKStatus(HttpResponseMessage response) { 
            return response.IsSuccessStatusCode;
        }
    }
}
