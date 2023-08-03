using System.ComponentModel.DataAnnotations;

namespace RapidAPIConsume_WEBUI.DTOs.AccountDtos
{
    public class AccountSettingsDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi onaylayınız")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor!")]
        public string PasswordConfirm { get; set; }
    }
}
