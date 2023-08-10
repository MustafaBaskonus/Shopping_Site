namespace product.model2.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()//
        {
                

        };
        public List<Product> GetAll() => _products;// tek satır kod olduğu için {} bunu kullanmadık => bunu kullandık.

        public void Add(Product product) => _products.Add(product);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);
            if (hasProduct != null)
            {
                // throw new Exception($"Bu id({id}) ' ye sahip ürün bulunmamaktadir.");

            }
            _products.Remove(hasProduct);//bu ürünü siler.
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);//bu id ye ait veri var mı varsa ata. yoksa null.
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(p => p.Id == updateProduct.Id);// güncellenecek verinin id sini bul.
            _products[index] = hasProduct;

        }

    }
}
