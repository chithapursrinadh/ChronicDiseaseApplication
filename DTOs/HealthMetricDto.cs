using System.ComponentModel.DataAnnotations;

namespace ChronicDiseaseApplication.DTOs
{
    public class HealthMetricDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public string MetricType { get; set; } 

        [Required]
        public double Value { get; set; } 

        [Required]
        public DateTime DateRecorded { get; set; }
    }
}
