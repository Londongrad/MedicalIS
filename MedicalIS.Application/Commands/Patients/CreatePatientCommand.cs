using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Commands.Patients
{
    public class CreatePatientCommand
    {
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
