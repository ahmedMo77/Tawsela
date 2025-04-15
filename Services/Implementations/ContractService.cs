using Tawsela.Entities;
using Tawsela.Services.Interfaces;
using Tawsela.Repositories.Interfaces;

namespace Tawsela.Services.Implementations
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<IEnumerable<Contract>> GetAllContractsAsync()
        {
            return await _contractRepository.GetAllAsync();
        }

        public async Task<Contract?> GetContractByIdAsync(int id)
        {
            return await _contractRepository.GetByIdAsync(id);
        }

        public async Task CreateContractAsync(Contract contract)
        {
            await _contractRepository.AddAsync(contract);
            await _contractRepository.SaveChangesAsync();
        }

        public async Task UpdateContractAsync(Contract contract)
        {
            _contractRepository.Update(contract);
            await _contractRepository.SaveChangesAsync();
        }

        public async Task DeleteContractAsync(int id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract != null)
            {
                _contractRepository.Delete(contract);
                await _contractRepository.SaveChangesAsync();
            }
        }
    }

}
