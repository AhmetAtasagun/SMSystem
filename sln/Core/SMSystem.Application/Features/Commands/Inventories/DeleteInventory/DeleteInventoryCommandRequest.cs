using MediatR;

namespace SMSystem.Application.Features.Commands.Inventories.DeleteInventory
{
    public class DeleteInventoryCommandRequest : IRequest<DeleteInventoryCommandResponse>
    {
        public int Id { get; set; }
    }
}