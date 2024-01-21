using AutoMapper;
using Seminar_3.Models;
using Seminar_3.Models.DTO;

namespace Seminar_3.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<StorageEntity, StorageDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
