using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidationApp.Models.Validation
{
    public class SystemUserValidation
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "T.C. Kimlik Numarası boş geçilemez")]
        [IdentificationNumberValidation(ErrorMessage = "T.C. Kimlik Numarası hatalı")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Puan Alanı boş geçilemez")]
        [Range(0, 100, ErrorMessage = "Puan 0-100 arasında olmalıdır")]
        public int Score { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş geçilemez")]
        [MailValidation(ErrorMessage = "E-posta adresi @contoso.com ile sonlanmalı ve boşluk içermemelidir")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifre 6-20 karakter arasında olmalıdır")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Şifre tekrarı boş geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string PasswordConfirmation { get; set; }
    }
}
