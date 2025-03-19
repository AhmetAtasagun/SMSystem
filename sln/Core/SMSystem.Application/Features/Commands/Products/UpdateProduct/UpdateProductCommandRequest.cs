using MediatR;
using SMSystem.Domain.Dtos;
using System.Collections.Generic;

namespace SMSystem.Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        
        // Localized properties
        public List<LocalizedStringDto> LocalizedNames { get; set; } = new List<LocalizedStringDto>();
        public List<LocalizedStringDto> LocalizedDescriptions { get; set; } = new List<LocalizedStringDto>();
    }
}