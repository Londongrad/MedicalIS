using MedicalIS.Domain.Common;

namespace MedicalIS.Domain.Entities
{
    public class Patient : EntityBase
    {
        #region [ Properties ]

        public string FullName { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; } = null!;
        public string Gender { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public Guid DoctorId { get; private set; }

        /// <summary>Навигационное свойство</summary>
        public Doctor Doctor { get; private set; } = null!;

        /// <summary>Навигационное свойство</summary>
        public ICollection<PatientDisease> PatientDiseases { get; private set; } = [];

        #endregion [ Properties ]

        #region [ Ctors ]

        protected Patient() { } // EF Core

        public Patient(Guid id, string fullName, DateTime dateOfBirth, string phone)
            : base(id)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phone;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        public void ChangePhone(string newPhone)
        {
            PhoneNumber = newPhone;
            UpdateTimestamp();
        }

        #endregion [ Properties ]
    }
}
