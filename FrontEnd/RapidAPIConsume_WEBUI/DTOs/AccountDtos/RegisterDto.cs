using System.ComponentModel.DataAnnotations;

namespace RapidAPIConsume_WEBUI.DTOs.AccountDtos
{
    public class RegisterDto
    {
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        [Required(ErrorMessage = "Lütfen bir mail adresi giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor!")]
        public string PasswordConfirm { get; set; }
    }
}
