using Microsoft.EntityFrameworkCore;
using Tawsela.Entities;
using Tawsela.Repositories.Interfaces;

namespace Tawsela.Repositories.Implementations
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AppDbContext _context;

        public ShipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task<Shipment?> GetByIdAsync(int id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task AddAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
        }

        public void Update(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
        }

        public void Delete(Shipment shipment)
        {
            _context.Shipments.Remove(shipment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}