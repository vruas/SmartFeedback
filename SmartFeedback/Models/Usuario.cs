using Microsoft.AspNetCore.Identity;

namespace SmartFeedback.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        Usuario() : base() { }
    }
}
