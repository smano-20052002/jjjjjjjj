using LXP.Common.ViewModels;

namespace LXP.Core.IServices
{
    public interface ICategoryServices
    {
        Task<bool> AddCategory(CourseCategoryViewModel category);
        Task<List<CourseCategoryListViewModel>> GetAllCategory();
        Task<CourseCategoryListViewModel> GetCategoryByCategoryName(string categoryName);
    }
}
