using ChronicDiseaseApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronicDiseaseApplication.Data
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDbContext _context;

        public ProviderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Provider>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var provider = await _context.Providers.FindAsync(id);
            if (provider != null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }
        }
    }
}
