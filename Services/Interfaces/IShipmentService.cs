using Tawsela.Entities;

namespace Tawsela.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task<Shipment?> GetShipmentByIdAsync(int id);
        Task CreateShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int id);
    }

}
