using System.ComponentModel.DataAnnotations;

namespace UserManager.SpecFlow.Api.Messages.Requests
{
    public class UpdateUserRequest : CreateUserRequest
    {
        [Required]
        public int Id { get; set; }
    }
}