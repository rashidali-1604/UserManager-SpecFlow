using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;

namespace UserManager.SpecFlow.Specs.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client { get; set; }

        protected HttpResponseMessage Response { get; set; }

        public UserStepDefinitions(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:7009/")
            });
        }

        [When(@"I make a post request to '([^']*)' with the following data '([^']*)'")]
        public virtual async Task WhenIMakeAPostRequestToWithTheFollowingData(string resourceEndPoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }

        [When(@"I make a delete request to '([^']*)'")]
        public virtual async Task WhenIMakeADeleteRequestTo(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await _client.DeleteAsync(postRelativeUri).ConfigureAwait(false);
        }

        [When(@"I make a get request to '([^']*)'")]
        public virtual async Task WhenIMakeAGetRequestTo(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);
        }



        [Then(@"the response status code is '([^']*)'")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
    }
}