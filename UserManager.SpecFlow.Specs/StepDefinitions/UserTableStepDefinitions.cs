using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow.Assist;
using UserManager.SpecFlow.Api.Models;

namespace UserManager.SpecFlow.Specs.StepDefinitions
{
    [Binding]
    [Scope(Feature = "UserTable")]
    public class UserTableStepDefinitions : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client { get; set; }

        protected HttpResponseMessage Response { get; set; }

        public UserTableStepDefinitions(WebApplicationFactory<Program> factory)
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

        [When(@"I make a post request to '([^']*)' with following data")]
        public virtual async Task WhenIMakeAPostRequestToWithFollowingData(string resourceEndPoint, Table table)
        {
            var user = table.CreateInstance<User>();
            string postDataJson = JsonSerializer.Serialize(user);

            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }

        [Then(@"the response status code is '([^']*)'")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
    }
}