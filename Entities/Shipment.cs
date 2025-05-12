using Tawsela.Enums;

namespace Tawsela.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string PickupAddress { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ShipmentStatus Status { get; set; }

        // Foreign Keys
        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;

        // delivery or shiping company
        public int? CourierId { get; set; }
        public User? Courier { get; set; }

        public void MarkAsDelivered()
        {
            Status = ShipmentStatus.Delivered;
        }
    }
}