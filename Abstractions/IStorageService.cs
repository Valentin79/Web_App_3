using Seminar_3.Models.DTO;

namespace Seminar_3.Abstractions
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetStorages();
        int AddStorage(StorageDto storage);
        IEnumerable<ProductDto> GetProductsToStorage(int storageId);
    }
}
