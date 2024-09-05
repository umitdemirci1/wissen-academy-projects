using System.ComponentModel.DataAnnotations;

namespace ValidationApp.Models.Validation
{
    public class MailValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string kontrolEdilecekVeri = string.Empty;
            if (value != null)
            {
                kontrolEdilecekVeri = value.ToString();
            }
            else return false;

            if (kontrolEdilecekVeri.Where(x => x == ' ').ToList().Count > 0)
                return false;

            if (kontrolEdilecekVeri.Split('@').Length != 2)
                return false;
            //neden != 2. Çünkü e-posta adresi sadece bir tane @ işareti içerebilir.
            //öyleyse return değeri neden false? Çünkü @ işaretinden önce ve sonra en az bir karakter olmalıdır.

            if (kontrolEdilecekVeri.EndsWith("@contoso.com"))
                return true;

            return false;
            //return base.IsValid(value);
        }
    }
}
