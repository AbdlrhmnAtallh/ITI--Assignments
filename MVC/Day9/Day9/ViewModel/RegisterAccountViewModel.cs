using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Day9.ViewModel
{
    public class RegisterAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage="Password Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
