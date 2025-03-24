using ChronicDiseaseApplication.Data;
using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;
using ChronicDiseaseApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronicDiseaseApplication.Controllers
{
    [Authorize]
    [Route("api/health-metrics")]
    [ApiController]
    public class HealthMetricsController : ControllerBase
    {
        private readonly IHealthMetricRepository _service;

        public HealthMetricsController(IHealthMetricRepository service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetric(HealthMetric metric)
        {
            await _service.AddMetricAsync(metric);
            return Ok("Metric added successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetMetrics()
        {
            var metrics = await _service.GetMetrics();
            return Ok(metrics);
        }
    }
}
