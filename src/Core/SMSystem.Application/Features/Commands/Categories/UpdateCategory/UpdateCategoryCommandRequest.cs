using MediatR;
using SMSystem.Domain.Dtos;
using System.Collections.Generic;

namespace SMSystem.Application.Features.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        
        // Localized properties
        public List<LocalizedStringDto> LocalizedNames { get; set; } = new List<LocalizedStringDto>();
    }
}