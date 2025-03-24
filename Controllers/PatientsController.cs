using ChronicDiseaseApplication.Data;
using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronicDiseaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDTO>>> GetAllPatients()
        {
            var patients = await _repository.GetAllAsync();
            return patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Age = p.Age,
                Gender = p.Gender,
                MedicalHistory = p.MedicalHistory
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null) return NotFound();

            return new PatientDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email,
                Age = patient.Age,
                Gender = patient.Gender,
                MedicalHistory = patient.MedicalHistory
            };
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] PatientDTO patientDTO)
        {
            var patient = new Patient
            {
                Name = patientDTO.Name,
                Email = patientDTO.Email,
                Age = patientDTO.Age,
                Gender = patientDTO.Gender,
                MedicalHistory = patientDTO.MedicalHistory
            };

            await _repository.AddAsync(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patientDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody] PatientDTO patientDTO)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null) return NotFound();

            patient.Name = patientDTO.Name;
            patient.Email = patientDTO.Email;
            patient.Age = patientDTO.Age;
            patient.Gender = patientDTO.Gender;
            patient.MedicalHistory = patientDTO.MedicalHistory;

            await _repository.UpdateAsync(patient);
            return NoContent();
        }
    }
}
