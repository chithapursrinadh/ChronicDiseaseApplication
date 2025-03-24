using ChronicDiseaseApplication.Data;
using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronicDiseaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderRepository _repository;

        public ProvidersController(IProviderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProviderDTO>>> GetAllProviders()
        {
            var providers = await _repository.GetAllAsync();
            return providers.Select(p => new ProviderDTO
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Specialization = p.Specialization
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDTO>> GetProvider(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider == null) return NotFound();

            return new ProviderDTO
            {
                Id = provider.Id,
                Name = provider.Name,
                Email = provider.Email,
                Specialization = provider.Specialization
            };
        }

        [HttpPost]
        public async Task<ActionResult> AddProvider([FromBody] ProviderDTO providerDTO)
        {
            var provider = new Provider
            {
                Name = providerDTO.Name,
                Email = providerDTO.Email,
                Specialization = providerDTO.Specialization
            };

            await _repository.AddAsync(provider);
            return CreatedAtAction(nameof(GetProvider), new { id = provider.Id }, providerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProvider(int id, [FromBody] ProviderDTO providerDTO)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider == null) return NotFound();

            provider.Name = providerDTO.Name;
            provider.Email = providerDTO.Email;
            provider.Specialization = providerDTO.Specialization;

            await _repository.UpdateAsync(provider);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProvider(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
