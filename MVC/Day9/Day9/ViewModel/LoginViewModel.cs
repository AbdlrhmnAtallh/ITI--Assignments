using System.ComponentModel.DataAnnotations;

namespace Day9.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Ispersisite { get; set; }
    }
}
