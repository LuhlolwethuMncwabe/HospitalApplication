using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HospitalApp.Models
{
    public class Patient
    {
        // Primary key for the Patient table.
        // This will uniquely identify each patient in the database.
        [Key]
        public int PatientId { get; set; }

        // Patient's first name is required.
        // We limited it to 50 characters to keep things consistent and avoid overly long inputs.
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        // Same approach as FirstName, just for the last name
        // Keeping validation consistent across similar fields
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        // Stores the patient's date of birth
        // Using DataType.Date so it shows properly in forms
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        // Basic field for gender
        // Kept as a string for simplicity, but still limited in length.
        [Required]
        [StringLength(10)]
        public required string Gender { get; set; }

        // Contact number is required and validated using the Phone attribute
        // Helps catch obvious formatting issues during input.
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; }

        // Email is required and must follow a valid format
        // This could be useful later for notifications or login features
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        // Stores the patient's address
        // I allowed a bit more space here since addresses can get long.
        [StringLength(250)]
        public required string Address { get; set; }

        // Tracks when the patient was admitted.
        // Defaults to the current date and time when a new record is created.
        [DataType(DataType.Date)]
        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        // Optional field for any extra medical notes
        // Not required, since not every patient will have notes immediately
        [StringLength(500)]
        [Display(Name = "Medical Notes")]
        public string? MedicalNotes { get; set; }

        // Foreign Key
        public int DoctorId { get; set; }

        // Navigation Property
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}