using System.ComponentModel.DataAnnotations;

namespace Catcher.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "使用者")]
        public string? User { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string? Mema { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }
}
