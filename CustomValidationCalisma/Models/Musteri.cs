using CustomValidationCalisma.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomValidationCalisma.Models
{
    public class Musteri
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // benzersiz bir id uretir

        [Required(ErrorMessage = "{0} alani zorunlu")]
        [MaxLength(50, ErrorMessage = "{0} alani maksimum {1} karakterden olmali")] // 0 yerine ad geliyor 1 yerine 50 geliyor
        [Display(Name = "Isim")] // burada artik 0 yerine Isim geliyor
        public string Ad { get; set; } = null!;

        [Required(ErrorMessage = "{0} alani zorunludur")]
        [Display(Name = "Dogum Tarihi")]
        [DataType(DataType.Date)]
        [YasSiniri(18)]
        public DateTime? DogumTarihi { get; set; }


    }
}
