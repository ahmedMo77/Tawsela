using Tawsela.Entities;

namespace Tawsela.Services.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> GetAllContractsAsync();
        Task<Contract?> GetContractByIdAsync(int id);
        Task CreateContractAsync(Contract contract);
        Task UpdateContractAsync(Contract contract);
        Task DeleteContractAsync(int id);
    }

}
