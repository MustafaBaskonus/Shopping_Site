using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace product.model2.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        [Remote (action: "HasProductName", controller: "Products")]
        [StringLength(30,ErrorMessage ="isim uzunluğu en fazla 30 karekter olur.")]
        [Required(ErrorMessage = "İsim alanı boş olamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş olamaz")]
        [Range(1,1000,ErrorMessage ="Fiyat1 ila 1000 arası olabilir.")]
        public decimal Price { get; set; }

        [StringLength(300, MinimumLength =30,ErrorMessage ="30 ile 300 arası kararekter lazım.")]
        [Required(ErrorMessage = "Açıklma alanı boş olamaz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Stok alanı boş olamaz")]
        [Range(1,200,ErrorMessage = "1 ile 200 arası stok olmalıdır.")]
       
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Renk Seçimi  boş olamaz")]
        public string? Color { get; set; }
       
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Yayınlanma süresi  boş olamaz")]
        public int Expire { get; set; }
        [Required(ErrorMessage = "Yayınlanma tarihi  boş olamaz")]

        //[EmailAddress(ErrorMessage ="Email adresi formata uygun değil.")]
        //public string EmailAdress { get; set; }

        public DateTime? PublishDate { get; set; }


    }
}
