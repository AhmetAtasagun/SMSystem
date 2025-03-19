using MediatR;

namespace SMSystem.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}