using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Seminar_3.Models.DTO;
using Seminar_3.Models;
using Seminar_3.Abstractions;

namespace Seminar_3.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public StorageService(AppDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddStorage(StorageDto storage)
        {
            using (_context)
            {
                var entity = _mapper.Map<StorageEntity>(storage);

                _context.Storages.Add(entity);
                _context.SaveChanges();
                _cache.Remove("storages");

                return entity.Id;
            }
        }

        public IEnumerable<StorageDto> GetStorages()
        {
            using (_context)
            {
                if (_cache.TryGetValue("storages", out List<StorageDto> storages))
                    return storages;

                storages = _context.Storages.Select(x => _mapper.Map<StorageDto>(x)).ToList();
                _cache.Set("storages", storages, TimeSpan.FromMinutes(30));

                return storages;
            }
        }

        public IEnumerable<ProductDto> GetProductsToStorage(int storageId)
        {
            var products = new List<ProductDto>();
            using (_context)
            {
                products.AddRange(_context.Storages.FirstOrDefault(x => x.Id.Equals(storageId))
                    .Products.Select(x => _mapper.Map<ProductDto>(x)).ToList());
                return products;
            }
        }

        
    }
}
