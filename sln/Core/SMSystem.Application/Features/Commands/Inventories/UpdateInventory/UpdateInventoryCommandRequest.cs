using MediatR;

namespace SMSystem.Application.Features.Commands.Inventories.UpdateInventory
{
    public class UpdateInventoryCommandRequest : IRequest<UpdateInventoryCommandResponse>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string WarehouseName { get; set; }
        public int ProductId { get; set; }
    }
}