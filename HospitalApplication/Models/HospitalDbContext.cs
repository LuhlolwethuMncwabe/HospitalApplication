using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.Entity;

// This class represents the database context
// It acts as the bridge between the application and the database allowing us to query and save data using Entity Framework.
namespace HospitalApp.Models
{

    // Constructor that accepts options like connection string, provider, ectra., and passes them,
    // to the base DbContext class.
    public class HospitalDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // This DbSet represents the Doctors table in the database
        // Each record in this table will map to a Doctor object
        public HospitalDbContext(DbContextOptions<HospitalDbContext>options)
            : base(options) { }

        // This DbSet represents the Patients table
        // It allows us to perform Create,Read, Update and Delete (CRUD)  operations on Patient data
        public Microsoft.EntityFrameworkCore.DbSet<Doctor> Doctors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Patient> Patients { get; set; }
    }
}

