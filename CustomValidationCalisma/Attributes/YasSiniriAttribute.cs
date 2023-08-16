using System.ComponentModel.DataAnnotations;

namespace CustomValidationCalisma.Attributes
{
    public class YasSiniriAttribute : ValidationAttribute
    {

        public YasSiniriAttribute(int yas)
        {
            Yas = yas;
        }
        public int Yas { get; }

        public string HataMesaji => $"Yasi en az {Yas} olmalidir";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? tarih = value as DateTime?;



            if (tarih != null && YasHesapla(tarih.Value) < Yas)
            {
                return new ValidationResult(HataMesaji);
            }
            return ValidationResult.Success;
        }

        private int YasHesapla(DateTime value)
        {
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - value.Year;

            if (value.Month > bugun.Month || value.Month == bugun.Month && value.Day > bugun.Day)
            {
                return yas - 1;
            }

            return yas;
        }
    }
}
