using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HospitalApp.Models
{
    public class Doctor
    {
        // This is the primary key for the Doctor table
        // Each doctor will have a unique ID automatically generated
        [Key]
        public int DoctorId { get; set; }

        // Doctor's first name is required and limited to 50 characters
        // The Display attribute just makes the label look nicer in the User interface
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Same idea as FirstName, but for the last name
        // Keeping it consistent helps with validation and User interface display
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // This stores what the doctor specializes in, for example,Cardiologist
        // Required so that every doctor has a defined field of expertise
        [Required]
        [StringLength(100)]
        public string Specialization { get; set; }

        // Phone number is required and validated using the '[Phone]' attribute
        // This helps ensure the format is somewhat correct when entered
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Email is also required and must follow a valid email format
        // Useful for communication and login-related features later on
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // License number is optional but capped at 20 characters.
        // Could be useful for verification or regulatory purposes
        [StringLength(20)]
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }

        // This keeps track of how experienced the doctor is
        // The range ensures no negative values or unrealistic numbers
        [Range(0, 50)]
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }

        // Indicates whether the doctor is currently available
        // Defaults to true so new doctors are assumed available unless changed
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true;

        // Navigation Property (one Doctor → many Patients)
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
