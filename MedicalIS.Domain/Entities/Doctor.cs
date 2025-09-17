using MedicalIS.Domain.Common;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Domain.Entities
{
    public class Doctor : EntityBase
    {
        #region [ Fields ]

        private readonly List<Patient> _patients = new();

        #endregion [ Fields ]

        #region [ Properties ]

        public string FullName { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public Specialty Specialty { get; private set; }
        public IReadOnlyCollection<Patient> Patients => _patients;

        #endregion [ Properties ]

        #region [ Ctors ]

        private Doctor() { } // EF Core

        public Doctor(Guid id, string fullName, string phoneNumber, Specialty scpecialty)
            :base(id)
        {
            GuardHelper.AgainstEmptyGuid(id, nameof(id));
            GuardHelper.AgainstNullOrEmpty(fullName, nameof(fullName));
            GuardHelper.AgainstNullOrEmpty(phoneNumber, nameof(phoneNumber));
            GuardHelper.AgainstInvalidEnum(scpecialty, nameof(scpecialty));

            FullName = fullName;
            PhoneNumber = phoneNumber;
            Specialty = scpecialty;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        public void ChangePhone(string newPhone)
        {
            PhoneNumber = newPhone;
            UpdateTimestamp();
        }

        public void ChangeSpecialty(Specialty newSpecialty)
        {
            Specialty = newSpecialty;
            UpdateTimestamp();
        }

        #endregion [ Methods ]
    }
}
