namespace UserManager.SpecFlow.Api.Messages.Requests
{
    public class CreateUserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
    }
}