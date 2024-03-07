using System.ComponentModel.DataAnnotations;

namespace PersionalExpenditureManagement.ViewModel
{
    public class CreateUserRequest
    {
        [Required]
        public CreateRequestPayload payload { get; set; }
    }

    public class CreateRequestPayload
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
    }
}
