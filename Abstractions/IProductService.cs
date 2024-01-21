using Seminar_3.Models.DTO;

namespace Seminar_3.Abstractions
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}
