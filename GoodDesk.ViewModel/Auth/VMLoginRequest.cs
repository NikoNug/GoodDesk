using System.ComponentModel.DataAnnotations;

namespace GoodDesk.ViewModel.Auth
{
    public class VMLoginRequest
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
