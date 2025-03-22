using SMSystem.Domain.Dtos;
using System.Collections.Generic;

namespace SMSystem.WebAPI.ViewModel
{
    public class UpdateProductFormModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; } // Existing image path
        public IFormFile ImageFile { get; set; } // New image file (optional)
        
        // Localized properties
        public List<LocalizedStringDto> LocalizedNames { get; set; } = new List<LocalizedStringDto>();
        public List<LocalizedStringDto> LocalizedDescriptions { get; set; } = new List<LocalizedStringDto>();
    }
}