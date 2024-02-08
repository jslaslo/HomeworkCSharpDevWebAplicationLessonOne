using Microsoft.AspNetCore.Mvc;
using StoreMarket.Context;
using StoreMarket.Contracts.Responses;
using StoreMarket.Contracts.Requests;
using StoreMarket.Models;
using StoreMarket.Abstractions;

namespace StoreMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products/{id}")]

        public ActionResult<ProductResponse> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpGet]
        [Route("products")]
        public ActionResult<IEnumerable<ProductResponse>> GetProducts()
        {
            var products = _productService.GetProducts();

            return Ok(products);
        }

        [HttpPost]
        [Route("create")]

        public ActionResult<int> AddProducts(ProductCreateRequest request)
        {
            try
            {
                var id = _productService.AddProduct(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete/product")]
        public ActionResult DeleteProduct(int id)
        {
            bool isDelete = _productService.DeleteProduct(id);
            if (isDelete)
            {
                return Ok($"Product deleted");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("delete/category")]
        public ActionResult DeleteCategory(string category)
        {
            bool isDelete = _productService.DeleteCategory(category);

            if (isDelete)
            {
                return Ok($"Category deleted");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("update/price")]
        public ActionResult UpdatePrice(int productId, int actualPrice)
        {
            bool isUpdate = _productService.UpdatePrice(productId, actualPrice);

            if (isUpdate)
            {
                return Ok($"Category deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
