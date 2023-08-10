namespace product.model2.ViewModels
{
    public class ProductListPartialViewModel
    {
        public List<ProductPartialModel> Products { get; set; }
    }
    public class ProductPartialModel
        {
        public int Id { get; set; }

        public string? Name { get; set; }


        public decimal? Price { get; set; }


        public int Stock { get; set; }
    }
}
