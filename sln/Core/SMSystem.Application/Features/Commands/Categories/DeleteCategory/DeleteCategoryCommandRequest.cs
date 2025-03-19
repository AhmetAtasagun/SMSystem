using MediatR;

namespace SMSystem.Application.Features.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public int Id { get; set; }
    }
}