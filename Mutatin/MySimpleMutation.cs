using Seminar_3.Abstractions;
using Seminar_3.Models.DTO;

namespace Seminar_3.Mutatin
{
    public class MySimpleMutation
    {
        public int AddProduct(ProductDto product, [Service] IProductService service)
        {
            var id = service.AddProduct(product);
            return id;
        }

        public int AddStorage(StorageDto storage, [Service] IStorageService service)
        {
            var id = service.AddStorage(storage);
            return id;
        }
    }
}
