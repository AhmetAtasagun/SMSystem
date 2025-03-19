using SMSystem.Domain.Dtos;
using System.Collections.Generic;

namespace SMSystem.WebAPI.ViewModel
{
    public class UpdateCategoryViewModel
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        
        // Localized properties
        public List<LocalizedStringDto> LocalizedNames { get; set; } = new List<LocalizedStringDto>();
    }
}