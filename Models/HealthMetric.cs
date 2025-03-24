using System.ComponentModel.DataAnnotations;

namespace ChronicDiseaseApplication.Models
{
    public class HealthMetric
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        public string MetricType { get; set; }

        [Required]
        public double Value { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
