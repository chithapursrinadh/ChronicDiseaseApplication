using ChronicDiseaseApplication.Models;

namespace ChronicDiseaseApplication.Data
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllAsync();
        Task<Provider> GetByIdAsync(int id);
        Task AddAsync(Provider provider);
        Task UpdateAsync(Provider provider);
        Task DeleteAsync(int id);
    }
}
