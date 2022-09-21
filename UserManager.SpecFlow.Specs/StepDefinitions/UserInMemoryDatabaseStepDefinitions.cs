using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using UserManager.SpecFlow.Api.Models;
using UserManager.SpecFlow.Api.Repositories.Interfaces;
using UserManager.SpecFlow.Api.Services;
using UserManager.SpecFlow.Api.Services.Interfaces;

namespace UserManager.SpecFlow.Specs.StepDefinitions
{
    [Binding]
    [Scope(Feature = "UserInMemoryDatabase")]
    public class UserInMemoryDatabaseStepDefinitions : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client { get; set; }

        protected HttpResponseMessage Response { get; set; }

        private IUserService _userService;

        private Mock<IUserRepository> _mockUserRepository;

        private User _user;

        public UserInMemoryDatabaseStepDefinitions(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [BeforeScenario]
        public void SetupTestUsers()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns(new User()
            {
                Id = 14,
                FirstName = "Test",
                LastName = "User",
                EmailAddress = "testUser@mailinator.com"
            }
            );
        }

        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            _userService = new UserService(_mockUserRepository.Object);
        }

        [When(@"I get User details with id (.*)")]
        public void WhenIGetUserDetailsWithId(int id)
        {
            _user = _userService.GetUserById(id);
        }

        [Then(@"following result is returned")]
        public void ThenFollowingResultIsReturned(Table table)
        {
            var actualUser = _user;

            var expectedUser = table.CreateInstance<User>();

            Assert.Equal(expectedUser.Id, actualUser.Id);

            Assert.Equal(expectedUser.FirstName, actualUser.FirstName);

            Assert.Equal(expectedUser.LastName, actualUser.LastName);
            Assert.Equal(expectedUser.EmailAddress, actualUser.EmailAddress);
        }
    }
}