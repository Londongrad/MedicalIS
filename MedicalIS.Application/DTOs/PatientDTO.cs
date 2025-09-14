namespace MedicalIS.Application.DTOs
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public List<string> Diseases { get; set; } = [];
    }
}
