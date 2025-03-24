using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronicDiseaseApplication.Data
{
    public class HealthMetricRepository : IHealthMetricRepository
    {
        private readonly AppDbContext _context;

        public HealthMetricRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMetricAsync(HealthMetric metric)
        {
            await _context.HealthMetrics.AddAsync(metric);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<HealthMetric>> GetMetricsByPatientIdAsync(int patientId)
        {
            return await _context.HealthMetrics
                .Where(m => m.PatientId == patientId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }
        public async Task<List<HealthMetricDto>> GetMetrics()
        {
            return await _context.HealthMetrics
                .Select(m => new HealthMetricDto
                {
                    PatientId = m.PatientId,
                    MetricType = m.MetricType,
                    Value = m.Value,
                })
                .ToListAsync();
        }
    }
}
