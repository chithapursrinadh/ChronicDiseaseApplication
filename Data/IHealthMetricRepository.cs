using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;

namespace ChronicDiseaseApplication.Data
{
    public interface IHealthMetricRepository
    {
        Task AddMetricAsync(HealthMetric metric);  
        Task<IEnumerable<HealthMetric>> GetMetricsByPatientIdAsync(int patientId);
        Task<List<HealthMetricDto>> GetMetrics();
    }
}
