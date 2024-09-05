using System.ComponentModel.DataAnnotations;

namespace ValidationApp.Models.Validation
{
    public class IdentificationNumberValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int toplam = 0, ciftToplam = 0, tekToplam = 0;

            if (value == null)
                return false;

            string id = value.ToString();

            if (id.Length != 11)
                return false;

            if (id[0] == '0')
                return false;

            for (int i = 0; i < id.Length; i++)
            {
                if (char.IsDigit(id[i]) == false)
                    return false;
            }

            int[] tcNumber = new int[11];
            for (int i = 0; i < 11; i++)
            {
                tcNumber[i] = int.Parse(id[i].ToString());
            }
            //char[] tcNumber = id.ToCharArray();

            int tenDigit = 0;
            for (int i = 0; i < 10; i++)
            {
                tenDigit += tcNumber[i];
            }
            
            if (tenDigit % 10 != tcNumber[10])
                return false;

            
            //Daha fazla kontrol de yapılabilir. ilk 10 karakter toplamının 10 a bölümü son karakteri vermeli.

            return true;
            //return base.IsValid(value);
        }
    }
}
