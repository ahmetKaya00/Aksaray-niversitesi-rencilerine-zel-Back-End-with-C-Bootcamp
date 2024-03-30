using System.ComponentModel.DataAnnotations;

namespace ETicaret.Models
{
    public class Product{

        [Display(Name="Urun Id")]
        public int ProductId {get;set;}

        [Display(Name="Ürün Adı")]
        [Required(ErrorMessage ="Ürün adı bilgisini giriniz")]
        [StringLength(100)]
        public string? Name {get;set;} 

        [Display(Name="Fiyatı")]
        [Required(ErrorMessage ="Fiyat adı bilgisini giriniz")]
        [Range(0,105000,ErrorMessage = "0 ile 105000 arası bir fiyat girin")]
        public decimal? Price {get;set;}
        public string? Image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Required]
        public int? CategoryId {get;set;}
    }
}