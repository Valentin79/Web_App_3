using Microsoft.Identity.Client.Extensions.Msal;
using Seminar_3.Abstractions;
using Seminar_3.Models.DTO;

namespace Seminar_3.Query
{
    public class MySimpleQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<StorageDto> GetStorages([Service] IStorageService service) => service.GetStorages();
        public IEnumerable<CategoryDto> GetCategories([Service] ICategoryService service) => service.GetCategories();
        public IEnumerable<ProductDto> GetProductsToStorage([Service] IStorageService service, int storageId) => service.GetProductsToStorage(storageId);
    }
}
