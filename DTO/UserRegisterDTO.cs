using System.ComponentModel.DataAnnotations;

namespace web_api.DTO
{
    public class UserRegisterDTO
    {
        [StringLength(50)] 
        public string UserName { get; set; }

        [Required] 
        public string Password { get; set; }

        [EmailAddress] 
        public string Email { get; set; }

        [Phone] 
        public string Phone { get; set; }
    }
}
