using Microsoft.AspNetCore.Http;

namespace LXP.Common.ViewModels
{
    public class MaterialUpdateViewModel
    {
        public string MaterialId { get; set; }

        public string Name { get; set; } = null!;

        public IFormFile Material { get; set; } = null!;

        public string? ModifiedBy { get; set; }
    }
}
