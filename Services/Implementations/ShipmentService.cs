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
        private readonly INotificationService _notificationService;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
            _notificationService = new NotificationService();
        }

        // to use Singleton pattern
        //public async Task<bool> MarkAsDeliveredAsync(int shipmentId)
        //{
        //    var shipment = await _shipmentRepository.GetByIdAsync(shipmentId);
            
        //    if (shipment == null) 
        //        return false;

        //    shipment.Status = ShipmentStatus.Delivered;

        //    _shipmentRepository.Update(shipment);
        //    await _shipmentRepository.SaveChangesAsync();

        //    NotificationManager.Instance.Notify($"Shipment #{shipment.Id} has been delivered.");

        //    return true;
        //}

        public async Task<bool> MarkAsDeliveredAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(shipmentId);
            if (shipment == null)
                return false;

            shipment.MarkAsDelivered();

            _shipmentRepository.Update(shipment);
            await _shipmentRepository.SaveChangesAsync();

            _notificationService.Notify($"Shipment #{shipment.Id} has been delivered.");
            return true;
        }



        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            return await _shipmentRepository.GetAllAsync();
        }

        // before refactoring
        //public async Task<Shipment?> GetShipmentByIdAsync(int id)
        //{
        //    return await _shipmentRepository.GetByIdAsync(id);
        //}

        // after refactoring
        public async Task<Shipment?> GetShipmentByIdAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);

            if (shipment == null)
                throw new KeyNotFoundException($"Shipment with ID {id} not found.");

            return shipment;
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

        //    before factoring
        //public async Task DeleteShipmentAsync(int id)
        //{
        //    var shipment = await _shipmentRepository.GetByIdAsync(id);
        //    if (shipment != null)
        //    {
        //        _shipmentRepository.Delete(shipment);
        //        await _shipmentRepository.SaveChangesAsync();
        //    }
        //}

        //   after factoring
        public async Task DeleteShipmentAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);

            if (shipment is null)
            {
                NotificationManager.Instance.Notify($"Shipment with ID {id} not found.");
                return;
            }

            _shipmentRepository.Delete(shipment);
            await _shipmentRepository.SaveChangesAsync();

            NotificationManager.Instance.Notify($"Shipment with ID {id} deleted successfully.");
        }



    }
}