using Tawsela.Entities;

namespace Tawsela.Repositories.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetAllAsync();
        Task<Contract?> GetByIdAsync(int id);
        Task AddAsync(Contract contract);
        void Update(Contract contract);
        void Delete(Contract contract);
        Task SaveChangesAsync();
    }
}
