using Tawsela.Entities;
using Tawsela.Services.Interfaces;
using Tawsela.Repositories.Interfaces;
using Tawsela.Patterns;
using Tawsela.Enums;

namespace Tawsela.Services.Implementations
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        // to use Singleton pattern
        public async Task<bool> MarkAsDeliveredAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(shipmentId);
            if (shipment == null) return false;

            shipment.Status = ShipmentStatus.Delivered;

            _shipmentRepository.Update(shipment);
            await _shipmentRepository.SaveChangesAsync();

            // ✅ Notify via Singleton
            NotificationManager.Instance.Notify($"Shipment #{shipment.Id} has been delivered.");

            return true;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            return await _shipmentRepository.GetAllAsync();
        }

        public async Task<Shipment?> GetShipmentByIdAsync(int id)
        {
            return await _shipmentRepository.GetByIdAsync(id);
        }

        public async Task CreateShipmentAsync(Shipment shipment)
        {
            await _shipmentRepository.AddAsync(shipment);
            await _shipmentRepository.SaveChangesAsync();
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            _shipmentRepository.Update(shipment);
            await _shipmentRepository.SaveChangesAsync();
        }

        public async Task DeleteShipmentAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            if (shipment != null)
            {
                _shipmentRepository.Delete(shipment);
                await _shipmentRepository.SaveChangesAsync();
            }
        }
    }
}