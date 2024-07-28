using System.ComponentModel.DataAnnotations;
using DatingApp.BusinessLayer.Enums;

namespace DatingApp.BusinessLayer.Models.User.Request
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "The email must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The firstname is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The lastname is required.")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
