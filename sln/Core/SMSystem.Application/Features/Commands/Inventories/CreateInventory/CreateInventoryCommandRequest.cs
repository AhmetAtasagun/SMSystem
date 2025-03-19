using MediatR;

namespace SMSystem.Application.Features.Commands.Inventories.CreateInventory
{
    public class CreateInventoryCommandRequest : IRequest<CreateInventoryCommandResponse>
    {
        public int Quantity { get; set; }
        public string WarehouseName { get; set; }
        public int ProductId { get; set; }
    }
}