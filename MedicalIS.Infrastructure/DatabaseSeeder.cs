using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Infrastructure
{
    public static class DatabaseSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            var random = new Random();

            if (!db.Doctors.Any())
            {
                db.Doctors.AddRange(
                    new Doctor(Guid.NewGuid(), "Larisa", $"{random.Next(100, 999)}-222", Specialty.Cardiologist),
                    new Doctor(Guid.NewGuid(), "Marina", $"{random.Next(100, 999)}-333", Specialty.Surgeon),
                    new Doctor(Guid.NewGuid(), "Ivan", $"{random.Next(100, 999)}-444", Specialty.Neurologist),
                    new Doctor(Guid.NewGuid(), "Liza", $"{random.Next(100, 999)}-555", Specialty.Pediatrician),
                    new Doctor(Guid.NewGuid(), "Gosha", $"{random.Next(100, 999)}-666", Specialty.Therapist),
                    new Doctor(Guid.NewGuid(), "Daniel", $"{random.Next(100, 999)}-777", Specialty.Pediatrician),
                    new Doctor(Guid.NewGuid(), "Matthew", $"{random.Next(100, 999)}-888", Specialty.Surgeon)
                );
            }

            if (!db.Diseases.Any())
            {
                db.Diseases.AddRange(
                    new Disease(Guid.NewGuid(), "Flu"),
                    new Disease(Guid.NewGuid(), "Cold"),
                    new Disease(Guid.NewGuid(), "Diabetes"),
                    new Disease(Guid.NewGuid(), "Asthma"),
                    new Disease(Guid.NewGuid(), "Pneumonia"),
                    new Disease(Guid.NewGuid(), "Arthritis"),
                    new Disease(Guid.NewGuid(), "Stroke")
                );
            }

            if (!db.Patients.Any())
            {
                db.Patients.AddRange(
                    new Patient(Guid.NewGuid(), "Ivan", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "999-112", Gender.Male, "Moscow"),

                    new Patient(Guid.NewGuid(), "Larisa", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "111-13462", Gender.Female, "New York"),

                    new Patient(Guid.NewGuid(), "James", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "94599-1162", Gender.Male, "London"),

                    new Patient(Guid.NewGuid(), "Michael", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "94399-11762", Gender.Male, "Paris"),

                    new Patient(Guid.NewGuid(), "Mary", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "99349-112754", Gender.Female, "Berlin"),

                    new Patient(Guid.NewGuid(), "William", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "99229-112", Gender.Male, "Madrid"),

                    new Patient(Guid.NewGuid(), "Barbara", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "934699-152312", Gender.Female, "Tokyo"),

                    new Patient(Guid.NewGuid(), "John", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "94699-112352", Gender.Male, "Rome"),

                    new Patient(Guid.NewGuid(), "Jessica", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "92599-112532", Gender.Female, "Toronto"),

                    new Patient(Guid.NewGuid(), "Sarah", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "95399-235112", Gender.Female, "Sydney"),

                    new Patient(Guid.NewGuid(), "Emily", new DateOnly(random.Next(1920, 2010), random.Next(1, 12), random.Next(1, 28)), "92599-12512", Gender.Female, "Dubai")
                );
            }

            db.SaveChanges();
        }
    }
}
