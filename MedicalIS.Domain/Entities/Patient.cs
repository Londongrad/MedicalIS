using MedicalIS.Domain.Common;
using MedicalIS.Domain.Enums;
using System.Numerics;

namespace MedicalIS.Domain.Entities
{
    public class Patient : EntityBase
    {
        #region [ Properties ]

        public string FullName { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; } = null!;
        public Gender Gender { get; private set; }

        /// <summary>Адрес можно было бы сделать отдельным классом. Оставил для простоты.</summary>
        public string Address { get; private set; } = null!;
        public Guid DoctorId { get; private set; }

        /// <summary>Навигационное свойство</summary>
        public Doctor Doctor { get; private set; } = null!;

        /// <summary>Навигационное свойство</summary>
        public ICollection<PatientDisease> PatientDiseases { get; private set; } = [];

        #endregion [ Properties ]

        #region [ Ctors ]

        private Patient() { } // EF Core

        public Patient(Guid id, string fullName, DateTime dateOfBirth, string phone, Gender gender, string address)
            : base(id)
        {
            GuardHelper.AgainstEmptyGuid(id, nameof(id));
            GuardHelper.AgainstNullOrEmpty(fullName, nameof(fullName));
            GuardHelper.AgainstInvalidDate(dateOfBirth, nameof(dateOfBirth));
            GuardHelper.AgainstNullOrEmpty(phone, nameof(phone));
            GuardHelper.AgainstInvalidEnum(gender, nameof(gender));
            GuardHelper.AgainstNullOrEmpty(address, nameof(address));

            FullName = fullName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phone;
            Gender = gender;
            Address = address;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        public void ChangePhone(string newPhone)
        {
            GuardHelper.AgainstNullOrEmpty(newPhone, nameof(newPhone));

            PhoneNumber = newPhone;
            UpdateTimestamp();
        }

        public void AssignDoctor(Guid doctorId)
        {
            GuardHelper.AgainstEmptyGuid(doctorId, nameof(doctorId));

            DoctorId = doctorId;
            UpdateTimestamp();
        }

        #endregion [ Properties ]
    }
}
