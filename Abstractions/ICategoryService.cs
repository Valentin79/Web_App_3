using Seminar_3.Models.DTO;

namespace Seminar_3.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        int AddCategory(CategoryDto category);
    }
}
