using Tawsela.Entities;

namespace Tawsela.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetAllAsync();
        Task<Shipment?> GetByIdAsync(int id);
        Task AddAsync(Shipment shipment);
        void Update(Shipment shipment);
        void Delete(Shipment shipment);
        Task SaveChangesAsync();
    }
}