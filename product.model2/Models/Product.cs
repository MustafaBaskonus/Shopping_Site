using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace product.model2.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

       
        public decimal? Price { get; set; }

        
        public string Description { get; set; }
        
        public int Stock { get; set; }
        
        public string? Color { get; set; }

        public bool IsPublish { get; set; }
       
        public int Expire { get; set; }
        

        public DateTime? PublishDate  { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
