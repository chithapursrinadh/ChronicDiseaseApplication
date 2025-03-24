using System.ComponentModel.DataAnnotations;

namespace ChronicDiseaseApplication.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        public string Gender { get; set; }
        public string MedicalHistory { get; set; }
    }
}
