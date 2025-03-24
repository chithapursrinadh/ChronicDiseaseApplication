using ChronicDiseaseApplication.Data;
using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronicDiseaseApplication.Services
{
   
        public class HealthMetricService : IHealthMetricRepository
        {
            private readonly IHealthMetricRepository _repository;

            public HealthMetricService(IHealthMetricRepository repository)
            {
                _repository = repository;
            }

            public async Task AddMetric(HealthMetricDto metricDto)  
            {
                var metric = new HealthMetric
                {
                    PatientId = metricDto.PatientId,
                    MetricType = metricDto.MetricType,
                    Value = metricDto.Value
                };

                await _repository.AddMetricAsync(metric);  
            }
        
        public async Task<IEnumerable<HealthMetric>> GetMetricsByPatientIdAsync(int patientId)
            {
                return await _repository.GetMetricsByPatientIdAsync(patientId);
            }
        }
    
}
