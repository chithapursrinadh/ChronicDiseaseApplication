using System.ComponentModel.DataAnnotations;

namespace ChronicDiseaseApplication.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Specialization { get; set; }
    }
}
