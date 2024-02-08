using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;

namespace StoreMarket.Abstractions
{
    public interface IProductService
    {
        public int AddProduct(ProductCreateRequest product);
        public IEnumerable<ProductResponse> GetProducts();

        public ProductResponse GetProductById(int id);
        public bool DeleteProduct(int id);
        public bool UpdatePrice(int idProduct, int price);
        public bool DeleteCategory(string category);
    }
}
