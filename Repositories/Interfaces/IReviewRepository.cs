using Tawsela.Entities;

namespace Tawsela.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task AddAsync(Review review);
        void Update(Review review);
        void Delete(Review review);
        Task SaveChangesAsync();
    }

}
